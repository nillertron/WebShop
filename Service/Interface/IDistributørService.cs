using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    interface IDistributørService
    {
        Task<List<WS_Distributør>> GetAll();
        Task<WS_Distributør> Get(int id);
    }
}
