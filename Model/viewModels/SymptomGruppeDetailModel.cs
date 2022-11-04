namespace obligDiagnoseVerktøyy.Model.viewModels
{
    public class SymptomGruppeDetailModel
    {
        public int symptomGruppeId { get; set; }
        public string navn { get; set; } //Forklaringen kan hentes ut herfra

        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra
        public String dypForklaring { get; set; }
    }
}
