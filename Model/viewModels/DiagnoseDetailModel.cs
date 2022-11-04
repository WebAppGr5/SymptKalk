namespace obligDiagnoseVerktøyy.Model.viewModels
{
    public class DiagnoseDetailModel
    {
        public string navn { get; set; }

        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra
        public int diagnoseId { get; set; }

        public String dypForklaring { get; set; }
    }
}
