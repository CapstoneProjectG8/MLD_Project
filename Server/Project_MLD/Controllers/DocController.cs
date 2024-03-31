using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Project_MLD.Models;
using Project_MLD.Service.Interface;
using System.Diagnostics;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Project_MLD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocController : ControllerBase
    {
        private readonly MldDatabaseContext _context;
        private readonly IDocRepository _repository;
        public DocController(MldDatabaseContext context, IDocRepository repository)
        {
            _repository = repository;
            _context = context;
        }
        
        private async Task<IActionResult> DownloadPDF(string filename)
        {
            var DownloadfilePath = Path.Combine(Directory.GetCurrentDirectory(), "GeneratedPDFfile", filename);
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(DownloadfilePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = await System.IO.File.ReadAllBytesAsync(DownloadfilePath);
            return File(bytes, contentType, Path.GetFileName(DownloadfilePath));
        }

        [HttpGet("GeneratePDFfromURL")]
        public async Task<IActionResult> GeneratePDFfromURL(string url)
        {
            var render = new ChromePdfRenderer();
            var pdf = render.RenderUrlAsPdf(url);

            string pdfFileName = DateTime.Now.Ticks.ToString() + ".pdf";

            pdf.SaveAs(Path.Combine(Directory.GetCurrentDirectory(), "GeneratedPDFfile", url));

            return await DownloadPDF(pdfFileName);
        }
    }
}
