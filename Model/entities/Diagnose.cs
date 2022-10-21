using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class Diagnose
    {
        [Key]
        public int diagnoseId { get; set; }
        
        public string navn {get; set; } 


        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra

        public List<SymptomBilde> symptomBilde { get; set; }

        public int diagnoseGruppeId { get; set; }
        public DiagnoseGruppe diagnoseGruppe { get; set; }

   
    }

}
