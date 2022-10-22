using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomBildeListModel
    {
        public int symptomBildeId { get; set; }


        public int diagnoseId { get; set; }

        public string navn { get; set; }

        public string beskrivelse { get; set; }

    }
}
