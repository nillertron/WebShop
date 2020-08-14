using Model;
using System;
using System.Threading.Tasks;

namespace Service
{
    public interface ILoginStateService
    {
        WS_User CurrentUser { get; }

        Task<bool> CheckRank(Rank rank);
        Task<bool> GetLoginState();
        Task<bool> Login(string UserName, string Password);
        Task Logout();
        event Action LoggedIn;

    }
}