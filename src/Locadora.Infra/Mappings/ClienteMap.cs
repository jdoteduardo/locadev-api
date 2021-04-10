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
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .UseIdentityColumn()
                .HasColumnType("BIGINT");

            builder.Property(x => x.NomeCompleto)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("NomeCompleto")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Cpf)
                .IsRequired()
                .HasMaxLength(14)
                .HasColumnName("Cpf")
                .HasColumnType("VARCHAR(14)");

            builder.Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(180)
                .HasColumnName("Email")
                .HasColumnType("VARCHAR(180)");

            builder.Property(x => x.Contato)
                .IsRequired()
                .HasMaxLength(15)
                .HasColumnName("Contato")
                .HasColumnType("VARCHAR(15)");

            // Relacionamentos
            builder
                .HasMany(c => c.Alugueis)
                .WithOne(o => o.Cliente)
                .HasForeignKey(o => o.IdCliente)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
