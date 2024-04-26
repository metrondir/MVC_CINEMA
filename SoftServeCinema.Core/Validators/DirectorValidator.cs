using FluentValidation;
using SoftServeCinema.Core.DTOs.Directors;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Validators
{
    public class DirectorValidator : AbstractValidator<DirectorDTO>
    {
        private readonly IDirectorService _directorService;

        public DirectorValidator(IDirectorService directorService)
        {
            _directorService = directorService;

            RuleSet("Create", () =>
            {
                RuleFor(d => d.Name)
                .NotNull().WithMessage("Це поле обов'язкове")
                .NotEmpty().WithMessage("Це поле обов'язкове")
                .Length(1, 100).WithMessage("Ім'я Прізвище повинно мати від 1 до 100 символів")
                .Must(name => Task.Run(async () => await _directorService.IsNameUniqueAsync(name == null ? "" : name)).Result)
                .WithMessage("Цей режисер вже існує");
            });

            RuleSet("Edit", () =>
            {
                RuleFor(d => d.Name)
                .NotNull().WithMessage("Це поле обов'язкове")
                .NotEmpty().WithMessage("Це поле обов'язкове")
                .Length(1, 100).WithMessage("Ім'я Прізвище повинно мати від 1 до 100 символів");

                RuleFor(d => d)
                    .Must(d => Task.Run(async () => await _directorService.IsNameUniqueWithoutIdAsync(d.Id, d.Name)).Result)
                    .WithMessage("Цей режисер вже існує")
                    .WithName("Name");
            });
        }
    }
}
