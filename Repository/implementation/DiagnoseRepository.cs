using Microsoft.AspNetCore.Identity;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;
using System.Linq;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class DiagnoseRepository : IDiagnoseRepository
    {

        private ApplicationDbContext db;

        public DiagnoseRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<DiagnoseListModel> hentDiagnoser(List<SymptomBilde> symptomBilder)
        {
            List<Diagnose> diagnoser = new List<Diagnose>();
            symptomBilder.ForEach((x) =>
            {
                Diagnose diagnose = db.diagnose.Where((y) => x.diagnoseId == y.diagnoseId).First();
                diagnoser.Add(diagnose);

            });

            List<DiagnoseListModel> diagnoseListModel = diagnoser.ConvertAll((x) => new DiagnoseListModel { beskrivelse = x.beskrivelse, diagnoseGruppeId = x.diagnoseGruppeId, navn = x.navn });
            return diagnoseListModel;
        }

        public List<DiagnoseListModel> hentDiagnoserListModels()
        {
            List<Diagnose> diagnoser = db.diagnose.ToList();

            List<DiagnoseListModel> diagnoseListModel = diagnoser.ConvertAll((x) => new DiagnoseListModel {beskrivelse=x.beskrivelse,diagnoseGruppeId=x.diagnoseGruppeId,navn=x.navn});
            return diagnoseListModel;
        }
        public List<Diagnose> hentDiagnoser()
        {
            List<Diagnose> diagnoser = db.diagnose.ToList();

            return diagnoser;
        }

    }
}
