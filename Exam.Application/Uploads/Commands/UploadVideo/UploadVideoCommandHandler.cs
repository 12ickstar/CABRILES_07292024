using Exam.Application.Common.Interfaces;
using Exam.Domain.Entities;
using MediatR;

namespace Exam.Application.Uploads.Commands.UploadVideo
{
    public class UploadVideoCommandHandler : IRequestHandler<UploadVideoCommand>
    {
        private readonly IApplicationDbContext _context;

        public UploadVideoCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UploadVideoCommand request, CancellationToken cancellationToken)
        {
            await _context.Uploads.AddAsync(new Upload
            {
                Title = request.Title,
                Description = request.Description,
                Categories = request.Categories,
                VideoFilePath = request.VideoFilePath
            });

            await _context.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
