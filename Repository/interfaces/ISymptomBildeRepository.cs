using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomBildeRepository
    {


        public Task<List<SymptomBilde>> hentSymptomBilder(List<SymptomDTO> symptomIdEnTrenger);

    }
}
