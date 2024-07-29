using MediatR;

namespace Exam.Application.Uploads.Commands.UploadVideo
{
    public class UploadVideoCommand : IRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        public string VideoFilePath { get; set; } = string.Empty;
    }
}
