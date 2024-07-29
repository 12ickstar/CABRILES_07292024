using Exam.Application.Uploads.Commands.UploadVideo;
using Microsoft.AspNetCore.Mvc;

namespace Exam.Server.Controllers
{
    public class UploadsController : ApiControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Test(UploadVideoCommand command)
        {
            await Mediator.Send(command);

            return Ok();
        }
    }
}
