using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Teste_Inicial.Models;
using System.Data.Entity;

namespace Teste_Inicial.Contexts
{
    public class EFContext : DbContext
    {
        public EFContext() : base("Asp_Net_MVC_CS") { }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Fabricante> Fabricantes { get; set; }
    }
}