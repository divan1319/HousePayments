﻿// <auto-generated />
using System;
using HousePayments.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HousePayments.Migrations
{
    [DbContext(typeof(HousePaymentsContext))]
    [Migration("20240603211714_RefactorMigration")]
    partial class RefactorMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("HousePayments.Models.Administrador", b =>
                {
                    b.Property<int>("AdminId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("AdminId");

                    b.ToTable("Administradors");
                });

            modelBuilder.Entity("HousePayments.Models.Casa", b =>
                {
                    b.Property<int>("CasaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("PoligonoId")
                        .HasColumnType("int");

                    b.Property<int>("ResidenteId")
                        .HasColumnType("int");

                    b.Property<int>("SendaId")
                        .HasColumnType("int");

                    b.HasKey("CasaId");

                    b.HasIndex("PoligonoId");

                    b.HasIndex("ResidenteId");

                    b.HasIndex("SendaId");

                    b.ToTable("Casas");
                });

            modelBuilder.Entity("HousePayments.Models.Pago", b =>
                {
                    b.Property<int>("PagoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("CasaId")
                        .HasColumnType("int");

                    b.Property<decimal>("Cuota")
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("FechaPago")
                        .HasColumnType("datetime(6)");

                    b.Property<decimal>("Mora")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("PagoId");

                    b.HasIndex("CasaId");

                    b.ToTable("Pagos");
                });

            modelBuilder.Entity("HousePayments.Models.Poligono", b =>
                {
                    b.Property<int>("PoligonoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("PoligonoId");

                    b.ToTable("Poligonos");
                });

            modelBuilder.Entity("HousePayments.Models.Residente", b =>
                {
                    b.Property<int>("ResidenteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("varchar(500)");

                    b.Property<int>("Telefono")
                        .HasColumnType("int");

                    b.HasKey("ResidenteId");

                    b.ToTable("Residentes");
                });

            modelBuilder.Entity("HousePayments.Models.Senda", b =>
                {
                    b.Property<int>("SendaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("SendaId");

                    b.ToTable("Sendas");
                });

            modelBuilder.Entity("HousePayments.Models.SendaPoligono", b =>
                {
                    b.Property<int>("SendaPoligonoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("PoligonoId")
                        .HasColumnType("int");

                    b.Property<int>("SendaId")
                        .HasColumnType("int");

                    b.HasKey("SendaPoligonoId");

                    b.HasIndex("PoligonoId");

                    b.HasIndex("SendaId");

                    b.ToTable("SendaPoligonos");
                });

            modelBuilder.Entity("HousePayments.Models.Casa", b =>
                {
                    b.HasOne("HousePayments.Models.Poligono", "Poligono")
                        .WithMany()
                        .HasForeignKey("PoligonoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HousePayments.Models.Residente", "Residente")
                        .WithMany()
                        .HasForeignKey("ResidenteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HousePayments.Models.Senda", "Senda")
                        .WithMany()
                        .HasForeignKey("SendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poligono");

                    b.Navigation("Residente");

                    b.Navigation("Senda");
                });

            modelBuilder.Entity("HousePayments.Models.Pago", b =>
                {
                    b.HasOne("HousePayments.Models.Casa", "Casa")
                        .WithMany()
                        .HasForeignKey("CasaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Casa");
                });

            modelBuilder.Entity("HousePayments.Models.SendaPoligono", b =>
                {
                    b.HasOne("HousePayments.Models.Poligono", "Poligono")
                        .WithMany("SendaPoligonos")
                        .HasForeignKey("PoligonoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HousePayments.Models.Senda", "Senda")
                        .WithMany("SendaPoligonos")
                        .HasForeignKey("SendaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Poligono");

                    b.Navigation("Senda");
                });

            modelBuilder.Entity("HousePayments.Models.Poligono", b =>
                {
                    b.Navigation("SendaPoligonos");
                });

            modelBuilder.Entity("HousePayments.Models.Senda", b =>
                {
                    b.Navigation("SendaPoligonos");
                });
#pragma warning restore 612, 618
        }
    }
}
