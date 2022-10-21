using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseRepository
    {
        public List<SymptomBilde> hentSymptomBilder(List<Symptom> symptomer);
        public List<SymptomBilde> hentSymptomBilder(List<string> symptomer);

        public List<Diagnose> hentDiagnoser(List<SymptomBilde> symptomer);
    }
}
