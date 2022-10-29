using Microsoft.AspNetCore.Identity;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;
using System.Linq;
using obligDiagnoseVerktøyy.Model.DTO;

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

            List<DiagnoseListModel> diagnoseListModel = diagnoser.Distinct().ToList().ConvertAll((x) => new DiagnoseListModel { beskrivelse = x.beskrivelse, diagnoseId = x.diagnoseId, navn = x.navn,padState=x.padState});
            return diagnoseListModel;
        }
        public void updatePadState(int id, int padState)
        {
            Diagnose diagnosen = db.diagnose.Where((x) => x.diagnoseId == id).ToList().First();
            diagnosen.padState = padState;
            db.diagnose.Update(diagnosen);
            db.SaveChanges();

        }
        public void deleteDiagnose(int diagnoseId)
        {
            Diagnose diagnose = db.diagnose.Find(diagnoseId);
           
            db.diagnose.Remove(diagnose);
            db.SaveChanges();

        }
        public List<DiagnoseListModel> hentDiagnoserListModels()
        {
            List<Diagnose> diagnoser = db.diagnose.ToList();

            List<DiagnoseListModel> diagnoseListModel = diagnoser.ConvertAll((x) => new DiagnoseListModel {beskrivelse=x.beskrivelse, diagnoseId = x.diagnoseId, navn=x.navn});
            return diagnoseListModel;
        }
        public List<Diagnose> hentDiagnoser()
        {
            List<Diagnose> diagnoser = db.diagnose.ToList();
            return diagnoser;
        }
        public List<Diagnose> hentDiagnoser(int diagnoseGruppeId)
        {
            List<Diagnose> diagnoser = db.diagnose.Where((x) => x.diagnoseGruppeId == diagnoseGruppeId).ToList();
            return diagnoser;
        }
    }
}
