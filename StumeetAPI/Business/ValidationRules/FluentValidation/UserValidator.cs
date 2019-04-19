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

            //@ işareti olacak ve @ işaretinden sonra .edu içerecek regex yazılacak.
            RuleFor(u => u.Email).NotEmpty().Must(email => email.Contains(".edu"));
            RuleFor(u => u.PasswordHash).NotEmpty();
            RuleFor(u => u.PasswordSalt).NotEmpty();
            RuleFor(u => u.CreationDate).NotEmpty();
            RuleFor(u => u.IsDeleted).NotEmpty();
        }
    }
}
