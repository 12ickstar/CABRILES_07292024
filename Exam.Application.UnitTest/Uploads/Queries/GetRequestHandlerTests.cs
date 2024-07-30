using AutoMapper;
using Exam.Application.Common.Exceptions;
using Exam.Application.Uploads.Queries.GetUploadById;
using Exam.Domain.Entities;
using Exam.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Exam.Application.UnitTests.Uploads.Queries
{
    public class GetRequestHandlerTests
    {
        private ApplicationDbContext _context;
        private IMapper _mapper;
        private GetRequestHandler _handler;

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

            _handler = new GetRequestHandler(_context, _mapper);
        }

        [TearDown]
        public void Teardown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task Handle_ShouldReturnUploadDto_WhenUploadExists()
        {
            var upload = new Upload { Id = 1, Title = "Title1", Description = "Description1", Categories = "Category1" };
            _context.Uploads.Add(upload);
            await _context.SaveChangesAsync();

            var query = new GetUploadByIdQuery { Id = 1 };

            var result = await _handler.Handle(query, CancellationToken.None);

            Assert.NotNull(result);
            Assert.That(result.Id, Is.EqualTo(1));
            Assert.That(result.Title, Is.EqualTo("Title1"));
            Assert.That(result.Description, Is.EqualTo("Description1"));
            Assert.That(result.Categories, Is.EqualTo("Category1"));
        }

        [Test]
        public void Handle_ShouldThrowEntityNotFoundException_WhenUploadDoesNotExist()
        {
            var query = new GetUploadByIdQuery { Id = 999 };

            Assert.ThrowsAsync<EntityNotFoundException>(() => _handler.Handle(query, CancellationToken.None));
        }
    }
}
