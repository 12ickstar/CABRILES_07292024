using Exam.Application.Uploads.Queries.GetUploadById;

namespace Exam.Application.Uploads.Queries.GetAllUploads
{
    public class UploadList
    {
        public IEnumerable<UploadDto> List { get; set; } = Enumerable.Empty<UploadDto>();
        public int Total { get; set; }
    }
}
