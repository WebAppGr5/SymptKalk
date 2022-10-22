using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class SymptomRepository : ISymptomRepository
    {
        private ApplicationDbContext db;

        public SymptomRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public List<SymptomListModel> hentSymptomerListModels()
        {
            List<Symptom> symptomer = db.symptom.ToList();

            List<SymptomListModel> symptomList = symptomer.ConvertAll((x) => new SymptomListModel {beskrivelse=x.beskrivelse,navn=x.navn,symptomGruppeId=x.symptomGruppeId,symptomId=x.symptomId });
            return symptomList;
        }

        public List<Symptom> hentSymptomer()
        {
            List<Symptom> symptomer = db.symptom.ToList();

            return symptomer;
        }
    }
}
