using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.DTO
{
    public class SymptomDTO
    {
        [Required]
        [RegularExpression(@"^[0-9]{1,6}$")]
        public int id { get; set; }

        [Required]
        [RegularExpression(@"^[0-9]{1,2}$")]
        public int varighet { get; set; }
    }
}
