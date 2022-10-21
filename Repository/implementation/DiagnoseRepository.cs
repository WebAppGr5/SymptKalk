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

        public List<Diagnose> hentDiagnoser(List<SymptomBilde> symptomer)
        {
            throw new NotImplementedException();
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
                    if(symptomIdEnTrenger.Contains(symptomId))
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
