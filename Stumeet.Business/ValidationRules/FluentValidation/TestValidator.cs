using FluentValidation;
using Stumeet.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Stumeet.Business.ValidationRules.FluentValidation
{
    public class TestValidator : AbstractValidator<Test>
    {
        public TestValidator()
        {
            RuleFor(t => t.ID).NotEmpty();
            RuleFor(t => t.Name).NotEmpty().Length(3,25);
        }
    }
}
