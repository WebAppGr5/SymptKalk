using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseGruppeRepository
    {

        public List<DiagnoseGruppeListModel> hentDiagnoseGrupperListModels();
        public List<DiagnoseGruppe> hentDiagnoseGrupper();

    }
}
