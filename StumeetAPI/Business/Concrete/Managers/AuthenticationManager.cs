using Microsoft.AspNetCore.Http;
using StumeetAPI.Business.Abstract;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.DTOs;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Concrete.Managers
{
    public class AuthenticationManager : IAuthenticationService
    {
        private IAuthenticationDal _authenticationDal;
        private IUserDal _userManager;

        public AuthenticationManager(IAuthenticationDal authenticationDal, IUserDal userManager)
        {
            _authenticationDal = authenticationDal;
            _userManager = userManager;
        }

        public async Task<Authentication> Add(Authentication authentication)
        {
            //ValidatorTool.Validate(new UserValidator(), authentication);
            return await _authenticationDal.Add(authentication);
        }

        public string GetPotantialUsername(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            if (string.IsNullOrEmpty(token) || !tokenHandler.CanReadToken(token))
            {
                return null;
            }
            return tokenHandler.ReadJwtToken(token).Claims.ToList()[1].Value;
        }

        public async Task<CustomResponse> CheckUser(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            string potantialUserName = GetPotantialUsername(token);
            if (string.IsNullOrEmpty(potantialUserName))
            {
                return new CustomResponse
                {
                    StatusCode = 401,
                    ResponseText = "Potantial username not found in token"
                };
            }

            User potatialUser = await _userManager.Get(u => u.Email == potantialUserName && u.IsDeleted != true);
            if (potatialUser == null)
            {
                return new CustomResponse
                {
                    StatusCode = 401,
                    ResponseText = "Potantial user not found"
                };
            }
            return new CustomResponse
            {
                StatusCode = 200,
                ResponseText = "Success",
                Data = potatialUser
            };
        }

        public async Task<Authentication> GetByCondition(Expression<Func<Authentication, bool>> filter = null)
        {
            return await _authenticationDal.Get(filter);
        }

        public async Task<Authentication> GetByID(int id)
        {
            return await _authenticationDal.Get(u => u.Id == id);
        }

        public async Task<Authentication> Update(Authentication authenticationDal)
        {
            //ValidatorTool.Validate(new UserValidator(), asset);
            return await _authenticationDal.Update(authenticationDal);
        }

        public async Task<List<Authentication>> GetAll(Expression<Func<Authentication, bool>> filter = null)
        {
            return await _authenticationDal.GetList(filter);
        }
    }
}
