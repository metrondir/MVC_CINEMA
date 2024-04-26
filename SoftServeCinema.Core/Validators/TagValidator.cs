using FluentValidation;
using SoftServeCinema.Core.DTOs.Tags;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Validators
{
    public class TagValidator : AbstractValidator<TagDTO>
    {
        private readonly ITagService _tagService;

        public TagValidator(ITagService tagService)
        {
            _tagService = tagService;

            RuleSet("Create", () =>
            {
                RuleFor(t => t.Name)
                .NotNull().WithMessage("Це поле обов'язкове")
                .NotEmpty().WithMessage("Це поле обов'язкове")
                .Length(1, 100).WithMessage("Назва повинна мати від 1 до 100 символів")
                .Must(name => Task.Run(async () => await _tagService.IsNameUniqueAsync(name == null ? "" : name)).Result)
                .WithMessage("Ця назва тегу вже існує");
            });

            RuleSet("Edit", () =>
            {
                RuleFor(t => t.Name)
                .NotNull().WithMessage("Це поле обов'язкове")
                .NotEmpty().WithMessage("Це поле обов'язкове")
                .Length(1, 100).WithMessage("Назва повинна мати від 1 до 100 символів");

                RuleFor(t => t)
                    .Must(t => Task.Run(async () => await _tagService.IsNameUniqueWithoutIdAsync(t.Id, t.Name)).Result)
                    .WithMessage("Ця назва тегу вже існує")
                    .WithName("Name");
            });
        }
    }
}
