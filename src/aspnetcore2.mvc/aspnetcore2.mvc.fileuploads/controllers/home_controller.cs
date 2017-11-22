using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.IO;
using Aspnet.Core.Controllers.FileUpload.Filters;

namespace Aspnet.Core.Controllers.FileUpload.Controllers
{
    public class HomeController : Controller
    {
        [GenerateAntiforgeryTokenCookieForAjax]
        public IActionResult Index() => View();

        [HttpPost("UploadFiles")]
        public async Task<IActionResult> Post(List<IFormFile> files)
        {
            string filePath = Path.GetTempFileName(); // full path to file in temp location
            long size = files.Sum(s => s.Length);

            foreach (var file in files)
                if (file.Length > 0)
                    using (var fs = new FileStream(filePath, FileMode.Create))
                        await file.CopyToAsync(fs);

            // Process uploaded files.
            // Don't rely on or trust the filename property without validation.
            return Ok(new { Count = files.Count, Size = size, FilePath = filePath });
        }
    }
}