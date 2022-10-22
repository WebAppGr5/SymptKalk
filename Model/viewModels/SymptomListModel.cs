using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class SymptomListModel
    {


        public String navn { get; set; }

        public int symptomGruppeId { get; set; }


        public String beskrivelse { get; set; }


    }
}
