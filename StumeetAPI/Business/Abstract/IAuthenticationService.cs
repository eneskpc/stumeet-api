using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using StumeetAPI.DTOs;

namespace StumeetAPI.Business.Abstract
{
    public interface IAuthenticationService
    {
        Task<List<Authentication>> GetAll(Expression<Func<Authentication, bool>> filter = null);
        Task<Authentication> GetByID(int id);
        Task<Authentication> GetByCondition(Expression<Func<Authentication, bool>> filter = null);
        Task<Authentication> Add(Authentication user);
        Task<Authentication> Update(Authentication user);
        
        Task<CustomResponse> CheckUser(string token);
    }
}
