using DataAcces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface IDbService<T> where T:BaseEntity
    {
        IRepository<T> Repository { get; set; }
    }
}
