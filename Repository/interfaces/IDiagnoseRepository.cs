using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseRepository
    {
        public List<SymptomBilde> hentSymptomBilder(List<Symptom> symptomer);
    }
}
