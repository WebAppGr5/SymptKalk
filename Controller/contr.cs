using System;
using Systems.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mcv;
using System.Web.Mcv.Ajax;

//Trenger å importere symptom fra front end og lagre som sympt senere
namespace symptKalk.Controllers
{
        [Route("[controller]/[action]")]
        public class symptKalk : controller
        {
            while((symptL!= null) && (!symptL.Any()))
            {
                List<string> symptL = new List<string>();
                            while(sympt not in symptL) //Så lenge symptomet ikke er i lista
                            {
                                symptL.Add(sympt); //legger til symptomet i lista laget av bruker.
                            }
            }

        }
        private readonly symptImg db;
        //tror vi må lagre symptombildet som strings slik at vi kan sammenligne

        public bool hent(symptL symptImg)
        {
            //Her må vi hente ut symptom bildene fra en annen fil, og sammenligne lista med symptomer med bildene,
            //deretter må vi på et eller annet vis øke en satt verdi med 1 for hvert symptom som passer. Kanskje bruke prosent, slik at det ikke blir urettferdig bias mot de bildene med flere symptomer?
            //Usikker på hvordan vi gjør det eller om vi kan forenkle det på et eller annet vis?

        }
        public bool slett(sympt symptL)
        {
            //må hente info fra front end hvor de har tatt vekk et symptom, deretter fjerne den fra lista.
        }
}