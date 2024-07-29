using FluentValidation;

namespace Exam.Application.Uploads.Commands.UploadVideo
{
    public class UploadVideoCommandValidator : AbstractValidator<UploadVideoCommand>
    {
        public UploadVideoCommandValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(200).WithMessage("Title must not exceed 200 characters.");

            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description is required.")
                .MaximumLength(1000).WithMessage("Description must not exceed 1000 characters.");

            RuleFor(x => x.Categories)
                .NotEmpty().WithMessage("Categories are required.")
                .MaximumLength(100).WithMessage("Categories must not exceed 100 characters.");

            RuleFor(x => x.FilePath)
                .NotEmpty().WithMessage("File path is required.")
                .MaximumLength(500).WithMessage("File path must not exceed 500 characters.");
        }
    }
}
