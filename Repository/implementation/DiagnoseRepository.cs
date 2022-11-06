using System.Data.SqlTypes;
using Microsoft.AspNetCore.Identity;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using ObligDiagnoseVerktøyy.Data;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using obligDiagnoseVerktøyy.Model.DTO;
using obligDiagnoseVerktøyy.Model.viewModels;
using obligDiagnoseVerktøyy.Controllers.implementations;

namespace obligDiagnoseVerktøyy.Repository.implementation
{
    public class DiagnoseRepository : IDiagnoseRepository
    {

        private ApplicationDbContext db;

        public DiagnoseRepository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public async Task<List<DiagnoseListModel>> hentDiagnoser(List<SymptomBilde> symptomBilder)
        {
            List<Diagnose> diagnoser = new List<Diagnose>();
            symptomBilder.ForEach(async (x) =>
            {
                Diagnose diagnose = await  db.diagnose.Where((y) => x.diagnoseId == y.diagnoseId).FirstAsync();
                if (diagnose == null)
                    throw new EntityNotFoundException("Diagnose returned with null value");
                diagnoser.Add(diagnose);

            });

            List<DiagnoseListModel> diagnoseListModel =  diagnoser.Distinct().ToList().ConvertAll((x) => new DiagnoseListModel { beskrivelse = x.beskrivelse, diagnoseId = x.diagnoseId, navn = x.navn});
            return diagnoseListModel;
        }


        public async void addDiagnose(DiagnoseCreateDTO diagnosDto)
        {
            Diagnose diagnose = new Diagnose { beskrivelse = diagnosDto.beskrivelse, navn = diagnosDto.navn,diagnoseGruppeId = 4,dypForklaring = diagnosDto.dypForklaring};
            if (diagnosDto.dypForklaring == null)
                diagnose.dypForklaring = diagnose.beskrivelse;
            db.diagnose.Add(diagnose);
            db.SaveChanges();

            //Diagnose har nå id

            SymptomBilde symptomBilde = new SymptomBilde
                { beskrivelse = diagnosDto.beskrivelse, navn = diagnosDto.beskrivelse, diagnoseId = diagnose.diagnoseId,dypForklaring = " "};



            db.symptomBilde.Add(symptomBilde);
            db.SaveChanges();

            List<int> symptomId = diagnosDto.symptomer.ConvertAll((x) => int.Parse(x));
            for(int i = 0; i < symptomId.Count; i++ )
            {
                SymptomSymptomBilde symptomSymptomBilde = new SymptomSymptomBilde
                    { symptomBildeId = symptomBilde.symptomBildeId, symptomId = symptomId[i], varighet = diagnosDto.varigheter[i] };
                db.symptomSymptomBilde.Add(symptomSymptomBilde);
            }
            await db.SaveChangesAsync();
        }
        public async void update(Diagnose diagnose)
        {
            Diagnose diagnosen = await db.diagnose.Where((x) => x.diagnoseId == diagnose.diagnoseId).FirstAsync();

            if (diagnosen == null)
                throw new EntityNotFoundException("Diagnose returned with null value");

                      diagnosen.navn = diagnose.navn;
                      diagnosen.beskrivelse = diagnose.beskrivelse;
                      diagnosen.dypForklaring = diagnose.dypForklaring;
                      if (diagnosen.dypForklaring == null)
                          diagnosen.dypForklaring = diagnosen.beskrivelse;
            db.diagnose.Update(diagnosen);
             await db.SaveChangesAsync();

        }

        public async void Add(Diagnose diagnose)
        {

            await  db.diagnose.AddAsync(diagnose);
            await db.SaveChangesAsync();

        }
        public async  void deleteDiagnose(int diagnoseId)
        {
            Diagnose diagnose = await  db.diagnose.FindAsync(diagnoseId);
            if (diagnose == null)
                throw new EntityNotFoundException("Diagnose returned with null value");

            db.diagnose.Remove(diagnose);
            await db.SaveChangesAsync();

        }
        public async  Task<DiagnoseDetailModel> hentDiagnoseGittDiagnoseId(int diagnoseId)
        {
            Diagnose diagnose = await  db.diagnose.FindAsync(diagnoseId);
            if (diagnose == null)
                throw new EntityNotFoundException("Diagnose returned with null value");
            DiagnoseDetailModel diagnoseListModle = new DiagnoseDetailModel()
            {
                beskrivelse = diagnose.beskrivelse, diagnoseId = diagnose.diagnoseId, navn = diagnose.navn,
                dypForklaring = diagnose.dypForklaring
            };
            return diagnoseListModle;

        }
        public async  Task<List<Diagnose>> hentDiagnoser()
        {
            List<Diagnose> diagnoser = await  db.diagnose.ToListAsync();
            return diagnoser;
        }
        public async  Task<List<Diagnose>> hentDiagnoser(int diagnoseGruppeId)
        {
            List<Diagnose> diagnoser = await  db.diagnose.Where((x) => x.diagnoseGruppeId == diagnoseGruppeId).ToListAsync();
            return diagnoser;
        }
    }
}
