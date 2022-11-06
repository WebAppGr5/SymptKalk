using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class Symptom
    {
        [Key]
        [RegularExpression(@"^[0-9]{1,6}$")]
        public int symptomId { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]{3,20}$")]
        public String navn { get; set; }

        [Required]
        public int symptomGruppeId { get; set; }
        public SymptomGruppe symptomGruppe { get; set; }

        [Required]
        [MaxLength(700)]
        public String beskrivelse { get; set; }



        [MaxLength(5000)]
        public String dypForklaring { get; set; }


        [JsonIgnore]
        public List<SymptomSymptomBilde> symptomSymptomBilde { get; set; }
    }
}
