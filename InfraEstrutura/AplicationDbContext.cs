using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace InfraEstrutura
{
    public class AplicationDbContext : DbContext
    {
        protected  override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            var connectionString = "server=localhost;user id=root;Password=Si@010101;database=FoodService; Allow User Variables=True";
            //var connectionString = "server=remotemysql.com;user id=VSCsQU417i;Password=Op0Ec2idjF;database=VSCsQU417i; Allow User Variables=True";
            optionsBuilder.UseMySql(connectionString);
        }
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Cardapio> Cardapio { get; set; }
        public DbSet<ListaItemProduto> ListaItemProduto { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Mesa> Mesa { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Consumo> Consumo { get; set; }
        public DbSet<FormaPagamento> FormaPagamento { get; set; }

    }
}
