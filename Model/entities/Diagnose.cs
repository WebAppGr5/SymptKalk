using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class Diagnose
    {
        [Key]
        [RegularExpression(@"^[0-9]{1,6}$")]
        public int diagnoseId { get; set;   }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]{3,20}$")]
        public string navn {get; set; }


        [Required]
        [MaxLength(700)]
        public string beskrivelse { get; set;} 


        public List<SymptomBilde> symptomBilde { get; set;  }

        
        public int diagnoseGruppeId { get; set; }


        [MaxLength(5000)]
        public string? dypForklaring { get; set; }

        public DiagnoseGruppe diagnoseGruppe { get; set; }


   
    }

}
