using StumeetAPI.Business.Abstract;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Concrete.Managers
{
    public class DeletedMessageManager : IDeletedMessageService
    {
        private IDeletedMessageDal _deletedMessageDal;

        public DeletedMessageManager(IDeletedMessageDal deletedMessageDal)
        {
            _deletedMessageDal = deletedMessageDal;
        }

        public async Task<DeletedMessage> Add(DeletedMessage deletedMessage)
        {
            //ValidatorTool.Validate(new UserValidator(), deletedMessage);
            return await _deletedMessageDal.Add(deletedMessage);
        }

        public async Task<List<DeletedMessage>> GetAll(Expression<Func<DeletedMessage, bool>> filter = null)
        {
            return await _deletedMessageDal.GetList(filter);
        }

        public async Task<DeletedMessage> GetByCondition(Expression<Func<DeletedMessage, bool>> filter = null)
        {
            return await _deletedMessageDal.Get(filter);
        }

        public async Task<DeletedMessage> GetByID(int id)
        {
            return await _deletedMessageDal.Get(u => u.Id == id);
        }

        public async Task<DeletedMessage> Update(DeletedMessage deletedMessage)
        {
            //ValidatorTool.Validate(new UserValidator(), deletedMessage);
            return await _deletedMessageDal.Update(deletedMessage);
        }
    }
}
