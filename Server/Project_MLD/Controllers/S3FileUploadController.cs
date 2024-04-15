using System.IO;
using System.Threading.Tasks;
using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_MLD.DTO;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3FileUploadController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;
        private readonly ILogger<S3FileUploadController> _logger;

        public S3FileUploadController(IAmazonS3 s3Client, ILogger<S3FileUploadController> logger)
        {
            _s3Client = s3Client;
            _logger = logger;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadFiles(ICollection<IFormFile> files, string? prefix)
        {
            if (files == null || files.Count == 0)
            {
                return BadRequest("No file uploaded");
            }

            string bucketName = "meldsep490";
            var uploadedFileUrls = new List<string>();
            foreach (var file in files)
            {
                if (file.Length == 0)
                {
                    _logger.LogWarning("Empty file uploaded: {FileName}", file.FileName);
                    continue; // Skip empty files
                }

                string fileKey = prefix + Guid.NewGuid() + Path.GetExtension(file.FileName);

                try
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await file.CopyToAsync(memoryStream);

                        var putRequest = new TransferUtilityUploadRequest
                        {
                            BucketName = bucketName,
                            Key = fileKey,
                            InputStream = memoryStream,
                            ContentType = file.ContentType
                        };

                        using (var transferUtility = new TransferUtility(_s3Client))
                        {
                            await transferUtility.UploadAsync(putRequest);
                        }
                        // Generate pre-signed URL
                        var getPresignedUrlRequest = new GetPreSignedUrlRequest
                        {
                            BucketName = bucketName,
                            Key = fileKey,
                            Expires = DateTime.UtcNow.AddYears(1) // Adjust expiration as needed
                        };
                        string presignedUrl = _s3Client.GetPreSignedURL(getPresignedUrlRequest);
                        uploadedFileUrls.Add(presignedUrl);
                        _logger.LogInformation("File uploaded to S3 successfully: {FileKey}", fileKey);
                    }
                }
                catch (AmazonS3Exception ex)
                {
                    _logger.LogError(ex, "Error uploading file to S3: {FileKey}", fileKey);
                    return StatusCode(500, "Error uploading file to S3");
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Unexpected error uploading file to S3: {FileKey}", fileKey);
                    return StatusCode(500, "Unexpected error uploading file to S3");
                }
            }

            return Ok(new { fileUrls = uploadedFileUrls });
        }
        [HttpGet]
        public async Task<IActionResult> GetAllFilesFormS3(string? prefix)
        {
            string bucketName = "meldsep490";
            var request = new ListObjectsV2Request()
            {
                BucketName = bucketName,
                Prefix = prefix
            };
            var result = await _s3Client.ListObjectsV2Async(request);
            var s3Ojects = result.S3Objects.Select(s =>
            {
                var urlRequest = new GetPreSignedUrlRequest()
                {
                    BucketName = bucketName,
                    Key = s.Key,
                    Expires = DateTime.UtcNow.AddYears(1)
                };
                return new S3ObjectDTO()
                {
                    Name = s.Key.ToString(),
                    PresignedURL = _s3Client.GetPreSignedURL(urlRequest)
                };
            });
            return Ok(s3Ojects);
        }

        [HttpGet("preview")]
        public async Task<IActionResult> GetFilebyKey(string key)
        {
            string bucketName = "meldsep490";
            var s3Object =  await _s3Client.GetObjectAsync(bucketName, key);
            return File(s3Object.ResponseStream, s3Object.Headers.ContentType);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteFileS3(string key)
        {
            string bucketName = "meldsep490";
            await _s3Client.DeleteObjectAsync(bucketName, key);
            return NoContent();
        }
    }

}
