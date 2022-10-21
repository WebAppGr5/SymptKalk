using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomBilde
    {
        [Key]
        public int symptomBildeId { get; set; }

        List<SymptomSymptomBilde> symptomSymptomBilde { get; set; }

        public int diagnoseId { get; set; }
        Diagnose diagnose { get; set; }
    }
}
