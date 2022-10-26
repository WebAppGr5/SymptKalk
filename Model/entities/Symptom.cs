using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class Symptom
    {
        [Key]
        public int symptomId { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(3)]
        [RegularExpression(@"^[a-zA-Z]{3,20}$")]
        public String navn { get; set; }

        [Required]
        [MaxLength(3)]
        [RegularExpression(@"^[0-9]{1,3}$")]
        public int symptomGruppeId { get; set; }
        public SymptomGruppe symptomGruppe { get; set; }

        [Required]
        [MaxLength(700)]
        [RegularExpression(@"^[a-zA-Z0-9]{0,700}$")]
        public String beskrivelse { get; set; }

        public int varighet { get; set; }

        [JsonIgnore]
        public List<SymptomSymptomBilde> symptomSymptomBilde { get; set; }
    }
}
