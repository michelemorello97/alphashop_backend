using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace SalutiWebApi.controllers
{
    [ApiController]
    [Route("api/saluti")]
    public class SalutiController
    {
        public string GetSaluti()
        {
            return "\"Saluti, sono la tua prima web apio creata in c#\"";
        }

        [HttpGet("{Nome}")]
        public string GetSaluti(string Nome) => string.Format("\"Saluti, {0} sono il tuo primo web service creato con c# in .NET 10.0\"", Nome);
    }
}