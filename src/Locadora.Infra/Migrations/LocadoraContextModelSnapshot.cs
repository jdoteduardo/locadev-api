﻿// <auto-generated />
using System;
using Locadora.Infra.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Locadora.Infra.Migrations
{
    [DbContext(typeof(LocadoraContext))]
    partial class LocadoraContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Locadora.Domain.Entities.Aluguel", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<DateTime>("DataAluguel")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2")
                        .HasColumnName("dataAluguel")
                        .HasDefaultValueSql("getdate()");

                    b.Property<long>("IdCarro")
                        .HasColumnType("BIGINT")
                        .HasColumnName("idCarro");

                    b.Property<long>("IdCliente")
                        .HasColumnType("BIGINT")
                        .HasColumnName("idCliente");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("valor");

                    b.HasKey("Id");

                    b.HasIndex("IdCarro")
                        .IsUnique();

                    b.HasIndex("IdCliente")
                        .IsUnique();

                    b.ToTable("Aluguel");
                });

            modelBuilder.Entity("Locadora.Domain.Entities.Carro", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Ano")
                        .HasColumnType("int");

                    b.Property<bool>("Ativo")
                        .HasColumnType("bit");

                    b.Property<string>("Marca")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("Marca");

                    b.Property<string>("Modelo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("VARCHAR(50)")
                        .HasColumnName("Modelo");

                    b.Property<string>("Placa")
                        .IsRequired()
                        .HasColumnType("VARCHAR(7)")
                        .HasColumnName("Placa")
                        .IsFixedLength(true);

                    b.HasKey("Id");

                    b.ToTable("Carro");
                });

            modelBuilder.Entity("Locadora.Domain.Entities.Cliente", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("BIGINT")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contato")
                        .IsRequired()
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("Contato")
                        .IsFixedLength(true);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("Cpf")
                        .IsFixedLength(true);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("VARCHAR(180)")
                        .HasColumnName("Email");

                    b.Property<string>("NomeCompleto")
                        .IsRequired()
                        .HasMaxLength(180)
                        .HasColumnType("VARCHAR(180)")
                        .HasColumnName("NomeCompleto");

                    b.HasKey("Id");

                    b.ToTable("Cliente");
                });

            modelBuilder.Entity("Locadora.Domain.Entities.Aluguel", b =>
                {
                    b.HasOne("Locadora.Domain.Entities.Carro", "Carro")
                        .WithOne()
                        .HasForeignKey("Locadora.Domain.Entities.Aluguel", "IdCarro")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("Locadora.Domain.Entities.Cliente", "Cliente")
                        .WithOne()
                        .HasForeignKey("Locadora.Domain.Entities.Aluguel", "IdCliente")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Carro");

                    b.Navigation("Cliente");
                });
#pragma warning restore 612, 618
        }
    }
}
