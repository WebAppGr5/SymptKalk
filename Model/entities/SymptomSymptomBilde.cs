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

        List<Symptom> symptomer { get; set; }
        List<SymptomBilde> SymptomBilder { get; set; }

    }
}
