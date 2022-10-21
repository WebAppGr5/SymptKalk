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

        public DiagnoseController(IDiagnoseRepository diagnoseRepository)
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
           


        }

        public class teller
        {
            List<String> symptImg = new List<string>();
            /**
            symptKalk symptL = string1;
            symptImg = string2;

        while (string1 != null){
            //Må fortsatte i kveld
        }

        }*/
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
        public List<Diagnose> getDiagnoser(List<Symptom> symptomer)
        {
            List<SymptomBilde> symptombilder = diagnoseRepository.hentSymptomBilder(symptomer);
            List<Diagnose> diagnoser = diagnoseRepository.hentDiagnoser(symptombilder);
            return diagnoser;
        }
        //Ikke ferdig
        public List<Diagnose> getDiagnoser(String symtpomer)
        {
            if (symtpomer == null)
                return new List<Diagnose>();

            List<string> symptomListe = symtpomer.Split("-").ToList();
            List<SymptomBilde> symptomBilde = diagnoseRepository.hentSymptomBilder(symptomListe);
            List<Diagnose> diagnoser = diagnoseRepository.hentDiagnoser(symptomBilde);
            return diagnoser;



        }

        public String test()
        {
            return "det giikk";
        }
    }

      
}