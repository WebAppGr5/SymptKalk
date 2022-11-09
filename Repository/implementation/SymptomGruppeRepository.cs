using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Controllers.implementations;
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
            if (symptomGruppe == null)
                throw new EntityNotFoundException("symptomGruppe returned with null value");
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
            if (symptomGruppe == null)
                throw new EntityNotFoundException("symptomGruppe returned with null value");
            return symptomGruppe;
        }


        public async Task<List<SymptomGruppeListModel>> hentSymptomGrupper()
        {
            List<SymptomGruppe> symptomGruppe = await  db.symptomGruppe.ToListAsync();
            List<SymptomGruppeListModel> symptomGruppeList = symptomGruppe.ConvertAll((x) => new SymptomGruppeListModel
                { beskrivelse = x.beskrivelse, navn = x.navn, symptomGruppeId = x.symptomGruppeId });

            return symptomGruppeList;
        }
    }
}
