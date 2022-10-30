using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseRepository
    {

        public Task<List<Diagnose>> hentDiagnoser();

        public Task<List<DiagnoseListModel>> hentDiagnoser(List<SymptomBilde> symptomBilder);
        public Task<List<Diagnose>> hentDiagnoser(int diagnoseGruppeId);
        public void deleteDiagnose(int diagnoseId);
        public void update(Diagnose diagnose);
        public void Add(Diagnose diagnose);
        public void addDiagnose(DiagnoseDTO diagnosDto);


    }
}
