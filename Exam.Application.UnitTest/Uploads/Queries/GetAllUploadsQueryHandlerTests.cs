using AutoMapper;
using Exam.Application.Uploads.Queries.GetAllUploads;
using Exam.Application.Uploads.Queries.GetUploadById;
using Exam.Domain.Entities;
using Exam.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.UnitTests.Uploads.Queries
{
    public class GetAllUploadsQueryHandlerTests
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private GetAllUploadsQueryHandler _handler;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Upload, UploadDto>();
            });
            _mapper = config.CreateMapper();

            _handler = new GetAllUploadsQueryHandler(_context, _mapper);
        }

        [TearDown]
        public void Teardown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task Handle_ShouldReturnUploadList()
        {
            var uploads = new List<Upload>
            {
                new() { Id = 1, Title = "Title1", Description = "Description1", Categories = "Category1" },
                new() { Id = 2, Title = "Title2", Description = "Description2", Categories = "Category2" }
            };

            _context.Uploads.AddRange(uploads);
            await _context.SaveChangesAsync();

            var query = new GetAllUploadsQuery();

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.That(result.List.Count, Is.EqualTo(2));
            Assert.That(result.Total, Is.EqualTo(2));
        }
    }
}
