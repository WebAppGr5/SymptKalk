using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomSymptomBilde
    {
        [Key,Column(Order = 0)]
        [RegularExpression(@"^[0-9]{1,6}$")]
        public int symptomId { get; set; }

        [Key,Column(Order =1)]
        [RegularExpression(@"^[0-9]{1,6}$")]
        public int symptomBildeId { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{1,2}$")]
        public int varighet { get; set; }
        public Symptom symptom { get; set; }
        public SymptomBilde symptomBilde { get; set; }

    }
}
