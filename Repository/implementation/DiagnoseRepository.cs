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

        public void addDiagnose(DiagnoseDTO diagnosDto)
        {
            Diagnose diagnose = new Diagnose { beskrivelse = diagnosDto.beskrivelse, navn = diagnosDto.navn,diagnoseGruppeId = 4};
            db.diagnose.Add(diagnose);
            db.SaveChanges();

            //Diagnose har nå id

            SymptomBilde symptomBilde = new SymptomBilde
                { beskrivelse = diagnosDto.beskrivelse, navn = diagnosDto.beskrivelse, diagnoseId = diagnose.diagnoseId };
            db.symptomBilde.Add(symptomBilde);
            db.SaveChanges();

            List<int> symptomId = diagnosDto.symptomer.ConvertAll((x) => int.Parse(x));
            for(int i = 0; i < symptomId.Count; i++ )
            {
                SymptomSymptomBilde symptomSymptomBilde = new SymptomSymptomBilde
                    { symptomBildeId = symptomBilde.symptomBildeId, symptomId = symptomId[i], varighet = diagnosDto.varigheter[i] };
                db.symptomSymptomBilde.Add(symptomSymptomBilde);
            }
            db.SaveChanges();
        }
        public void update(Diagnose diagnose)
        {
            Diagnose diagnosen = db.diagnose.Where((x) => x.diagnoseId == diagnose.diagnoseId).ToList().First();

                diagnosen.padState = diagnose.padState;
                if (diagnose.navn != null)
                      diagnosen.navn = diagnose.navn;
                if (diagnose.beskrivelse != null)
                     diagnosen.beskrivelse = diagnosen.beskrivelse;
            db.diagnose.Update(diagnosen);
            db.SaveChanges();

        }

        public void Add(Diagnose diagnose)
        {

            db.diagnose.Add(diagnose);
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
