using AutoMapper;
using AutoMapper.QueryableExtensions;
using Exam.Application.Common.Exceptions;
using Exam.Application.Common.Interfaces;
using Exam.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Uploads.Queries.GetUploadById
{
    public class GetUploadByIdQuery : IRequest<UploadDto>
    {
        public int Id { get; set; }
    }

    public class GetRequestHandler : IRequestHandler<GetUploadByIdQuery, UploadDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetRequestHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UploadDto> Handle(GetUploadByIdQuery request, CancellationToken cancellationToken)
        {
            var upload = await _context.Uploads
                .Where(x => x.Id == request.Id)
                .ProjectTo<UploadDto>(_mapper.ConfigurationProvider)
                .FirstOrDefaultAsync(cancellationToken);

            _ = upload ?? throw new EntityNotFoundException(typeof(Upload), request.Id);

            return upload;
        }
    }
}
