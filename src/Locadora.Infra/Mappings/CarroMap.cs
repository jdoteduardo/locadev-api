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
    public class CarroMap : IEntityTypeConfiguration<Carro>
    {
        public void Configure(EntityTypeBuilder<Carro> builder)
        {
            builder.ToTable("Carro");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.Placa)
                .IsRequired()
                .IsFixedLength()
                .HasColumnName("Placa")
                .HasColumnType("VARCHAR(7)");

            builder.Property(x => x.Marca)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Marca")
                .HasColumnType("VARCHAR(50)");

            builder.Property(x => x.Modelo)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("Modelo")
                .HasColumnType("VARCHAR(50)");
        }
    }
}
