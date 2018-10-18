using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using ProductAPI.Domain.Entities;

namespace ProductAPI.Service.Validators
{
    public class BrandValidator : AbstractValidator<Brand>
    {
        public BrandValidator()
        {

            RuleFor(c => c)
                    .NotNull()
                    .OnAnyFailure(x =>
                    {
                        throw new ArgumentNullException("Can't found the object.");
                    });

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("Is necessary to inform the Name.")
                .MaximumLength(50).WithMessage("Name must be no longer than 50 characters.")
                .NotNull().WithMessage("Is necessary to inform the Name.");
        }
    }
}
