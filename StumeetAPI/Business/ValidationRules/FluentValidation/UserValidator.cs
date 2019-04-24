using FluentValidation;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StumeetAPI.Business.ValidationRules.FluentValidation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator()
        {
            RuleFor(u => u.Name).NotEmpty().Length(2, 50);
            RuleFor(u => u.Surname).NotEmpty().Length(2, 50);
            RuleFor(u => u.BirthDate).NotEmpty().LessThan(DateTime.Now.AddYears(-16));
            RuleFor(u => u.Email).EmailAddress().Matches(@"((\w+\.)*\w+)@(\w+\.)+(edu)(\.\w+)*");
            RuleFor(u => u.PasswordHash).NotEmpty();
            RuleFor(u => u.PasswordSalt).NotEmpty();
            RuleFor(u => u.CreationDate).NotEmpty();
            RuleFor(u => u.PhoneNumber).Must(phoneNumber => phoneNumber.Length == 10);
        }
    }
}
