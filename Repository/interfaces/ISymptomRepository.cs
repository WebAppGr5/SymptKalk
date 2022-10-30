using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomRepository
    {
  
        public Task<List<Symptom>> hentSymptomer();
        public Task<List<SymptomListModel>> hentSymptomer(int symptomGruppeId);
    }
}
