using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomGruppe
    {
        [Key]
        public int symptomGruppeId { get; set; }
        public string navn { get; set; } //Forklaringen kan hentes ut herfra
        public List<Symptom> symptom { get; set; }

        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra

    }
}
