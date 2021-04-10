using Locadora.Domain.Entities;
using Locadora.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Locadora.Infra.Context
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext() { }

        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=LAPTOP-U6I09CAJ\SQLEXPRESS;Initial Catalog=LOCADEVAPI;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }

        public DbSet<Carro> Carros { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Aluguel> Alugueis { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new CarroMap());
            builder.ApplyConfiguration(new ClienteMap());
            builder.ApplyConfiguration(new AluguelMap());
        }
    }
}
