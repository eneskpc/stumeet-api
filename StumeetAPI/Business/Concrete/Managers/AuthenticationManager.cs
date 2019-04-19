using Microsoft.AspNetCore.Http;
using StumeetAPI.Business.Abstract;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Concrete.Managers
{
    public class AuthenticationManager : IAuthenticationService
    {
        private IAuthenticationDal _authenticationDal;

        public AuthenticationManager(IAuthenticationDal authenticationDal)
        {
            _authenticationDal = authenticationDal;
        }

        public async Task<Authentication> Add(Authentication authentication)
        {
            //ValidatorTool.Validate(new UserValidator(), authentication);
            return await _authenticationDal.Add(authentication);
        }

        public async Task<List<Authentication>> GetAll()
        {
            return await _authenticationDal.GetList();
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
    }
}
