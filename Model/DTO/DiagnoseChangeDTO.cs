
    using System.ComponentModel.DataAnnotations;

    namespace obligDiagnoseVerktøyy.Model.DTO
{
        public class DiagnoseChangeDTO
        {
            [RegularExpression(@"^[0-9]{1,6}$")]
            public int diagnoseId { get; set; }
            [MaxLength(20)]
            [MinLength(3)]
            [RegularExpression(@"^[a-zA-Z0-9\s-]{3,20}$")]
        public string navn { get; set; }

        [Required]
        [MaxLength(700)]
        public string beskrivelse { get; set; }
        [MaxLength(5000)]
        public string? dypForklaring { get; set; }

        }
    }

