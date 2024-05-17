using FluentValidation;
using SoftServeCinema.Core.DTOs.Sessions;
using SoftServeCinema.Core.Interfaces.Services;

namespace SoftServeCinema.Core.Validators
{
    public class SessionDTOValidator : AbstractValidator<SessionDTO>
    {
        private readonly ISessionService _sessionService;

        public SessionDTOValidator(ISessionService sessionService)
        {
            _sessionService = sessionService;

            RuleSet("Create", () =>
            {
                RuleFor(s => s.StartDate)
                    .NotEmpty().WithMessage("Start date is required")
                    .Must(IsValidDate).WithMessage("Invalid start date")
                    .Must(startDate => Task.Run(async () => await _sessionService.IsSessionUniqueAsync(startDate)).Result)
                    .WithMessage("This session time already exists");

                RuleFor(s => s.BasicPrice)
                    .GreaterThanOrEqualTo(0).WithMessage("Basic price must be non-negative");

                RuleFor(s => s.VipPrice)
                    .GreaterThanOrEqualTo(0).WithMessage("VIP price must be non-negative");


            });

            RuleSet("Edit", () =>
            {
                RuleFor(s => s.StartDate)
                    .NotEmpty().WithMessage("Start date is required");

                RuleFor(s => s)
                    .Must(s => Task.Run(async () => await _sessionService.IsSessionUniqueWithoutIdAsync(s.Id,s.StartDate)).Result)
                    .WithMessage("This session time already exists")
                    .WithName("StartDate");

                RuleFor(s => s.BasicPrice)
                    .GreaterThanOrEqualTo(0).WithMessage("Basic price must be non-negative");

                RuleFor(s => s.VipPrice)
                    .GreaterThanOrEqualTo(0).WithMessage("VIP price must be non-negative");

             
            });
        }

        private bool IsValidDate(DateTime date)
        {
            return date >= DateTime.UtcNow;
        }
    }
}
