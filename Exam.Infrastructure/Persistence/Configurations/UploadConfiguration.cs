using Exam.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Exam.Infrastructure.Persistence.Configurations
{
    public class UploadConfiguration : IEntityTypeConfiguration<Upload>
    {
        public void Configure(EntityTypeBuilder<Upload> builder)
        {
            builder.ToTable("Uploads");

            builder.HasKey(u => u.Id);

            builder.Property(u => u.Id)
                .IsRequired();

            builder.Property(u => u.Title)
                .IsRequired()
                .HasMaxLength(200);

            builder.Property(u => u.Description)
                .IsRequired()
                .HasMaxLength(160);

            builder.Property(u => u.Categories)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(u => u.VideoFilePath)
                .IsRequired()
                .HasMaxLength(500);

            builder.HasIndex(u => u.Categories)
                .IsUnique();
        }
    }
}
