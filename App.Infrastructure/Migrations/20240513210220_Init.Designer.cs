﻿// <auto-generated />
using System;
using App.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace App.Infrastructure.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20240513210220_Init")]
    partial class Init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.ApplicationCore.Domain.Electeur", b =>
                {
                    b.Property<int>("ElecteurId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ElecteurId"), 1L, 1);

                    b.Property<string>("CIN")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("MonBureauVote")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("MonGenre")
                        .HasColumnType("int");

                    b.HasKey("ElecteurId");

                    b.ToTable("Electeurs");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Election", b =>
                {
                    b.Property<DateTime>("DateElection")
                        .HasColumnType("datetime2");

                    b.Property<int>("MonTypeElection")
                        .HasColumnType("int");

                    b.Property<int?>("PartiePolitiqueId")
                        .HasColumnType("int");

                    b.HasKey("DateElection");

                    b.HasIndex("PartiePolitiqueId");

                    b.ToTable("Elections");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.PartiePolitique", b =>
                {
                    b.Property<int>("PartiePolitiqueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartiePolitiqueId"), 1L, 1);

                    b.Property<DateTime>("DateFondation")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Nom")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("PartiePolitiqueId");

                    b.ToTable("PartiePolitiques");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Vote", b =>
                {
                    b.Property<DateTime>("DateElection")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartiePolitiqueId")
                        .HasColumnType("int");

                    b.Property<int>("VoteId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("MonBureauVote")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("DateElection", "PartiePolitiqueId", "VoteId");

                    b.HasIndex("PartiePolitiqueId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("ElecteurElection", b =>
                {
                    b.Property<int>("ElecteursElecteurId")
                        .HasColumnType("int");

                    b.Property<DateTime>("ElectionsDateElection")
                        .HasColumnType("datetime2");

                    b.HasKey("ElecteursElecteurId", "ElectionsDateElection");

                    b.HasIndex("ElectionsDateElection");

                    b.ToTable("ParticipationElection", (string)null);
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Election", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.PartiePolitique", null)
                        .WithMany("Elections")
                        .HasForeignKey("PartiePolitiqueId");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Vote", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.Election", "Election")
                        .WithMany("Votes")
                        .HasForeignKey("DateElection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ApplicationCore.Domain.PartiePolitique", "PartiePolitique")
                        .WithMany("Votes")
                        .HasForeignKey("PartiePolitiqueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Election");

                    b.Navigation("PartiePolitique");
                });

            modelBuilder.Entity("ElecteurElection", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.Electeur", null)
                        .WithMany()
                        .HasForeignKey("ElecteursElecteurId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ApplicationCore.Domain.Election", null)
                        .WithMany()
                        .HasForeignKey("ElectionsDateElection")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Election", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.PartiePolitique", b =>
                {
                    b.Navigation("Elections");

                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
