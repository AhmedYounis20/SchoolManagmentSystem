using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentAffairWeb.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class FileController : ControllerBase
    {
        IWebHostEnvironment environment;
        public FileController(IWebHostEnvironment _environment) => environment = _environment;

        [HttpGet]
        public IActionResult DownloadFile()
        {
            string filePath = Path.Combine(environment.ContentRootPath, "Files", "Book1.csv");
            MemoryStream ms = new MemoryStream();
            using (FileStream file = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                file.CopyTo(ms);

            return File(ms, "text/csv");
        }

    }


}
