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


        public async Task<List<DiagnoseGruppe>> hentDiagnoseGrupper()
        {
            List<DiagnoseGruppe> diagnoseGruppe = await db.diagnoseGruppe.ToListAsync();

            return diagnoseGruppe;
        }


    }
}

