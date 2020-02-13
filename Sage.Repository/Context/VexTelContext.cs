using Microsoft.EntityFrameworkCore;
using Sage.Domain.Entities;
using Sage.Repository.Config;

namespace Sage.Repository.Context
{
    public class SageContext : DbContext
    {
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }


        public SageContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Mapeamento das entidades
            modelBuilder.ApplyConfiguration(new EnderecoConfiguration());           
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
