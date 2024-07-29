namespace Exam.Domain.Entities
{
    public class Upload
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Categories { get; set; } = string.Empty;
        public string VideoFilePath { get; set; } = string.Empty;
    }
}
