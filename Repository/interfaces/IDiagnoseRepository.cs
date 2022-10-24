using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseRepository
    {

        public List<Diagnose> hentDiagnoser();
        public List<DiagnoseListModel> hentDiagnoserListModels();
        public List<DiagnoseListModel> hentDiagnoser(List<SymptomBilde> symptomBilder);
        public List<Diagnose> hentDiagnoser(int diagnoseGruppeId);
    }
}
