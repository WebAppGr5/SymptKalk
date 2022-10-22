using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomGruppeRepository
    {


        public List<SymptomGruppeListModel> hentSymptomGrupperListModels();
        public List<SymptomGruppe> hentSymptomGrupper();
    }
}
