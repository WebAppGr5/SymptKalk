using Microsoft.AspNetCore.Identity;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class DiagnoseRepository : IDiagnoseRepository
    {

        private ApplicationDbContext db;

        public DiagnoseRepository(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<SymptomBilde> hentSymptomBilder(List<Symptom> symptomer)
        {

            List<SymptomBilde> symptomBilder = db.symptomBilde.ToList();
            List<SymptomBilde> tilRetunering = new List<SymptomBilde>();

            foreach (var symptomBilde in symptomBilder)
            {
                int counter = 0;

                //Med spesifikt symptombilde
                List<int> syptomIder = db.symptomSymptomBilde.Where((x) => x.symptomBildeId == symptomBilde.symptomBildeId).ToList().ConvertAll((x) => x.symptomId);
                foreach (var symptomId in syptomIder)
                {
                    if (counter == symptomer.Count)
                    {
                        counter++;
                        tilRetunering.Add(symptomBilde);
                        break;
                    }
                }
            }
            return tilRetunering;
        }

    }
}
