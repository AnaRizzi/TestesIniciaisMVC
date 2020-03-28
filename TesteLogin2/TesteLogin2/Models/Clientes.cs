using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TesteLogin2.Models
{
    public class Clientes
    {
        
        public int IdCliente { get; set; }

        public string NomeCliente { get; set; }

        public string Email { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}