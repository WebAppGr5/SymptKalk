
using System.Collections.Generic;

using Microsoft.EntityFrameworkCore;


using System;

using obligDiagnoseVerktøyy.Model.entities;

namespace ObligDiagnoseVerktøyy.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }
        //
        public DbSet<Symptom> symptom { get; set; }
        public DbSet<SymptomBilde> symptomBilde { get; set; }
        public DbSet<SymptomGruppe> symptomGruppe { get; set; }
        public DbSet<Diagnose> diagnose { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Symptom>().ToTable("Symptom").HasKey(k => k.symptomId);

            modelBuilder.Entity<Diagnose>().ToTable("diagnose").HasKey(k => k.diagnoseId);


            modelBuilder.Entity<SymptomGruppe>().ToTable("symptomGruppe").HasKey(k => k.symptomGruppeId);
            modelBuilder.Entity<SymptomBilde>().ToTable("symptomBilde").HasKey(k => k.symptomBildeId);

        }

 
    }
}