using obligDiagnoseVerktøyy.Model.entities;

namespace obligDiagnoseVerktøyy.Repository.interfaces
{
    public interface ISymptomGruppeRepository
    {


        public Task<List<SymptomGruppe>> hentSymptomGrupper();

    }
}
