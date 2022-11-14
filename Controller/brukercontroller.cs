using system;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Angular.brukerController{
    [Route("api/controller")]
    public class brukerController{
        private List <Bruker> alleBrukere = new List<Bruker>();
        [HTTPGet]
        public List<Bruker> hent(){
            var b1 = new Bruker(){
                id = 001,
                fornavn = "Ola",
                Etternavn = "Nordmann",
                passord = "123456"
            };
        }

        
    }
    
}