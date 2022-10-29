using Microsoft.AspNetCore.Authorization;

using Microsoft.AspNetCore.Identity;

using Microsoft.Extensions.WebEncoders.Testing;
using Microsoft.VisualBasic;
using obligDiagnoseVerktøyy.Model.entities;
using obligDiagnoseVerktøyy.Repository.interfaces;

using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//using System.Web.Mcv;
//using System.Web.Mcv.Ajax;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using obligDiagnoseVerktøyy.Repository.implementation;
using Microsoft.Extensions.Logging;
using obligDiagnoseVerktøyy.Model.DTO;

namespace obligDiagnoseVerktøyy.Controllers.implementations
{
    [Route("[controller]/[action]")]
    public class DiagnoseController : ControllerBase
    {
        private IDiagnoseRepository _diagnoseRepository;
        private IDiagnoseGruppeRepository _diagnoseGruppeRepository;
        private ISymptomBildeRepository _symptomBildeRepository;
        private ISymptomGruppeRepository _symptomGruppeRepository;
        private ISymptomRepository _symptomRepository;

        private ILogger<DiagnoseController> _logger;


        public DiagnoseController(IDiagnoseRepository diagnoseRepository, IDiagnoseGruppeRepository diagnoseGruppeRepository, ISymptomBildeRepository symptomBildeRepository, ISymptomGruppeRepository symptomGruppeRepository, ISymptomRepository symptomRepository, ILogger<DiagnoseController> logger)
        {
            List<string> symptomListe = new List<string>();
            this._logger = logger;
            this._diagnoseRepository = diagnoseRepository;
            this._diagnoseGruppeRepository = diagnoseGruppeRepository;
            this._symptomBildeRepository = symptomBildeRepository;
            this._symptomGruppeRepository = symptomGruppeRepository;
            this._symptomRepository = symptomRepository;
        }

        
        public IActionResult changePadState( [FromBody] DiagnoseDTO diagnoseDTO)
        {
            try
            {
                _diagnoseRepository.updatePadState(diagnoseDTO.diagnoseId,diagnoseDTO.padState);
                return Ok(diagnoseDTO);
            }
            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke endre hengelås tilstand");
                return BadRequest();
            }
        }

        [HttpGet]
        public IActionResult forgetDiagnose(int id)
        {
            try
            {
                _diagnoseRepository.deleteDiagnose(id);
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke slette diagnosen");
                return BadRequest();
            }
        }
        //Liste over int id, f.eks 1 2 4 6 7
        public IActionResult getDiagnoserGittSymptomer( [FromBody] List<SymptomDTO> symptomliste)
        {
            

            try
            {

                List<SymptomBilde> symptombilder = _symptomBildeRepository.hentSymptomBilder(symptomliste);
                List<DiagnoseListModel> diagnoser = _diagnoseRepository.hentDiagnoser(symptombilder);
                return Ok(diagnoser);
            }
            catch (Exception ex)
            {
                _logger.LogError("Klarte ikke å konverte mellom listen over false/true kinda strenger for at et symptom er tilstede, til liste over diagnoser");
                return BadRequest(new List<Diagnose>());
            }
        }


     
        [HttpGet]
        public IActionResult getSymptomerGittGruppeId(int id)
        {
            try
            {
                return Ok(_symptomRepository.hentSymptomer(id));
            }

            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente symptomer gitt id");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        public IActionResult getDiagnoseGrupper()
        {
            try
            {
                return Ok(_diagnoseGruppeRepository.hentDiagnoseGrupper());
            }
            catch (Exception ex) {
                _logger.LogError("Kunne ikke hente diagnose grupper");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        public IActionResult getSymptomer()
        {
            try
            {
                return Ok(_symptomRepository.hentSymptomer());
            }

            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente symptomer");
                return BadRequest("Something went wrong");
            }
        }
        public IActionResult getDiagnoser()
        {
            try
            {
                return Ok(_diagnoseRepository.hentDiagnoser());
            }
            catch (Exception ex){
                _logger.LogError("Kunne ikke hente diagnoser");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        public IActionResult getDiagnoserGittId(int id)
        {
            try
            {
                return Ok(_diagnoseRepository.hentDiagnoser(id));
            }
            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente diagnoser gitt id");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        public IActionResult getSymptomGrupper()
        {
            try
            {
                return Ok(_symptomGruppeRepository.hentSymptomGrupper());
            }
            catch (Exception ex){
                _logger.LogError("Kunne ikke hente symptom grupper");
                return BadRequest("Something went wrong");
            }
        }
        public String test()
        {
            return "det gikk";
        }
    }

      
}