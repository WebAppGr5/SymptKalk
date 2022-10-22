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

        public List<SymptomGruppeListModel> hentSymptomGrupperListModels()
        {
            List<SymptomGruppe> symptomGruppe = db.symptomGruppe.ToList();

            List<SymptomGruppeListModel> diagnoseListModel = symptomGruppe.ConvertAll((x) => new SymptomGruppeListModel { beskrivelse=x.beskrivelse,navn=x.navn });
            return diagnoseListModel;
        }

        public List<SymptomGruppe> hentSymptomGrupper()
        {
            List<SymptomGruppe> symptomGruppe = db.symptomGruppe.ToList();

            return symptomGruppe;
        }
    }
}
