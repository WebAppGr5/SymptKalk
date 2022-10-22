using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.VisualBasic;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;
using System;
//using Systems.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
//using System.Web.Mcv;
//using System.Web.Mcv.Ajax;

namespace obligDiagnoseVerktøyy.Controller.implementations
{

    public class DiagnoseController : ControllerBase
    {
        private IDiagnoseRepository diagnoseRepository;
        private IDiagnoseGruppeRepository diagnoseGruppeRepository;
        private ISymptomBildeRepository symptomBildeRepository;
        private ISymptomGruppeRepository symptomGruppeRepository;
        private ISymptomRepository symptomRepository;



        public DiagnoseController(IDiagnoseRepository diagnoseRepository, IDiagnoseGruppeRepository diagnoseGruppeRepository, ISymptomBildeRepository symptomBildeRepository, ISymptomGruppeRepository symptomGruppeRepository, ISymptomRepository symptomRepository)
        {
                      /**
            while ((symptL != null) && (!symptL.Any()))
            {
                List<string> symptL = new List<string>();
                while (sympt not in symptL) //Så lenge symptomet ikke er i lista
                            {
                    symptL.Add(sympt); //legger til symptomet i lista laget av bruker.
                }
            }*/
            this.diagnoseRepository = diagnoseRepository;
            this.diagnoseGruppeRepository = diagnoseGruppeRepository;
            this.symptomBildeRepository = symptomBildeRepository;
            this.symptomGruppeRepository = symptomGruppeRepository;
            this.symptomRepository = symptomRepository;
        }

        public class teller
        {
                    List<int> symptomIdEnTrenger = symptomer.ConvertAll((x) => x.symptomId);

                    List<SymptomBilde> symptomBilder = db.symptomBilde.ToList();
                    List<SymptomBilde> tilRetunering = new List<SymptomBilde>();

                    foreach (var symptomBilde in symptomBilder)
                    {
                        int counter = 0;

                        //Med spesifikt symptombilde
                        List<int> syptomIder = db.symptomSymptomBilde.Where((x) => x.symptomBildeId == symptomBilde.symptomBildeId).ToList().ConvertAll((x) => x.symptomId);
                        foreach (int symptomId in syptomIder)
                        {
                            if(symptomIdEnTrenger.Contains(symptomId))
                                counter++;

                            if (counter == symptomer.Count)
                            {

                                tilRetunering.Add(symptomBilde);
                                break;
                            }
                        }
                    }
                    return tilRetunering;
                }

        public bool hent(symptom){
            
        }

        public bool hent(Symptom symptImg)
        {
            //Her må vi hente ut symptom bildene fra en annen fil, og sammenligne lista med symptomer med bildene,
            //deretter må vi på et eller annet vis øke en satt verdi med 1 for hvert symptom som passer. Kanskje bruke prosent, slik at det ikke blir urettferdig bias mot de bildene med flere symptomer?
            //Usikker på hvordan vi gjør det eller om vi kan forenkle det på et eller annet vis?
            return false;
        }
        //Ikke ferdig
        public bool slett(Symptom symptL)
        {
            //må hente info fra front end hvor de har tatt vekk et symptom, deretter fjerne den fra lista.
            return false;
        }
        //Ikke ferdig
        public List<DiagnoseListModel> getDiagnoserGittSymptomer1(List<Symptom> symptomer)
        {
            List<SymptomBilde> symptombilder = symptomBildeRepository.hentSymptomBilder(symptomer);
            List<DiagnoseListModel> diagnoser = diagnoseRepository.hentDiagnoser(symptombilder);
            return diagnoser;
        }
        //Ikke ferdig

        public List<DiagnoseListModel> getDiagnoserGittSymptomer2(String symtpomer)
        {
            if (symtpomer == null)
                return new List<DiagnoseListModel>();

            List<int> symptomListe = symtpomer.Split("-").ToList().ConvertAll((x)=> int.Parse(x.ToString()));
            List<SymptomBilde> symptombilder = symptomBildeRepository.hentSymptomBilder(symptomListe);
            List<DiagnoseListModel> diagnoser = diagnoseRepository.hentDiagnoser(symptombilder);
            return diagnoser;



        }


        public List<Symptom> getSymptomer()
        {
            return symptomRepository.hentSymptomer();
        }
        public List<DiagnoseGruppe> getDiagnoseGrupper()
        {
            return diagnoseGruppeRepository.hentDiagnoseGrupper();
        }
        public List<Diagnose> getDiagnoser()
        {
            return diagnoseRepository.hentDiagnoser();
        }
        public List<Symptom> GetSymptomer()
        {
            return symptomRepository.hentSymptomer();
        }
        public List<SymptomGruppe> getSymptomGruppe()
        {
            return symptomGruppeRepository.hentSymptomGrupper();
        }
        public String test()
        {
            return "det giikk";
        }
    }

      
}