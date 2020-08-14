using DataAcces;
using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class UserService : IUserService
    {
        private IRepository<WS_User> _repository;
        private IRepository<WS_UserRank> userRankRepo;
        private IRepository<WS_Rank> rankRepo;
        public UserService(IRepository<WS_User> repo, IRepository<WS_UserRank> userRankRepo,IRepository<WS_Rank> rankRepo)
        {
            _repository = repo;
            this.userRankRepo = userRankRepo;
            this.rankRepo = rankRepo;
        }
        public async Task DeleteUser(WS_User user)
        {
            await _repository.Delete(user);
        }

        public async Task<WS_User> GetUser(int id)
        {
            return await _repository.Get(id);
        }

        public async Task<List<WS_User>> GetUsers()
        {
            var list = _repository._context.WS_User.Include(x => x.PostNr).ToList();
            return list;
        }

        public async Task InsertUser(WS_User user)
        {
            if (await CheckIfUserEmailIsTaken(user))
                throw new Exception("E-mail already in use");
            user.Oprettet = DateTime.Now;
            var rank = new WS_UserRank { Rank = await rankRepo._context.FindAsync<WS_Rank>(2), User = user };
            await _repository.Insert(user);
            await userRankRepo.Update(rank);
        }

        public async Task UpdateUser(WS_User user)
        {
            await _repository.Update(user);
        }

        private async Task<bool> CheckIfUserEmailIsTaken(WS_User _user)
        {
            var user = _repository._context.WS_User.Where(x => x.Email.ToLower() == _user.Email.ToLower()).FirstOrDefault();
            if (user == null)
                return false;
            else
                return true;
        }
    }
}
