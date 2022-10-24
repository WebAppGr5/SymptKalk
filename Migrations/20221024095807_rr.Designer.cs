﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ObligDiagnoseVerktøyy.Data;

#nullable disable

namespace obligDiagnoseVerktøyy.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20221024095807_rr")]
    partial class rr
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.Diagnose", b =>
                {
                    b.Property<int>("diagnoseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("diagnoseId"), 1L, 1);

                    b.Property<string>("beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("diagnoseGruppeId")
                        .HasColumnType("int");

                    b.Property<string>("navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("diagnoseId");

                    b.HasIndex("diagnoseGruppeId");

                    b.ToTable("diagnose", (string)null);
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.DiagnoseGruppe", b =>
                {
                    b.Property<int>("diagnoseGruppeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("diagnoseGruppeId"), 1L, 1);

                    b.Property<string>("beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("diagnoseGruppeId");

                    b.ToTable("diagnoseGruppe", (string)null);
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.Symptom", b =>
                {
                    b.Property<int>("symptomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("symptomId"), 1L, 1);

                    b.Property<string>("beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("symptomGruppeId")
                        .HasColumnType("int");

                    b.HasKey("symptomId");

                    b.HasIndex("symptomGruppeId");

                    b.ToTable("symptom", (string)null);
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.SymptomBilde", b =>
                {
                    b.Property<int>("symptomBildeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("symptomBildeId"), 1L, 1);

                    b.Property<string>("beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("diagnoseId")
                        .HasColumnType("int");

                    b.Property<string>("navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("symptomBildeId");

                    b.HasIndex("diagnoseId");

                    b.ToTable("symptomBilde", (string)null);
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.SymptomGruppe", b =>
                {
                    b.Property<int>("symptomGruppeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("symptomGruppeId"), 1L, 1);

                    b.Property<string>("beskrivelse")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("navn")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("symptomGruppeId");

                    b.ToTable("symptomGruppe", (string)null);
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.SymptomSymptomBilde", b =>
                {
                    b.Property<int>("symptomId")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("symptomBildeId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.HasKey("symptomId", "symptomBildeId");

                    b.HasIndex("symptomBildeId");

                    b.ToTable("symptomSymptomBilde", (string)null);
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.Diagnose", b =>
                {
                    b.HasOne("obligDiagnoseVerktøyy.Model.entities.DiagnoseGruppe", "diagnoseGruppe")
                        .WithMany("diagnose")
                        .HasForeignKey("diagnoseGruppeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("diagnoseGruppe");
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.Symptom", b =>
                {
                    b.HasOne("obligDiagnoseVerktøyy.Model.entities.SymptomGruppe", "symptomGruppe")
                        .WithMany("symptomer")
                        .HasForeignKey("symptomGruppeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("symptomGruppe");
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.SymptomBilde", b =>
                {
                    b.HasOne("obligDiagnoseVerktøyy.Model.entities.Diagnose", "diagnose")
                        .WithMany("symptomBilde")
                        .HasForeignKey("diagnoseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("diagnose");
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.SymptomSymptomBilde", b =>
                {
                    b.HasOne("obligDiagnoseVerktøyy.Model.entities.SymptomBilde", "symptomBilde")
                        .WithMany("symptomSymptomBilde")
                        .HasForeignKey("symptomBildeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("obligDiagnoseVerktøyy.Model.entities.Symptom", "symptom")
                        .WithMany("symptomSymptomBilde")
                        .HasForeignKey("symptomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("symptom");

                    b.Navigation("symptomBilde");
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.Diagnose", b =>
                {
                    b.Navigation("symptomBilde");
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.DiagnoseGruppe", b =>
                {
                    b.Navigation("diagnose");
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.Symptom", b =>
                {
                    b.Navigation("symptomSymptomBilde");
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.SymptomBilde", b =>
                {
                    b.Navigation("symptomSymptomBilde");
                });

            modelBuilder.Entity("obligDiagnoseVerktøyy.Model.entities.SymptomGruppe", b =>
                {
                    b.Navigation("symptomer");
                });
#pragma warning restore 612, 618
        }
    }
}
