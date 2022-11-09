using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface IDiagnoseGruppeRepository
    {


        public  Task<List<DiagnoseGruppeListModel>> hentDiagnoseGrupper();


    }
}
