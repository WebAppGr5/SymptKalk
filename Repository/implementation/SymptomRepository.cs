using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class SymptomRepository : ISymptomRepository
    {
        private ApplicationDbContext db;

        public SymptomRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async  Task<List<SymptomListModel>> hentSymptomerListModels()
        {
            List<Symptom> symptomer = await  db.symptom.ToListAsync();

            List<SymptomListModel> symptomList = symptomer.ConvertAll((x) => new SymptomListModel {beskrivelse=x.beskrivelse,navn=x.navn,symptomGruppeId=x.symptomGruppeId,symptomId=x.symptomId });
            return symptomList;
        }
        public async Task<List<SymptomListModel>> hentSymptomer(int symptomGruppeId)
        {
            List<Symptom> symptomer = await db.symptom.Where((x) => x.symptomGruppeId == symptomGruppeId).ToListAsync();

            List<SymptomListModel> symptomList = symptomer.ConvertAll((x) => new SymptomListModel { beskrivelse = x.beskrivelse, navn = x.navn, symptomGruppeId = x.symptomGruppeId, symptomId = x.symptomId });
            return symptomList;
        }
        public async Task<List<Symptom>> hentSymptomer()
        {
            List<Symptom> symptomer = await db.symptom.ToListAsync();

            return symptomer;
        }
    }
}
