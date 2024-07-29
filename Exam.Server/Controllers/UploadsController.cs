using Exam.Application.Uploads.Commands.UploadVideo;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Server.Controllers
{
    public class UploadsController : ApiControllerBase
    {
        private readonly IWebHostEnvironment _environment;

        public UploadsController(IWebHostEnvironment environment)
        {
            _environment = environment;
        }

        [HttpPost]
        public async Task<IActionResult> Upload([FromForm] UploadVideoCommand command)
        {
            var uploadsPath = Path.Combine(_environment.ContentRootPath, "uploads");

            if (!Directory.Exists(uploadsPath))
            {
                Directory.CreateDirectory(uploadsPath);
            }
            var fileExtension = Path.GetExtension(command.Video.FileName);
            var fileName = $"{Guid.NewGuid()}{fileExtension}";

            command.FilePath = Path.Combine(uploadsPath, fileName);
            await Mediator.Send(command);

            return Ok();
        }
    }
}
