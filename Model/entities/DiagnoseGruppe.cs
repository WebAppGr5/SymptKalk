using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class DiagnoseGruppe
    {
        [Key]
        public int diagnoseGruppeId { get; set; }
        public string navn { get; set; } //Forklaringen kan hentes ut herfra
        public List<Diagnose> diagnose { get; set; }

        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra
    }
}
