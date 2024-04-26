using FluentValidation;
using SoftServeCinema.Core.DTOs.Actors;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Validators
{
    public class ActorValidator : AbstractValidator<ActorDTO>
    {
        private readonly IActorService _actorService;

        public ActorValidator(IActorService actorService)
        {
            _actorService = actorService;

            RuleSet("Create", () =>
            {
                RuleFor(a => a.Name)
                .NotNull().WithMessage("Це поле обов'язкове")
                .NotEmpty().WithMessage("Це поле обов'язкове")
                .Length(1, 100).WithMessage("Ім'я Прізвище повинно мати від 1 до 100 символів")
                .Must(name => Task.Run(async () => await _actorService.IsNameUniqueAsync(name == null ? "" : name)).Result)
                .WithMessage("Цей актор вже існує");
            });

            RuleSet("Edit", () =>
            {
                RuleFor(a => a.Name)
                .NotNull().WithMessage("Це поле обов'язкове")
                .NotEmpty().WithMessage("Це поле обов'язкове")
                .Length(1, 100).WithMessage("Ім'я Прізвище повинно мати від 1 до 100 символів");

                RuleFor(a => a)
                    .Must(a => Task.Run(async () => await _actorService.IsNameUniqueWithoutIdAsync(a.Id, a.Name)).Result)
                    .WithMessage("Цей актор вже існує")
                    .WithName("Name");
            });
        }
    }
}
