using Exam.Application.Common.Interfaces;
using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Exam.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Upload> Uploads => Set<Upload>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(builder);    
        }
    }
}
