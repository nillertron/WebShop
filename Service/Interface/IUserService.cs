using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IUserService
    {
        Task<List<WS_User>> GetUsers();
        Task<WS_User> GetUser(int id);
        Task InsertUser(WS_User user);
        Task UpdateUser(WS_User user);
        Task DeleteUser(WS_User user);
    }
}
