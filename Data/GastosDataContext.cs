using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gestor_de_gastos.Models;
using Microsoft.EntityFrameworkCore;

namespace gestor_de_gastos.Data
{
    public class GastosDataContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Gasto> Gastos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=192.168.10.18;Database=GestorDeGastos;User ID=sa;Password=Naosouotaku_69;Trusted_Connection=False; TrustServerCertificate=True;");
        }
    }
}