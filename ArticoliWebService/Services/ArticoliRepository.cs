using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticoliWebService.Services
{
    public class ArticoliRepository : IArticoliRepository
    {
        AlphaShopDbContext alphaShopDbContext;

        public ArticoliRepository(AlphaShopDbContext alphaShopDbContext)
        {
            this.alphaShopDbContext = alphaShopDbContext;
        }

        public async Task<IEnumerable<Articoli>> SelArticoliByDescrizione(string Descrizione)
        {
            return await this.alphaShopDbContext.Articoli
                .Where(a => a.Descrizione!.Contains(Descrizione))
                .OrderBy(a => a.Descrizione)
                .ToListAsync();
        }

        public async Task<Articoli> SelArticoloByCodice(string Code)
        {
            return await this.alphaShopDbContext.Articoli
                .Where(a => a.CodArt!.Equals(Code))
                .FirstOrDefaultAsync()!;
        }

        public async Task<Articoli> SelArticoloByEan(string Ean)
        {
            return await this.alphaShopDbContext.BarCode
                .Where(b => b.BarCode!.Equals(Ean))
                .Select(a => a.articolo)
                .FirstOrDefaultAsync()!;
        }

        public async Task<bool> ArticoloExists(string Code)
        {
            return await this.alphaShopDbContext.Articoli.AnyAsync(c => c.CodArt == Code);
        }

        public bool DelArticoli(Articoli articolo)
        {
            throw new NotImplementedException();
        }

        public bool InsArticoli(Articoli articolo)
        {
            throw new NotImplementedException();
        }

        public bool Salva()
        {
            throw new NotImplementedException();
        }

        public bool UpdArticoli(Articoli articolo)
        {
            throw new NotImplementedException();
        }
    }
}