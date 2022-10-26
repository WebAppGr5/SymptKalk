
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;


using System;

using obligDiagnoseVerktøyy.Model.entities;

namespace ObligDiagnoseVerktøyy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {  Database.EnsureCreated();  }
        //
        public DbSet<Symptom> symptom { get; set; }
        public DbSet<SymptomBilde> symptomBilde { get; set; }
        public DbSet<DiagnoseGruppe> diagnoseGruppe { get; set; }
        public DbSet<Diagnose> diagnose { get; set; }

        public DbSet<SymptomGruppe> symptomGruppe { get; set; }
        public DbSet<SymptomSymptomBilde> symptomSymptomBilde { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Symptom>().ToTable("symptom").HasKey(k => k.symptomId);

            modelBuilder.Entity<Diagnose>().ToTable("diagnose").HasKey(k => k.diagnoseId);


            modelBuilder.Entity<DiagnoseGruppe>().ToTable("diagnoseGruppe").HasKey(k => k.diagnoseGruppeId);
            modelBuilder.Entity<SymptomGruppe>().ToTable("symptomGruppe").HasKey(k => k.symptomGruppeId);
            modelBuilder.Entity<SymptomBilde>().ToTable("symptomBilde").HasKey(k => k.symptomBildeId);
            modelBuilder.Entity<SymptomSymptomBilde>().ToTable("symptomSymptomBilde").HasKey((x)=>new { x.symptomId, x.symptomBildeId });

            modelBuilder.Entity<SymptomSymptomBilde>().HasOne(x => x.symptom).WithMany((x) => x.symptomSymptomBilde).HasForeignKey((x) => x.symptomId);
            modelBuilder.Entity<SymptomSymptomBilde>().HasOne(x => x.symptomBilde).WithMany((x) => x.symptomSymptomBilde).HasForeignKey((x) => x.symptomBildeId);
            modelBuilder.Entity<Symptom>().HasOne(x => x.symptomGruppe).WithMany((x) => x.symptomer).HasForeignKey((x) => x.symptomGruppeId);
            modelBuilder.Entity<Diagnose>().HasOne(x => x.diagnoseGruppe).WithMany((x) => x.diagnose).HasForeignKey((x) => x.diagnoseGruppeId);
            modelBuilder.Entity<SymptomBilde>().HasOne(x => x.diagnose).WithMany((x) => x.symptomBilde).HasForeignKey((x) => x.diagnoseId);

        }

 
    }
}