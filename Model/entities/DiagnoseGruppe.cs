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


        public List<Diagnose> diagnose { get; set;}

        [Required]
        [MaxLength(150)]
        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra
    }
}
