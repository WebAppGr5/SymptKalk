using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class Diagnose
    {
        [Key]
        [RegularExpression(@"^[0-9]{1-4}$")]
        public int diagnoseId { get; set;   }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]{3,20}$")]
        public string navn {get; set; }

        [MaxLength(700)]
        [RegularExpression(@"^[a-zA-Z0-9]{0,700}$")]
        public string beskrivelse { get; set;} //Forklaringen kan hentes ut herfra


        public List<SymptomBilde> symptomBilde { get; set;  }

        public int diagnoseGruppeId { get; set; }



        public DiagnoseGruppe diagnoseGruppe { get; set; }


   
    }

}
