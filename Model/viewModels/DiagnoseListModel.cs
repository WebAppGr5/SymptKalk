using System.ComponentModel.DataAnnotations;

namespace obligDiagnoseVerktøyy.Model.entities
{
    public class DiagnoseListModel
    {

        
        public string navn {get; set; } 

        public string beskrivelse { get; set; } //Forklaringen kan hentes ut herfra
        public int diagnoseId { get; set; }


    }

}
