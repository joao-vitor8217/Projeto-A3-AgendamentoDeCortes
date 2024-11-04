﻿// <auto-generated />
using BarbeariaProjeto.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BarbeariaProjeto.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20241104172755_Barbearia")]
    partial class Barbearia
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.10");

            modelBuilder.Entity("BarbeariaProjeto.Models.Agendamento", b =>
                {
                    b.Property<int>("AgendamentoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Data")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.Property<string>("TipoDeCorte")
                        .HasColumnType("TEXT");

                    b.HasKey("AgendamentoId");

                    b.ToTable("Agendamento");
                });

            modelBuilder.Entity("BarbeariaProjeto.Models.Barbeiro", b =>
                {
                    b.Property<int>("BarbeiroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AgendamentoId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("BarbeiroNome")
                        .HasColumnType("TEXT");

                    b.HasKey("BarbeiroId");

                    b.HasIndex("AgendamentoId");

                    b.ToTable("Barbeiro");
                });

            modelBuilder.Entity("BarbeariaProjeto.Models.Barbeiro", b =>
                {
                    b.HasOne("BarbeariaProjeto.Models.Agendamento", "Agendamento")
                        .WithMany("Barbeiro")
                        .HasForeignKey("AgendamentoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agendamento");
                });

            modelBuilder.Entity("BarbeariaProjeto.Models.Agendamento", b =>
                {
                    b.Navigation("Barbeiro");
                });
#pragma warning restore 612, 618
        }
    }
}
