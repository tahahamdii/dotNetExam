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
    [Migration("20240516074214_Hamdi")]
    partial class Hamdi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("App.ApplicationCore.Domain.Analyse", b =>
                {
                    b.Property<int>("AnalyseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnalyseId"), 1L, 1);

                    b.Property<int?>("BilanCodeInfirmier")
                        .HasColumnType("int");

                    b.Property<int?>("BilanCodePatient")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BilanDatePrelevement")
                        .HasColumnType("datetime2");

                    b.Property<int>("BilanFk")
                        .HasColumnType("int");

                    b.Property<int>("DateResultat")
                        .HasColumnType("int");

                    b.Property<double>("PrixAnalyse")
                        .HasColumnType("float");

                    b.Property<string>("TypeAnalyse")
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("ValeurAnalyse")
                        .HasColumnType("real");

                    b.Property<float>("ValeurMax")
                        .HasColumnType("real");

                    b.Property<float>("ValeurMin")
                        .HasColumnType("real");

                    b.HasKey("AnalyseId");

                    b.HasIndex("BilanCodeInfirmier", "BilanCodePatient", "BilanDatePrelevement");

                    b.ToTable("Analyse");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Bilan", b =>
                {
                    b.Property<int>("CodeInfirmier")
                        .HasColumnType("int");

                    b.Property<int>("CodePatient")
                        .HasColumnType("int");

                    b.Property<DateTime>("DatePrelevement")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailMedecin")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Paye")
                        .HasColumnType("bit");

                    b.HasKey("CodeInfirmier", "CodePatient", "DatePrelevement");

                    b.HasIndex("CodePatient");

                    b.ToTable("Bilan");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Infirmier", b =>
                {
                    b.Property<int>("InfrimierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InfrimierId"), 1L, 1);

                    b.Property<int?>("LaboratoireId")
                        .HasColumnType("int");

                    b.Property<string>("NomComplet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Specialite")
                        .HasColumnType("int");

                    b.HasKey("InfrimierId");

                    b.HasIndex("LaboratoireId");

                    b.ToTable("Infirmier");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Laboratoire", b =>
                {
                    b.Property<int>("LaboratoireId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LaboratoireId"), 1L, 1);

                    b.Property<string>("Intitule")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Localisation")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LaboratoireId");

                    b.ToTable("Laboratoire");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Patient", b =>
                {
                    b.Property<int>("CodePatient")
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(5)
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CodePatient"), 1L, 1);

                    b.Property<string>("EmailPatient")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Informations")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NomComplet")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTel")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CodePatient");

                    b.ToTable("Patient");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Analyse", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.Bilan", "Bilan")
                        .WithMany("Analyses")
                        .HasForeignKey("BilanCodeInfirmier", "BilanCodePatient", "BilanDatePrelevement");

                    b.Navigation("Bilan");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Bilan", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.Infirmier", "Infirmier")
                        .WithMany("Bilans")
                        .HasForeignKey("CodeInfirmier")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("App.ApplicationCore.Domain.Patient", "Patient")
                        .WithMany("Bilans")
                        .HasForeignKey("CodePatient")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Infirmier");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Infirmier", b =>
                {
                    b.HasOne("App.ApplicationCore.Domain.Laboratoire", "Laboratoire")
                        .WithMany("Infirmiers")
                        .HasForeignKey("LaboratoireId");

                    b.Navigation("Laboratoire");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Bilan", b =>
                {
                    b.Navigation("Analyses");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Infirmier", b =>
                {
                    b.Navigation("Bilans");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Laboratoire", b =>
                {
                    b.Navigation("Infirmiers");
                });

            modelBuilder.Entity("App.ApplicationCore.Domain.Patient", b =>
                {
                    b.Navigation("Bilans");
                });
#pragma warning restore 612, 618
        }
    }
}