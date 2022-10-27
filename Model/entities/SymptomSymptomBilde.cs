using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomSymptomBilde
    {
        [Key,Column(Order = 0)]
        [MaxLength(3)]
        [RegularExpression(@"^[0-9]{1,3}$")]
        public int symptomId { get; set; }
        [Key,Column(Order =1)]
        [MaxLength(3)]
        [RegularExpression(@"^[0-9]{1,3}$")]
        public int symptomBildeId { get; set; }
        public int varighet { get; set; }
        public Symptom symptom { get; set; }
        public SymptomBilde symptomBilde { get; set; }

    }
}
