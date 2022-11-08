using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomGruppe
    {
        [Key]
        [RegularExpression(@"^[0-9]{1,6}$")]
        public int symptomGruppeId { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Z0-9\s-]{3,40}$")]
        public string navn { get; set; } //Forklaringen kan hentes ut herfra


        public List<Symptom> symptomer { get; set; }
        
        [Required]
        [MaxLength(700)]
        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra


        [MaxLength(5000)]
        public String dypForklaring { get; set; }
    }
}
