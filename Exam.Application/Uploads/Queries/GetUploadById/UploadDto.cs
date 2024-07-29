using Exam.Application.Common.Mappings;
using Exam.Domain.Entities;

namespace Exam.Application.Uploads.Queries.GetUploadById
{
    public class UploadDto : IMapFrom<Upload>
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        public string VideoFilePath { get; set; } = string.Empty;
    }
}
