using FluentValidation;
using Microsoft.AspNetCore.Http;
using SoftServeCinema.Core.DTOs.Movies;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.Core.Services;

namespace SoftServeCinema.Core.Validators
{
    public class MovieFormDTOValidator : AbstractValidator<MovieFormDTO>
    {
        private readonly IMovieService _movieService;

        public MovieFormDTOValidator(IMovieService movieService) 
        {
            _movieService = movieService;

            RuleSet("Create", () =>
            {
                RuleFor(m => m.ImageFile)
                .NotNull()
                .Must(IsImage).WithMessage("Invalid image format, valid formats (.jpg, .jped, .png, .webp)");

                RuleFor(m => m.TrailerUrl)
                    .NotEmpty()
                    .Must(IsUrl).WithMessage("Invalid trailer URL");

                RuleFor(m => m.Title)
                    .NotEmpty()
                    .Length(2, 255)
                    .Must(title => Task.Run(async () => await _movieService.IsTitleUniqueAsync(title == null ? "" : title)).Result)
                    .WithMessage("This movie title already exists"); ;

                RuleFor(m => m.Desc)
                    .NotEmpty();

                RuleFor(m => m.GraduationYear)
                    .NotEmpty()
                    .GreaterThanOrEqualTo(1900).WithMessage("The graduation year must be later than 1900")
                    .LessThanOrEqualTo(2100).WithMessage("The graduation year must be later than 2100");

                RuleFor(m => m.Duration)
                    .NotEmpty()
                    .GreaterThan(0).WithMessage("Invalid duration, must be greater than 0")
                    .LessThan(1000).WithMessage("Invalid duration, must be less than 1000");

                RuleFor(m => m.StartRentalDate)
                    .NotEmpty()
                    .Must(IsValidDate).WithMessage("Invalid rental start date, must be no more or no less than 10 years from the current one");

                RuleFor(m => m.EndRentalDate)
                    .NotEmpty()
                    .Must(IsValidDate).WithMessage("Invalid rental end date, must be no more or no less than 10 years from the current one")
                    .GreaterThan(m => m.StartRentalDate).WithMessage("Invalid rental end date, must be later than the start date");

                RuleFor(m => m.SelectedGenres)
                    .NotEmpty().WithMessage("Invalid genres, must be at least one genre");
            });

            RuleSet("Edit", () =>
            {
                RuleFor(m => m.ImageFile)
                    .Must(IsImage)
                    .When(m => m.ImageFile != null)
                    .WithMessage("Invalid image format, valid formats (.jpg, .jped, .png, .webp)");

                RuleFor(m => m.TrailerUrl)
                    .NotEmpty()
                    .Must(IsUrl).WithMessage("Invalid trailer URL");

                RuleFor(m => m.Title)
                    .NotEmpty()
                    .Length(2, 255);

                RuleFor(m => m)
                   .Must(m => Task.Run(async () => await _movieService.IsTitleUniqueWithoutIdAsync(m.Id, m.Title)).Result)
                   .WithMessage("This movie title already exists")
                   .WithName("Title");

                RuleFor(m => m.Desc)
                    .NotEmpty();

                RuleFor(m => m.GraduationYear)
                    .NotEmpty()
                    .GreaterThanOrEqualTo(1900).WithMessage("The graduation year must be later than 1900")
                    .LessThanOrEqualTo(2100).WithMessage("The graduation year must be later than 2100");

                RuleFor(m => m.Duration)
                    .NotEmpty()
                    .GreaterThan(0).WithMessage("Invalid duration, must be greater than 0")
                    .LessThan(1000).WithMessage("Invalid duration, must be less than 1000");

                RuleFor(m => m.StartRentalDate)
                    .NotEmpty()
                    .Must(IsValidDate).WithMessage("Invalid rental start date, must be no more or no less than 10 years from the current one");

                RuleFor(m => m.EndRentalDate)
                    .NotEmpty()
                    .Must(IsValidDate).WithMessage("Invalid rental end date, must be no more or no less than 10 years from the current one")
                    .GreaterThan(m => m.StartRentalDate).WithMessage("Invalid rental end date, must be later than the start date");

                RuleFor(m => m.SelectedGenres)
                    .NotEmpty().WithMessage("Invalid genres, must be at least one genre");
            });
        }
        private static bool IsUrl(string? link)
        {
            if (string.IsNullOrWhiteSpace(link))
            {
                return false;
            }

            Uri? outUri;
            return Uri.TryCreate(link, UriKind.Absolute, out outUri)
                   && (outUri.Scheme == Uri.UriSchemeHttp || outUri.Scheme == Uri.UriSchemeHttps);
        }

        private bool IsImage(IFormFile? image)
        {
            if (image == null)
            {
                return false;
            }

            string[] allowedExtensions = { ".jpg", ".jpeg", ".png", ".webp" };

            string extension = Path.GetExtension(image.FileName);
            if (string.IsNullOrEmpty(extension) || !allowedExtensions.Contains(extension.ToLower()))
            { 
                return false;
            }

            if (!image.ContentType.Contains("image"))
            { 
                return false;
            }

            return true;
        }

        private bool IsValidDate(DateTime date)
        {
            return date >= DateTime.Today.AddYears(-10) && date <= DateTime.Today.AddYears(10);
        }
    }
}
