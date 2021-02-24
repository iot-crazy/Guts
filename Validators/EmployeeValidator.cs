using FluentValidation;
using Interfaces.ViewModels;
using System;
using ViewModels;

namespace Validators
{
    public class EmployeeValidator : AbstractValidator<EmployeeViewModel>
    {

        public EmployeeValidator()
        {
            RuleFor(x => x.FirstName).NotEmpty().MinimumLength(5);
            RuleFor(x => x.LastName).NotEmpty();
           // RuleFor(x => x.DateOfBirth).NotEmpty().GreaterThan(new DateTime(1900, 1, 1)).LessThanOrEqualTo(new DateTime(2000,1,1)).WithMessage("must be before 1st jan 2000")
           //   ;

            //.LessThanOrEqualTo(DateTime.Now.AddYears(-18)).WithMessage("Employee must be over 18 years old");

            //.GreaterThan(DateTime.Now.AddYears(-100))
        }

    }
}
