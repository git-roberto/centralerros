using CentralErro.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentralErro.Core
{
    public class Contexto : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=dbErro;Persist Security Info=True;User ID=sa; Password=8ik,9ol.");
        }

        public DbSet<TipoErro> TipoErro { get; set; }
        public DbSet<Erro> Erro { get; set; }
    }
}
