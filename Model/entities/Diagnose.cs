using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class Diagnose
    {
        [Key]
        public int diagnoseId { get; set; }
        
        public string navn {get; set; } 


        public string description {get; set; } //Forklaringen kan hentes ut herfra

        List<SymptomBilde> symptomBilde { get; set; }

   
    }

}
