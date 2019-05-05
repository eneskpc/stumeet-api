using StumeetAPI.Business.Abstract;
using StumeetAPI.DataAccess.Abstract;
using StumeetAPI.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace StumeetAPI.Business.Concrete.Managers
{
    public class MessageGroupManager : IMessageGroupService
    {
        private IMessageGroupDal _messageGroupDal;
        private IMessageGroupMemberDal _messageGroupMemberDal;
        private IUserDal _userDal;

        public MessageGroupManager(IMessageGroupDal messageGroupDal, IMessageGroupMemberDal messageGroupMemberDal, IUserDal userDal)
        {
            _messageGroupDal = messageGroupDal;
            _messageGroupMemberDal = messageGroupMemberDal;
            _userDal = userDal;
        }

        public async Task<MessageGroup> Add(MessageGroup messageGroupDal)
        {
            //ValidatorTool.Validate(new UserValidator(), messageGroupDal);
            return await _messageGroupDal.Add(messageGroupDal);
        }

        public async Task<List<MessageGroup>> GetAll(Expression<Func<MessageGroup, bool>> filter = null)
        {
            return await _messageGroupDal.GetList(filter);
        }

        public async Task<MessageGroup> GetByCondition(Expression<Func<MessageGroup, bool>> filter = null)
        {
            return await _messageGroupDal.Get(filter);
        }

        public async Task<MessageGroup> GetByID(int id)
        {
            return await _messageGroupDal.Get(u => u.Id == id && u.IsDeleted != true);
        }

        public async Task<MessageGroup> Update(MessageGroup messageGroupDal)
        {
            //ValidatorTool.Validate(new UserValidator(), messageGroupDal);
            return await _messageGroupDal.Update(messageGroupDal);
        }

        public async Task<List<User>> GetAllMembers(Expression<Func<MessageGroupMember, bool>> filter = null)
        {
            List<MessageGroupMember> groupMembers = await _messageGroupMemberDal.GetList(filter);
            return await _userDal.GetList(u => groupMembers.Select(gm => gm.UserId).Contains(u.Id) && u.IsDeleted != true);
        }

        public async Task<User> GetMember(Expression<Func<MessageGroupMember, bool>> filter = null)
        {
            MessageGroupMember groupMember = await _messageGroupMemberDal.Get(filter);
            return await _userDal.Get(u => u.Id == groupMember.UserId && u.IsDeleted != true);
        }

        public async Task<List<MessageGroup>> GetAllMembersReturnGroup(Expression<Func<MessageGroupMember, bool>> filter = null)
        {
            List<MessageGroupMember> groupMembers = await _messageGroupMemberDal.GetList(filter);
            return await _messageGroupDal.GetList(u => groupMembers.Select(gm => gm.GroupId).Contains(u.Id) && u.IsDeleted != true);
        }

        public async Task<MessageGroup> GetMemberReturnGroup(Expression<Func<MessageGroupMember, bool>> filter = null)
        {
            MessageGroupMember groupMember = await _messageGroupMemberDal.Get(filter);
            return await _messageGroupDal.Get(u => u.Id == groupMember.GroupId && u.IsDeleted != true);
        }
    }
}
