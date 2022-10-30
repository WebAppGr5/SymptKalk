using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class SymptomGruppeRepository : ISymptomGruppeRepository
    {
        private ApplicationDbContext db;

        public SymptomGruppeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }



        public async Task<List<SymptomGruppe>> hentSymptomGrupper()
        {
            List<SymptomGruppe> symptomGruppe = await  db.symptomGruppe.ToListAsync();

            return symptomGruppe;
        }
    }
}
