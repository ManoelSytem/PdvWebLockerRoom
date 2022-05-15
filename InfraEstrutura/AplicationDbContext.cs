using Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;

namespace InfraEstrutura
{
    public class AplicationDbContext : DbContext
    {
        public AplicationDbContext(DbContextOptions<AplicationDbContext> options)
        : base(options)
        {
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
