using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Model.viewModels;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseRepository
    {

        public Task<List<DiagnoseListModel>> hentDiagnoser();

        public Task<List<DiagnoseListModel>> hentDiagnoser(List<SymptomBilde> symptomBilder);
        public Task<List<DiagnoseListModel>> hentDiagnoser(int diagnoseGruppeId);
        public void deleteDiagnose(int diagnoseId);
        public void update(Diagnose diagnose);
        public void Add(Diagnose diagnose);
        public void addDiagnose(DiagnoseCreateDTO diagnoseDto);
        public Task<DiagnoseDetailModel> hentDiagnoseGittDiagnoseId(int diagnoseId);


    }
}
