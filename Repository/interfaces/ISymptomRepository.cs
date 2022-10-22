using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomRepository
    {
        public List<SymptomListModel> hentSymptomerListModels();
        public List<Symptom> hentSymptomer();

    }
}
