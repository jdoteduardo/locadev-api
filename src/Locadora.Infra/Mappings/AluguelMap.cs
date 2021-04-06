using Locadora.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Infra.Mappings
{
    public class AluguelMap : IEntityTypeConfiguration<Aluguel>
    {
        public void Configure(EntityTypeBuilder<Aluguel> builder)
        {
            builder.ToTable("Aluguel");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.IdCarro)
                .IsRequired()
                .HasColumnName("idCarro");

            builder.Property(x => x.IdCliente)
                .IsRequired()
                .HasColumnName("idCliente");

            builder.Property(x => x.DataAluguel)
                .IsRequired()
                .HasColumnName("dataAluguel")
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.Valor)
                .IsRequired()
                .HasColumnName("valor");

            // Relacionamentos
            builder.HasOne(x => x.Carro)
                .WithOne()
                .HasForeignKey<Aluguel>(x => x.IdCarro)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Cliente)
                .WithOne()
                .HasForeignKey<Aluguel>(x => x.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
