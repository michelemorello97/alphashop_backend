using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ArticoliWebService.Models;

namespace ArticoliWebService.Services
{
    public interface IArticoliRepository
    {
        //metodi di selezione
        IEnumerable<Articoli> SelArticoliByDescrizione(string Descrizione);

        Articoli SelArticoloByCodice(string Code);

        Articoli SelArticoloByEan(string Ean);

        //metodi di modifica e inserimento
        bool InsArticoli(Articoli articolo);

        bool UpdArticoli(Articoli articolo);

        bool DelArticoli(Articoli articolo);

        bool Salva();

        //metodi di info
        bool ArticoloExists(string Code);
    }
}