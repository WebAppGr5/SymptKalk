using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomGruppe
    {
        [Key]
        [RegularExpression(@"^[0-9]{1,3}$")]
        public int symptomGruppeId { get; set; }

        [Required]
        [MaxLength(15)]
        [MinLength(3)]
        [RegularExpression(@"^a-zA-Z]{3,15}$")]
        public string navn { get; set; } //Forklaringen kan hentes ut herfra

        [Required]
        [RegularExpression(@"^[a-zA-Z]")]
        public List<Symptom> symptomer { get; set; }
        
        [Required]
        [MaxLength(700)]
        [RegularExpression(@"^[a-zA-Z0-9]{0,700}$")]
        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra

    }
}
