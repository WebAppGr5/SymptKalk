namespace obligDiagnoseVerktøyy.Model.viewModels
{
    public class SymptomDetailModel
    {
        public int symptomId { get; set; }
        public String navn { get; set; }

        public int symptomGruppeId { get; set; }


        public String beskrivelse { get; set; }

        public String dypForklaring { get; set; }
    }
}
