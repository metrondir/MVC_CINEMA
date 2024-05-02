using FluentValidation;
using SoftServeCinema.Core.DTOs.Users;
using SoftServeCinema.Core.Interfaces.Services;
using SoftServeCinema.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace SoftServeCinema.Core.Validators
{
    public class UserValidator : AbstractValidator<UserRegisterDTO>
    {
        private readonly IUserService _userService;

        public UserValidator(IUserService userService)
        {
            _userService = userService;

            RuleSet("Create", () =>
            {
                RuleFor(u => u.Email)
        .NotEmpty().WithMessage("Email is required")
        .NotNull().WithMessage("Email is required")
        .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible).WithMessage("Email is not valid");

                RuleFor(u => u.FirstName)
                    .NotEmpty().WithMessage("First Name is required")
                    .NotNull().WithMessage("Last Name is required");

                RuleFor(u => u.LastName)
                     .NotEmpty().WithMessage("Last Name is required")
                     .NotNull().WithMessage("Last Name is required");



                RuleFor(u => u.Password)
                    .NotEmpty().WithMessage("Password is required")
                    .Length(8, 20).WithMessage("Password must be between 8 and 20 characters")
                    .NotNull().WithMessage("Password is required")
                    .Matches(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).").WithMessage("Password must contain at least one uppercase letter, one lowercase letter, and one number");
            });



        }
    }
}
