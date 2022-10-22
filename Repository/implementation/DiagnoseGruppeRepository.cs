using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class DiagnoseGruppeRepository : IDiagnoseGruppeRepository
    {
        private ApplicationDbContext db;

        public DiagnoseGruppeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<DiagnoseGruppeListModel> hentDiagnoseGrupperListModels()
        {
            List<DiagnoseGruppe> diagnoseGruppe = db.diagnoseGruppe.ToList();

            List < DiagnoseGruppeListModel> diagnoseGruppeListModel  = diagnoseGruppe.ConvertAll((x) => new DiagnoseGruppeListModel { beskrivelse = x.beskrivelse, diagnoseGruppeId = x.diagnoseGruppeId, navn = x.navn });
            return diagnoseGruppeListModel;
        }

        public List<DiagnoseGruppe> hentDiagnoseGrupper()
        {
            List<DiagnoseGruppe> diagnoseGruppe = db.diagnoseGruppe.ToList();

            return diagnoseGruppe;
        }


    }
}

