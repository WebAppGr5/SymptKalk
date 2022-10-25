using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomBilde
    {
        [Key]
        [MaxLength(3)]
        [RegularExpression(@"^[0-9]{0,3}$")]
        public int symptomBildeId { get; set; }
        
        [Required]
        [JsonIgnore]
        public List<SymptomSymptomBilde> symptomSymptomBilde { get; set; }
       
        [Required]
        [MaxLength(3)]
        [RegularExpression(@"^[0-9]{0,3}$")]
        public int diagnoseId { get; set; }

 
        [Required]
        [MaxLength(30)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]{3,30}$")]
        public string navn { get; set; }
     

        [Required]
        [MaxLength(700)]
        [RegularExpression(@"^[a-zA-Z0-9]{0,700}$")]
        public string beskrivelse { get; set; }

        public Diagnose diagnose { get; set; }

    }
}
