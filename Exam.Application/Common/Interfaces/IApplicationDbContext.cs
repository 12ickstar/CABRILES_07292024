using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Upload> Uploads { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
