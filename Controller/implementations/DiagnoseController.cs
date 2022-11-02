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

        
 

        [HttpGet]
        public async Task<IActionResult> forgetDiagnose(int id)
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

        public async Task<IActionResult> update ([FromBody] Diagnose diagnose)
        {

            try
            {
                _diagnoseRepository.update(diagnose);
                return Ok(diagnose);
            }
            catch (Exception ex)
            {
                _diagnoseRepository.update(diagnose);
                _logger.LogError("Klarte ikke å endre diagnose");
                return BadRequest(new List<Diagnose>());
            }
        }

        public async Task<IActionResult> add([FromBody] Diagnose diagnose)
        {

            try
            {
                _diagnoseRepository.Add(diagnose);
                return Ok(diagnose);
            }
            catch (Exception ex)
            {
     
                _logger.LogError("Klarte ikke å lage diagnose");
                return BadRequest(new List<Diagnose>());
            }
        }

        public async Task<IActionResult> nyDiagnose([FromBody] DiagnoseDTO diagnose)
        {

            try
            {
                _diagnoseRepository.addDiagnose(diagnose);
                return Ok(diagnose);
            }
            catch (Exception ex)
            {

                _logger.LogError("Klarte ikke å lage diagnose");
                return BadRequest(new List<Diagnose>());
            }
        }

        //Liste over int id, f.eks 1 2 4 6 7
        public async Task<IActionResult> getDiagnoserGittSymptomer( [FromBody] List<SymptomDTO> symptomliste)
        {
            

            try
            {
                if (symptomliste.Count == 0)
                    return Ok(await _diagnoseRepository.hentDiagnoser());
                    
                List<SymptomBilde> symptombilder = await _symptomBildeRepository.hentSymptomBilder(symptomliste);
                List<DiagnoseListModel> diagnoser = await _diagnoseRepository.hentDiagnoser(symptombilder);
                return Ok(diagnoser);
            }
            catch (Exception ex)
            {
                _logger.LogError("Klarte ikke å konverte mellom listen over false/true kinda strenger for at et symptom er tilstede, til liste over diagnoser");
                return BadRequest(new List<Diagnose>());
            }
        }


     
        [HttpGet]
        public async Task<IActionResult> getSymptomerGittGruppeId(int id)
        {
            try
            {
                return Ok(await _symptomRepository.hentSymptomer(id));
            }

            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente symptomer gitt id");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        public async Task<IActionResult> getDiagnoseGrupper()
        {
            try
            {
                return Ok(await _diagnoseGruppeRepository.hentDiagnoseGrupper());
            }
            catch (Exception ex) {
                _logger.LogError("Kunne ikke hente diagnose grupper");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        public async Task<IActionResult> getSymptomer()
        {
            try
            {
                return Ok(await _symptomRepository.hentSymptomer());
            }

            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente symptomer");
                return BadRequest("Something went wrong");
            }
        }
        public async Task<IActionResult> getDiagnoser()
        {
            try
            {
                return Ok(await  _diagnoseRepository.hentDiagnoser());
            }
            catch (Exception ex){
                _logger.LogError("Kunne ikke hente diagnoser");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        public async Task<IActionResult> getDiagnoserGittId(int id)
        {
            try
            {
                return Ok(await _diagnoseRepository.hentDiagnoser(id));
            }
            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke hente diagnoser gitt id");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        public async Task<IActionResult> getSymptomGrupper()
        {
            try
            {
                return Ok(await _symptomGruppeRepository.hentSymptomGrupper());
            }
            catch (Exception ex){
                _logger.LogError("Kunne ikke hente symptom grupper");
                return BadRequest("Something went wrong");
            }
        }
  
    }

      
}
