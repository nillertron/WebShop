using DataAcces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using BlazorInputFile;
using System.IO;

namespace Service
{
    public class VareService : IVareService
    {
        private IRepository<WS_Vare> _repository;
        public VareService(IRepository<WS_Vare> repository)
        {
            _repository = repository;
        }
        public async Task DeleteVare(WS_Vare vare)
        {
            await _repository.Delete(vare);
        }

        public async Task<WS_Vare> GetVare(int id)
        {
            return await _repository.Get(id);
        }

        public async Task InsertVare(WS_Vare vare)
        {
            await _repository.Insert(vare);

        }

        public async Task UpdateVare(WS_Vare vare)
        {
            await _repository.Update(vare);
        }
        public async Task<List<WS_Vare>> GetAllVare()
        {
            var vareListe = await _repository._context.WS_Vare.Include(x => x.PictureList).Include(x=>x.Category).Include(x=>x.Distributør).ToListAsync();
            foreach(var v in vareListe)
            {
                if (v.Discount > 0 && !v.Discounted)
                {
                    double trækFra = (v.Pris * v.Discount) / 100;
                    v.DiscountedPrice = v.Pris - trækFra;
                    v.DiscountedPrice = Math.Round(v.DiscountedPrice, 2);
                    v.Discounted = true;
                }
            }
            return vareListe;
        }
        public async Task<List<WS_Vare>> SearchVare(string search)
        {
            return null;
        }


    }
}
