using System;
using DataAcces;
using Model;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public class DbService<T> : IDbService<T> where T : BaseEntity
    {
        public IRepository<T> Repository { get; set; }
        public DbService(IRepository<T> repo)
        {
            Repository = repo;
        }
    }
}
