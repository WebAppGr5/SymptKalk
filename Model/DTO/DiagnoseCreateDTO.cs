

    using System.ComponentModel.DataAnnotations;

    namespace obligDiagnoseVerktøyy.Model.DTO
    {
        public class DiagnoseCreateDTO
    {

            [RegularExpression(@"^[a-zA-Z0-9\s-]{3,40}$")]
        public string navn { get; set; }

        [Required]
        [MaxLength(700)]
        public string beskrivelse { get; set; }

        [Required]
        [MaxLength(5000)]
        public string dypForklaring { get; set; }
        [Required]
        public List<int> symptomer { get; set; }
        [Required]
        public List<int> varigheter { get; set; }
        }
    }

