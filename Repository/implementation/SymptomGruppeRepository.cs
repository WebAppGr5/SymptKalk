using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Model.viewModels;
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
        public async Task<SymptomGruppeDetailModel> hentSymptomGruppeGittSymptomGruppeId(int symptomGruppeId)
        {
            SymptomGruppe symptomGruppe = await db.symptomGruppe.FindAsync(symptomGruppeId);
            SymptomGruppeDetailModel symptomGruppeDetail = new SymptomGruppeDetailModel()
            {symptomGruppeId = symptomGruppe.symptomGruppeId,
                beskrivelse = symptomGruppe.beskrivelse,
                dypForklaring = symptomGruppe.dypForklaring,
                navn = symptomGruppe.navn
            };
            return symptomGruppeDetail;

        }
        public async Task<SymptomGruppe> hentSymptomGruppeGittId(int id)
        {
            SymptomGruppe symptomGruppe = await db.symptomGruppe.FindAsync(id);
            return symptomGruppe;
        }


        public async Task<List<SymptomGruppe>> hentSymptomGrupper()
        {
            List<SymptomGruppe> symptomGruppe = await  db.symptomGruppe.ToListAsync();

            return symptomGruppe;
        }
    }
}
