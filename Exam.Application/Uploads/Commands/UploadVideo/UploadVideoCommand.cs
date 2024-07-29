using MediatR;
using Microsoft.AspNetCore.Http;

namespace Exam.Application.Uploads.Commands.UploadVideo
{
    public class UploadVideoCommand : IRequest<int>
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        public IFormFile Video { get; set; } = null!;
        public string FilePath { get; set; } = string.Empty;
    }
}
