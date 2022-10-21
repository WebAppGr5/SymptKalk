using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class Symptom
    {
        [Key]
        public int symptomId { get; set; }

        public String navn { get; set; }

        public String beskrivelse { get; set; }

        [JsonIgnore]
        public List<SymptomSymptomBilde> symptomSymptomBilde { get; set; }
    }
}
