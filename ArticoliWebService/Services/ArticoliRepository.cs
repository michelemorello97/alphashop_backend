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

        public Articoli SelArticoloByCodice(string Code)
        {
            return this.alphaShopDbContext.Articoli
                .Where(a => a.CodArt!.Equals(Code))
                .FirstOrDefault()!;
        }

        public Articoli SelArticoloByEan(string Ean)
        {
            return this.alphaShopDbContext.BarCode
                .Where(b => b.BarCode!.Equals(Ean))
                .Select(a => a.articolo)
                .FirstOrDefault()!;
        }

        public bool ArticoloExists(string Code)
        {
            throw new NotImplementedException();
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