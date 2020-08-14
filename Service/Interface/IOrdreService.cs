using Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Service
{
    public interface IOrdreService
    {
        WS_Ordre ordre { get; }

        event Action VareChanged;

        Task AddVare(WS_Vare vare, int amount);
        Task<WS_Ordre> Get(int ordreId);

        Task Clear();
        Task Create();
        Task Delete(WS_Ordre ordre);
        Task RemoveVare(WS_Vare vare, int amount);
        Task Update(WS_Ordre ordre);
        Task<double> CalculateTotal();
        Task ResetOrder();
         Task<List<Model.WS_Ordre>> GetAll();


    }
}