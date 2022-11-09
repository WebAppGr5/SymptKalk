using Microsoft.EntityFrameworkCore;
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


        public async Task<List<DiagnoseGruppeListModel>> hentDiagnoseGrupper()
        {
            List<DiagnoseGruppe> diagnoseGruppe = await db.diagnoseGruppe.ToListAsync();
            List<DiagnoseGruppeListModel> diagnoseGruppeListModel = diagnoseGruppe.ConvertAll((x) =>
                new DiagnoseGruppeListModel
                    { beskrivelse = x.beskrivelse, diagnoseGruppeId = x.diagnoseGruppeId, navn = x.navn });
            return diagnoseGruppeListModel;
        }


    }
}

