using Exam.Application.Common.Exceptions;
using Exam.Application.Uploads.Commands.UploadVideo;
using Exam.Application.Uploads.Queries.GetUploadById;
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
            var response = await Mediator.Send(command);

            return Ok(new
            {
                Id = response
            });
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var result = await Mediator.Send(new GetUploadByIdQuery { Id = id });

                return Ok(result);
            }
            catch (EntityNotFoundException)
            {

                return NotFound(id);
            }
            catch (Exception)
            {
                return BadRequest(500);
            }
        }
    }
}
