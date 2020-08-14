using Microsoft.EntityFrameworkCore;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class OrdreService : IOrdreService
    {
        private IDbService<WS_Ordre> ordreDbService;
        private IDbService<WS_OrdreLinje> ordrelinjeDbService;
        private ILoginStateService loginService;
        public event Action VareChanged;
        public WS_Ordre ordre { get; private set; }
        public OrdreService(IDbService<WS_Ordre> ordreDbService, IDbService<WS_OrdreLinje> ordreLinjeDbService, ILoginStateService login)
        {
            this.ordreDbService = ordreDbService;
            this.ordrelinjeDbService = ordreLinjeDbService;
            this.ordre = new WS_Ordre();
            this.loginService = login;
        }
        public async Task<List<Model.WS_Ordre>> GetAll()
        {
            var list = await ordreDbService.Repository._context.WS_Ordre.Include(x => x.OrdreLinjer).Include(x => x.User).ToListAsync();
            return list;
        }
        public async Task<WS_Ordre> Get(int ordreId)
        {
            var ordre = ordreDbService.Repository._context.WS_Ordre.Where(x => x.Id == ordreId).Include(x => x.OrdreLinjer).FirstOrDefault();
            return ordre;
        }
        public async Task Create()
        {
            ordre.Bestilt = DateTime.Now;
            ordre.User = loginService.CurrentUser;
            await ordreDbService.Repository.Insert(ordre);
        }
        public async Task Delete(WS_Ordre ordre)
        {
            foreach(var line in ordre.OrdreLinjer)
            {
                await ordrelinjeDbService.Repository.Delete(line);
            }
            await ordreDbService.Repository.Delete(ordre);
        }

        public async Task Update(WS_Ordre ordre)
        {
            await ordreDbService.Repository.Update(ordre);
        }
        public async Task Clear()
        {
            ordre = new WS_Ordre();
        }
        public async Task AddVare(WS_Vare vare, int amount)
        {
            var existingObject = ordre.OrdreLinjer.Where(x => x.Vare.Id == vare.Id).FirstOrDefault();
            if (existingObject != null)
            {
                existingObject.Antal += amount;
            }
            else
            {
                var linje = new WS_OrdreLinje { Antal = amount, EnhedsPris = vare.Discounted?vare.DiscountedPrice:vare.Pris, Ordre = ordre, Vare = vare };
                ordre.OrdreLinjer.Add(linje);
            }
            StateChanged();
        }
        public async Task RemoveVare(WS_Vare vare, int amount)
        {
            var existingObject = ordre.OrdreLinjer.Where(x => x.Vare.Id == vare.Id).FirstOrDefault();
            if(existingObject != null)
            {
                if (existingObject.Antal - amount <= 0)
                    ordre.OrdreLinjer.Remove(existingObject);
                else
                    existingObject.Antal -= amount;
                StateChanged();
            }

        }
        private void StateChanged()
        {
            VareChanged?.Invoke();
        }
        public async Task<double> CalculateTotal()
        {
            var tempTotal = 0.00;
            foreach(var v in ordre.OrdreLinjer)
            {
                var subTotal = v.EnhedsPris * (double)v.Antal;
                tempTotal += subTotal;
            }
            return tempTotal;
        }
        public async Task ResetOrder()
        {
            ordre = new Model.WS_Ordre();
            StateChanged();
        }

    }
}
