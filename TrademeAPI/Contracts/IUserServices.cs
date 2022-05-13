using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrademeAPI.Model;

namespace TrademeAPI.Contracts
{
    public interface IUserServices
    {
        Task Register(User user);
        Task Login(Login login);
        Task ChangePassWord(User userId);
        Task ChangeUserName(User user);
    }
}
