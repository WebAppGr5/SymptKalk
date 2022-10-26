using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class DiagnoseGruppe
    {
        [Key]
        [RegularExpression(@"^[0-9]{1-3}$")]
        public int diagnoseGruppeId { get; set;  }
        [Required]
        [MaxLength(15)]
        [RegularExpression(@"^[a-zA-Z]{3,20}$")]
        public string navn { get; set; } //Forklaringen kan hentes ut herfra
      //

        public List<Diagnose> diagnose { get; set;}

        [Required]
        [MaxLength(700)]
        [RegularExpression(@"^[a-zA-Z0-9]{0,700}$")]
        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra
    }
}
