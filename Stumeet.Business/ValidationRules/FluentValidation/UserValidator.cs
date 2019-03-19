﻿using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;
using Stumeet.Entities.Concrete;

namespace Stumeet.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().Length(2, 50);
            RuleFor(u => u.Surname).NotEmpty().Length(2, 50);
            RuleFor(u => u.BirthDate).NotEmpty().LessThan(DateTime.Now.AddYears(-16));
            RuleFor(u => u.Email).NotEmpty().Must(email => email.EndsWith("edu.tr"));
            RuleFor(u => u.PasswordHash).NotEmpty();
            RuleFor(u => u.PasswordSalt).NotEmpty();
            RuleFor(u => u.CreationDate).NotEmpty();
            RuleFor(u => u.IsDeleted).NotEmpty();
        }
    }
}
