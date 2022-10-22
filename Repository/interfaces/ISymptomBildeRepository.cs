using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomBildeRepository
    {


        public List<SymptomBildeListModel> hentSymptomBilderListModels();
        public List<SymptomBilde> hentSymptomBilder();
        public List<SymptomBilde> hentSymptomBilder(List<int> symptomIdEnTrenger);
        public List<SymptomBilde> hentSymptomBilder(List<Symptom> symptomer);
    }
}
