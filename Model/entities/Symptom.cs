using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class Symptom
    {
        [Key]
        public int symptomId { get; set; }

        public String navn { get; set; }

        public String description { get; set; }
        List<SymptomSymptomBilde> symptomSymptomBilde { get; set; }
    }
}
