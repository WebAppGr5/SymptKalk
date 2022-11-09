using System.Data.SqlTypes;
using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;
using obligDiagnoseVerktøyy.Model.viewModels;

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
        public async Task<SymptomDetailModel> hentSymptomGittSymptomId(int symptomId)
        {
             Symptom symptom = await  db.symptom.FindAsync(symptomId);

             if (symptom == null)
                 throw new SqlNullValueException("symptom returned with null value");

            SymptomDetailModel symptomDetail = new SymptomDetailModel()
             {
                 beskrivelse = symptom.beskrivelse, dypForklaring = symptom.dypForklaring, navn = symptom.navn,
                 symptomGruppeId = symptom.symptomGruppeId, symptomId = symptom.symptomId
             };
            return symptomDetail;

        }
        public async Task<List<SymptomListModel>> hentSymptomer(int symptomGruppeId)
        {
            List<Symptom> symptomer = await db.symptom.Where((x) => x.symptomGruppeId == symptomGruppeId).ToListAsync();

            List<SymptomListModel> symptomList = symptomer.ConvertAll((x) => new SymptomListModel { beskrivelse = x.beskrivelse, navn = x.navn, symptomGruppeId = x.symptomGruppeId, symptomId = x.symptomId });
            return symptomList;
        }
        public async Task<List<SymptomListModel>> hentSymptomer()
        {
            List<Symptom> symptomer = await db.symptom.ToListAsync();

            List<SymptomListModel> symptomList = symptomer.ConvertAll((x) => new SymptomListModel { beskrivelse = x.beskrivelse, navn = x.navn, symptomGruppeId = x.symptomGruppeId, symptomId = x.symptomId });
            return symptomList; ;
        }
    }
}
