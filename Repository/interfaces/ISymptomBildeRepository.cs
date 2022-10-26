using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomBildeRepository
    {


        public List<SymptomBildeListModel> hentSymptomBilderListModels();
        public List<SymptomBilde> hentSymptomBilder();
        public List<SymptomBilde> hentSymptomBilder(List<SymptomDTO> symptomIdEnTrenger);

    }
}
