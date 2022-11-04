using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Model.viewModels;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomRepository
    {
        public Task<SymptomDetailModel> hentSymptomGittSymptomId(int symptomId);
        public Task<List<Symptom>> hentSymptomer();
        public Task<List<SymptomListModel>> hentSymptomer(int symptomGruppeId);
    }
}
