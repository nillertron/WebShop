using BlazorInputFile;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public interface IVareService
    {
        Task<List<WS_Vare>> GetAllVare();
        Task<WS_Vare> GetVare(int id);
        Task InsertVare(WS_Vare vare);
        Task UpdateVare(WS_Vare vare);
        Task DeleteVare(WS_Vare vare);
        Task<List<WS_Vare>> SearchVare(string search);
    }
}
