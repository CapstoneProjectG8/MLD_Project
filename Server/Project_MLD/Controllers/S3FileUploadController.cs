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
using System.Collections.Concurrent;
using Project_MLD.Models;
using Microsoft.EntityFrameworkCore;
namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3FileUploadController : ControllerBase
    {
        private readonly IAmazonS3 _s3Client;
        private readonly ILogger<S3FileUploadController> _logger;
        private static List<S3FileMetadatum> _fileMetadataStore = new List<S3FileMetadatum>();
        private readonly MldDatabaseContext _context;
        public S3FileUploadController(IAmazonS3 s3Client, ILogger<S3FileUploadController> logger, MldDatabaseContext context)
        {
            _s3Client = s3Client;
            _logger = logger;
            _context = context;
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
                        string presignedUrl = _s3Client.GetPreSignedURL(new GetPreSignedUrlRequest
                        {
                            BucketName = bucketName,
                            Key = fileKey,
                            Expires = DateTime.UtcNow.AddYears(1) // Adjust as needed
                        });

                        // Add URL to corresponding Document and save to database
                        switch (prefix)
                        {
                            case "doc1/":
                                var document1 = new Document1();
                                document1.LinkFile = presignedUrl;
                                _context.Document1s.Add(document1);
                                await _context.SaveChangesAsync();
                                uploadedFileUrls.Add(presignedUrl);
                                break;
                            case "doc2/":
                                var document2 = new Document2();
                                document2.LinkFile = presignedUrl;
                                _context.Document2s.Add(document2);
                                await _context.SaveChangesAsync();
                                uploadedFileUrls.Add(presignedUrl);
                                break;
                            case "doc3/":
                                var document3 = new Document3();
                                document3.LinkFile = presignedUrl;
                                _context.Document3s.Add(document3);
                                await _context.SaveChangesAsync();
                                uploadedFileUrls.Add(presignedUrl);
                                break;
                            case "doc4/":
                                var document4 = new Document4();
                                document4.LinkFile = presignedUrl;
                                _context.Document4s.Add(document4);
                                await _context.SaveChangesAsync();
                                uploadedFileUrls.Add(presignedUrl);
                                break;
                            case "doc5/":
                                var document5 = new Document5();
                                document5.LinkFile = presignedUrl;
                                _context.Document5s.Add(document5);
                                await _context.SaveChangesAsync();
                                uploadedFileUrls.Add(presignedUrl);
                                break;
                            case "scorm/":
                                var scorm = new Scorm();
                                scorm.LinkFile = presignedUrl;
                                _context.Scorms.Add(scorm);
                                await _context.SaveChangesAsync();
                                uploadedFileUrls.Add(presignedUrl);
                                break;
                            default:
                                return BadRequest("Invalid prefix");
                        }

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
                var storedMetadata = _context.S3FileMetadata.FirstOrDefault(metadata => metadata.FileKey == s.Key);
                if (storedMetadata != null)
                {
                    return new S3ObjectDTO()
                    {
                        Name = s.Key.ToString(),
                        PresignedURL = storedMetadata.PresignedUrl
                    };
                }
                else
                {
                    // If metadata not found, generate new pre-signed URL
                    var urlRequest = new GetPreSignedUrlRequest()
                    {
                        BucketName = bucketName,
                        Key = s.Key,
                        Expires = DateTime.UtcNow.AddYears(1)
                    };
                    var newPresignedUrl = _s3Client.GetPreSignedURL(urlRequest);

                    // Store new metadata in database
                    var newMetadata = new S3FileMetadatum
                    {
                        FileKey = s.Key,
                        PresignedUrl = newPresignedUrl,
                        ExpirationDatetime = DateTime.UtcNow.AddYears(1)
                    };
                    _context.S3FileMetadata.Add(newMetadata);
                    _context.SaveChanges();

                    return new S3ObjectDTO()
                    {
                        Name = s.Key.ToString(),
                        PresignedURL = newPresignedUrl
                    };
                }
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
