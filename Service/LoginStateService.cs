using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    public class LoginStateService : ILoginStateService
    {
        public WS_User CurrentUser { get; private set; }
        private IDbService<WS_User> dbService;
        private int loginAttempts = 0;
        private WS_UserRank userRank;
        public event Action LoggedIn;
        public LoginStateService(IDbService<WS_User> dbService)
        {
            this.dbService = dbService;
        }
        public async Task<bool> Login(string email, string Password)
        {
            bool loginSucces = false;
            if (CurrentUser == null && loginAttempts < 4)
            {
                CurrentUser = dbService.Repository._context.WS_User.Where(x => x.Email == email && x.Password == Password).Include(x=>x.PostNr).FirstOrDefault();
                if (CurrentUser != null)
                {
                    loginSucces = true;
                    userRank = dbService.Repository._context.WS_UserRank.Where(x => x.User == CurrentUser).Include(x => x.Rank).FirstOrDefault();
                    LoggedIn?.Invoke();
                }
                loginAttempts++;
            }
            return loginSucces;
        }
        public async Task Logout()
        {
            LoggedIn?.Invoke();
            if (CurrentUser != null)
                CurrentUser = null;
            if (userRank != null)
                userRank = null;
        }
        /// <summary>
        /// True for logged in, false for not logged in
        /// </summary>
        /// <returns></returns>
        public async Task<bool> GetLoginState()
        {
            if (CurrentUser != null)
                return true;
            else
                return false;
            
        }
        /// <summary>
        /// The user has the rank = true, not logged in or not having the rank = false
        /// </summary>
        /// <param name="rank"></param>
        /// <returns></returns>
        public async Task<bool> CheckRank(Rank rank)
        {
            if (userRank != null)
            {
                if (userRank.Rank.Rank == rank)
                    return true;
            }
            return false;
        }
    }
}
