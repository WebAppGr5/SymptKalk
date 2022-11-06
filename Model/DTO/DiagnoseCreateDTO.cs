

    using System.ComponentModel.DataAnnotations;

    namespace obligDiagnoseVerktøyy.Model.DTO
    {
        public class DiagnoseCreateDTO
    {
            [MaxLength(20)]
            [MinLength(3)]
            [RegularExpression(@"^[a-zA-Z0-9\s-]{3,20}$")]
        public string navn { get; set; }

        [Required]
        [MaxLength(700)]
        public string beskrivelse { get; set; }
        [MaxLength(5000)]
        public string? dypForklaring { get; set; }
            public List<string> symptomer { get; set; }
            public List<int> varigheter { get; set; }
        }
    }

