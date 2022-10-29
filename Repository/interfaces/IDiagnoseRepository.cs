using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseRepository
    {

        public List<Diagnose> hentDiagnoser();
        public List<DiagnoseListModel> hentDiagnoserListModels();
        public List<DiagnoseListModel> hentDiagnoser(List<SymptomBilde> symptomBilder);
        public List<Diagnose> hentDiagnoser(int diagnoseGruppeId);
        public void updatePadState(int id, int padState);
        public void deleteDiagnose(int diagnoseId);

    }
}
