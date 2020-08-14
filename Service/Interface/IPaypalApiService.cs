using Model;
using PayPalHttp;
using System;
using System.Threading.Tasks;

namespace Service
{
    public interface IPaypalApiService
    {
        Task<string> CreateOrder(WS_Ordre ordre);
    }
}