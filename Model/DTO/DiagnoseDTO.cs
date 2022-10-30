namespace obligDiagnoseVerktøyy.Model.DTO
{
    public class DiagnoseDTO
    {
        public string navn { get; set; }
        public string beskrivelse { get; set; } 
        public List<string> symptomer { get; set; }
        public List<int> varigheter { get; set; }
    }
}
