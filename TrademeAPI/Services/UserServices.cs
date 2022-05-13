using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrademeAPI.Contracts;
using TrademeAPI.Model;

namespace TrademeAPI.Services
{
    public class UserServices : IUserServices
    {
        private readonly IRepository<User> _Users;

        public UserServices(
            IRepository<User> Users
            )
        {
            _Users = Users;
        }

        public Task ChangePassWord(User userId)
        {
            throw new NotImplementedException();
        }

        public Task ChangeUserName(User user)
        {
            throw new NotImplementedException();
        }
        
        public  Task Login(Login login)
        {

            throw new NotImplementedException();
            /*
            var user = await _Users.GetQueryable()
            .Where(x => x.Account == login.Account).FirstOrDefaultAsync();
            if (null == user)
            {
                throw new NotImplementedException();
            }
            bool passwordValid = user.Password == login.Password;
            if (!passwordValid)
            {
                throw new NotImplementedException();
            }
            UserLoginResult userLoginResult = new UserLoginResult
            {
                UserId = user.UserId,
                UserName = user.UserName,
                Type = user.Type,
                DiscountRate = user.DiscountRate,
                Token = Convert.ToBase64String(Guid.NewGuid().ToByteArray())
            };
            return userLoginResult;
             */
        }

        public  Task Register(User user)
        {

            throw new NotImplementedException();
        }
        
    }
}
