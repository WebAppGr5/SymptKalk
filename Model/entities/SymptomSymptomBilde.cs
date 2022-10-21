using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomSymptomBilde
    {
        [Key]
        [Column(Order = 1)]
        public int symptomId { get; set; }
        [Key]
        [Column(Order =2)]
        public int symptomBildeId { get; set; }

        public Symptom symptom { get; set; }
        public SymptomBilde symptomBilde { get; set; }

    }
}
