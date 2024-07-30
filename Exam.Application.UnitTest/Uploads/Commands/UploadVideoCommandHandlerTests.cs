using Exam.Application.Uploads.Commands.UploadVideo;
using Exam.Infrastructure.Persistence;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace Exam.Application.UnitTest.Uploads.Commands
{
    public class UploadVideoCommandHandlerTests
    {
        private Mock<IFormFile> _formFileMock;
        private ApplicationDbContext _context;
        private UploadVideoCommandHandler _handler;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationDbContext(options);
            _handler = new UploadVideoCommandHandler(_context);
            _formFileMock = new Mock<IFormFile>();
        }

        [TearDown]
        public void Teardown()
        {
            _context.Database.EnsureDeleted();
            _context.Dispose();
        }

        [Test]
        public async Task Handle_ShouldSaveUploadAndReturnId()
        {
            var memoryStream = new MemoryStream();
            var writer = new StreamWriter(memoryStream);
            writer.Write("Test file content");
            writer.Flush();
            memoryStream.Position = 0;

            _formFileMock.Setup(f => f.CopyToAsync(It.IsAny<Stream>(), It.IsAny<CancellationToken>()))
                         .Returns((Stream stream, CancellationToken cancellationToken) => memoryStream.CopyToAsync(stream, cancellationToken));

            _formFileMock.Setup(f => f.FileName).Returns("test_video.mp4");

            var command = new UploadVideoCommand
            {
                Title = "Test Title",
                Description = "Test Description",
                Categories = "Test Categories",
                Video = _formFileMock.Object,
                FilePath = Path.GetTempFileName()
            };

            var result = await _handler.Handle(command, CancellationToken.None);

            var upload = await _context.Uploads.FindAsync(result);

            Assert.NotNull(upload);
            Assert.That(upload.Id, Is.GreaterThan(0));
            Assert.That(upload.Title, Is.EqualTo("Test Title"));
            Assert.That(upload.Description, Is.EqualTo("Test Description"));
            Assert.That(upload.Categories, Is.EqualTo("Test Categories"));
            Assert.That(upload.VideoFilePath, Is.EqualTo($"uploads/{Path.GetFileName(command.FilePath)}"));
        }
    }
}
