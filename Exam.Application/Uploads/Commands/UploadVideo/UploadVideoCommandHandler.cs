using Exam.Application.Common.Interfaces;
using Exam.Domain.Entities;
using MediatR;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Exam.Application.Uploads.Commands.UploadVideo
{
    public class UploadVideoCommandHandler : IRequestHandler<UploadVideoCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UploadVideoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
        {
            using (var stream = new FileStream(request.FilePath, FileMode.Create))
            {
                await request.Video.CopyToAsync(stream, cancellationToken);
            }

            var upload = new Upload
            {
                Title = request.Title,
                Description = request.Description,
                Categories = request.Categories,
                VideoFilePath = $"uploads/{Path.GetFileName(request.FilePath)}"
            };

            await _context.Uploads.AddAsync(upload, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return upload.Id;
        }
    }
}
