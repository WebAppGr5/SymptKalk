using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class SymptomBildeRepository : ISymptomBildeRepository
    {
        private ApplicationDbContext db;

        public SymptomBildeRepository(ApplicationDbContext db)
        {
            this.db = db;
        }


        public List<SymptomBildeListModel> hentSymptomBilderListModels()
        {
            List<SymptomBilde> symptomBilde = db.symptomBilde.ToList();

            List<SymptomBildeListModel> symptomListModel = symptomBilde.ConvertAll((x) => new SymptomBildeListModel {beskrivelse=x.beskrivelse,diagnoseId=x.diagnoseId,navn=x.navn,symptomBildeId=x.symptomBildeId});
            return symptomListModel;
        }
        public List<SymptomBilde> hentSymptomBilder()
        {
            List<SymptomBilde> symptomBilde = db.symptomBilde.ToList();
            return symptomBilde;
        }

        public List<SymptomBilde> hentSymptomBilder(List<string> symptomer)
        {
            return new List<SymptomBilde>();
        }
        public List<SymptomBilde> hentSymptomBilder(List<Symptom> symptomer)
        {
            List<int> symptomIdEnTrenger = symptomer.ConvertAll((x) => x.symptomId);

            List<SymptomBilde> symptomBilder = db.symptomBilde.ToList();
            List<SymptomBilde> tilRetunering = new List<SymptomBilde>();

            foreach (var symptomBilde in symptomBilder)
            {
                int counter = 0;

                //Med spesifikt symptombilde
                List<int> syptomIder = db.symptomSymptomBilde.Where((x) => x.symptomBildeId == symptomBilde.symptomBildeId).ToList().ConvertAll((x) => x.symptomId);
                foreach (int symptomId in syptomIder)
                {
                    if (symptomIdEnTrenger.Contains(symptomId))
                        counter++;

                    if (counter == symptomer.Count)
                    {

                        tilRetunering.Add(symptomBilde);
                        break;
                    }
                }
            }
         
            return tilRetunering;
        }
    }
}
