using Entities.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.ValidationRules.FluentValidation
{
    public class ColorValidator: AbstractValidator<Color>
    {
        public ColorValidator()
        {
            RuleFor(c => c.ColorName).NotEmpty();
            RuleFor(c => c.ColorId).NotEmpty();
            RuleFor(c => c.ColorName).Must(StartWithX).WithMessage("Die Farbe muss mit dem Buchstaben „X“ beginnen.");

        }

        private bool StartWithX(string arg)
        {
            return arg.StartsWith("X");
        }
    }
}
