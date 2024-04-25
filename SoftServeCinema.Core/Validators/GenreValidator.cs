using FluentValidation;
using SoftServeCinema.Core.DTOs.Genres;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Validators
{
    public class GenreValidator : AbstractValidator<GenreDTO>
    {
        private readonly IGenreService _genreService;

        public GenreValidator(IGenreService genreService)
        {
            _genreService = genreService;

            RuleSet("Create", () =>
            {
                RuleFor(g => g.Name)
                .NotNull().WithMessage("Це поле обов'язкове")
                .NotEmpty().WithMessage("Це поле обов'язкове")
                .Length(1, 50).WithMessage("Назва повинна мати від 1 до 50 символів")
                .Must(name => Task.Run(async () => await _genreService.IsNameUniqueAsync(name == null ? "" : name)).Result)
                .WithMessage("Ця назва жанру вже існує");
            });

            RuleSet("Edit", () =>
            {
                RuleFor(g => g.Name)
                .NotNull().WithMessage("Це поле обов'язкове")
                .NotEmpty().WithMessage("Це поле обов'язкове")
                .Length(1, 50).WithMessage("Назва повинна мати від 1 до 50 символів");

                RuleFor(g => g)
                    .Must(g => Task.Run(async () => await _genreService.IsNameUniqueWithoutIdAsync(g.Id, g.Name)).Result)
                    .WithMessage("Ця назва жанру вже існує")
                    .WithName("Name");
            });
        }
    }
}
