using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomBilde
    {
        [Key]
        public int symptomBildeId { get; set; }

        [JsonIgnore]
        public List<SymptomSymptomBilde> symptomSymptomBilde { get; set; }

        public int diagnoseId { get; set; }

        public string navn { get; set; }

        public string beskrivelse { get; set; }
        public Diagnose diagnose { get; set; }
    }
}
