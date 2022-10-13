using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.WebEncoders.Testing;
using obligDiagnoseVerktøyy.Repository.interfaces;


namespace obligDiagnoseVerktøyy.Controller.implementations
{

    public class DiagnoseController
    {
        private IDiagnoseRepository repository;

        public DiagnoseController(IDiagnoseRepository repository)
        {
            this.repository = repository;
  
        }

        public String test()
        {
            return "det giikk";
        }
    }
}
