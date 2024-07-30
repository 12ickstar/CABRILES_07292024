using AutoMapper;
using AutoMapper.QueryableExtensions;
using Exam.Application.Common.Interfaces;
using Exam.Application.Uploads.Queries.GetUploadById;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Uploads.Queries.GetAllUploads
{
    public class GetAllUploadsQueryHandler : IRequestHandler<GetAllUploadsQuery, UploadList>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllUploadsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<UploadList> Handle(GetAllUploadsQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Uploads
                .ProjectTo<UploadDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new UploadList
            {
                List = list,
                Total = list.Count
            };
        }
    }
}
