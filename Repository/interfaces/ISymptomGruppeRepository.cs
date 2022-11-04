using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Model.viewModels;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomGruppeRepository
    {


        public Task<List<SymptomGruppe>> hentSymptomGrupper();
        public Task<SymptomGruppeDetailModel> hentSymptomGruppeGittSymptomGruppeId(int symptomGruppeId);
    }
}
