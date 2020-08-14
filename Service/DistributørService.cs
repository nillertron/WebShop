using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    class DistributørService : IDistributørService
    {
        public Task<WS_Distributør> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<WS_Distributør>> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
