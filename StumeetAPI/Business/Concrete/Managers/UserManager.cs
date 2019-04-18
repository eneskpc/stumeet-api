using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StumeetAPI.Business.Abstract;
using StumeetAPI.Business.ValidationRules.FluentValidation;
using StumeetAPI.Core.CrossCuttingConcerns.Validation.FluentValidation;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.DTOs;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private IUserDal _userDal;
        private IConfiguration _configuration;
        private IMailService _mailManager;

        public UserManager(IUserDal userDal, IConfiguration configuration, IMailService mailManager)
        {
            _userDal = userDal;
            _configuration = configuration;
            _mailManager = mailManager;
        }

        public async Task<User> Add(User user)
        {
            ValidatorTool.Validate(new UserValidator(), user);
            return await _userDal.Add(user);
        }

        public string CreateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Token").Value);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]{
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Email)
                }),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<List<User>> GetAll()
        {
            return await _userDal.GetList();
        }

        public async Task<User> GetByCondition(Expression<Func<User, bool>> filter = null)
        {
            return await _userDal.Get(filter);
        }

        public async Task<User> GetByID(int id)
        {
            return await _userDal.Get(u => u.Id == id);
        }

        public async Task<User> Login(UserForLogin userForLogin)
        {
            var user = await _userDal.Get(x => x.Email == userForLogin.UserName);
            if (user == null)
            {
                return null;
            }

            if (!VerifyPasswordHash(userForLogin.Password, user.PasswordHash, user.PasswordSalt))
            {
                return null;
            }

            return user;
        }

        private bool VerifyPasswordHash(string password, byte[] userPasswordHash, byte[] userPasswordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(userPasswordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != userPasswordHash[i])
                    {
                        return false;
                    }
                }

                return true;
            }
        }

        public async Task<User> Update(User user)
        {
            ValidatorTool.Validate(new UserValidator(), user);
            return await _userDal.Update(user);
        }

        public async Task<User> Register(UserForRegister userForRegister)
        {
            if (await _userDal.Get(u => u.Email == userForRegister.Email) != null)
            {
                return null;
            }

            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(userForRegister.Password, out passwordHash, out passwordSalt);

            var userToCreate = new User
            {
                Name = userForRegister.Name,
                Surname = userForRegister.Surname,
                BirthDate = userForRegister.BirthDate,
                Email = userForRegister.Email,
                PhoneNumber = userForRegister.PhoneNumber,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };

            userToCreate = await _userDal.Add(userToCreate);
            if (userToCreate == null)
            {
                return null;
            }

            await _mailManager.SendByTemplate(userToCreate.Email,
                "Stumeet.com'a Hoşgeldiniz", @"\Templates\welcome_message.html", new MailTemplateItem[] {
                    new MailTemplateItem
                    {
                        Key = "Name",
                        Value = userToCreate.Name
                    }
                });

            return userToCreate;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}
