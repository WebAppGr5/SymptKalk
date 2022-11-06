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
using System.Data.SqlTypes;

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
            if (id < 0)
            {
                _logger.LogInformation("Bad id input");
                return BadRequest("Bad id input");
            }
            try
            {
                _diagnoseRepository.deleteDiagnose(id);
                return Ok();
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {
                _logger.LogError("Kunne ikke slette diagnosen");
                return BadRequest();
            }
        }

        public async Task<IActionResult> update ([FromBody] DiagnoseChangeDTO diagnose)
        {
            if (ModelState.IsValid)
            {

                try
                {
                    Diagnose diagnosen = new Diagnose
                    {
                        beskrivelse = diagnose.beskrivelse, diagnoseGruppe = null, diagnoseGruppeId = -1,
                        diagnoseId = diagnose.diagnoseId, dypForklaring = diagnose.dypForklaring, navn = diagnose.navn,
                        symptomBilde = null
                    };
                    _diagnoseRepository.update(diagnosen);
                    return Ok(diagnose);
                }
                catch (EntityNotFoundException ex)
                {
                    _logger.LogError("bad id");
                    return NotFound("bad id");
                }
                catch (Exception ex)
                {

                    _logger.LogError("Klarte ikke å endre diagnose");
                    return BadRequest(new List<Diagnose>());
                }
            }
            else
            {
                _logger.LogInformation("diagnose got bad server input");
                return BadRequest("diagnose got bad server input");
            }
        }


        public async Task<IActionResult> hentDiagnoseGittDiagnoseId(int id)
        {
            if (id < 0)
            {
                _logger.LogError("Bad id input");
                return BadRequest("Bad id input");
            }

            try
            {

                return Ok(_diagnoseRepository.hentDiagnoseGittDiagnoseId(id));
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {

                _logger.LogError("Kunne ikke hente diagnose");
                return BadRequest("Kunne ikke hente diagnose");
            }
        }

        public async Task<IActionResult> hentSymptomGittSymptomId(int id)
        {
            if (id < 0)
            {
                _logger.LogError("Bad id input");
                return BadRequest("Bad id input");
            }
            try
            {
                return Ok(_symptomRepository.hentSymptomGittSymptomId(id));
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {

                _logger.LogError("Klarte ikke å hente symptom");
                return BadRequest("Klarte ikke å hente symptom");
            }
        }

        public async Task<IActionResult> hentSymptomGruppeGittSymptomGruppeId(int id)
        {
            if (id < 0)
            {
                _logger.LogInformation("Bad id input");
                return BadRequest("Bad id input");
            }
            try
            {
                return Ok(_symptomGruppeRepository.hentSymptomGruppeGittSymptomGruppeId(id));
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex)
            {

                _logger.LogError("Klarte ikke å hente symptom gruppe");
                return BadRequest("Kunne ikke hente symptom gruppe");
            }
        }

        public async Task<IActionResult> nyDiagnose([FromBody] DiagnoseCreateDTO diagnose)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (diagnose.symptomer.Count != diagnose.varigheter.Count || diagnose.symptomer.Count == 0)
                    {
                        _logger.LogInformation("diagnose got bad server input");
                        return BadRequest("diagnose got bad server input");
                    }
                    _diagnoseRepository.addDiagnose(diagnose);
                    return Ok(diagnose);
                }
                catch (EntityNotFoundException ex)
                {
                    _logger.LogError("bad id");
                    return NotFound("bad id");
                }
                catch (Exception ex)
                {

                    _logger.LogError("Klarte ikke å lage diagnose");
                    return BadRequest(new List<Diagnose>());
                }
            }
            else
            {
                _logger.LogInformation("diagnose got bad server input");
                return BadRequest("diagnose got bad server input");
            }


        }

        //Liste over int id, f.eks 1 2 4 6 7
        public async Task<IActionResult> getDiagnoserGittSymptomer( [FromBody] List<SymptomDTO> symptomliste)
        {
            

            try
            {
                
                if (symptomliste.Count == 0)
                    return Ok(new List<Diagnose>());
                    
                List<SymptomBilde> symptombilder = await _symptomBildeRepository.hentSymptomBilder(symptomliste);
                if(symptombilder.Count == 0)
                {
                    return Ok(new List<Diagnose>());
                }
                    List<DiagnoseListModel> diagnoser = await _diagnoseRepository.hentDiagnoser(symptombilder);
                return Ok(diagnoser);
            }
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
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
            
                if ( id < 0)
                {
                    _logger.LogError("Bad id input");
                    return BadRequest("Bad id input");
                }
                try
            {
                return Ok(await _symptomRepository.hentSymptomer(id));
            }
                catch (EntityNotFoundException ex)
                {
                    _logger.LogError("bad id");
                    return NotFound("bad id");
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
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
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
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
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
            catch (EntityNotFoundException ex)
            {
                _logger.LogError("bad id");
                return NotFound("bad id");
            }
            catch (Exception ex){
                _logger.LogError("Kunne ikke hente diagnoser");
                return BadRequest("Something went wrong");
            }
        }
        [HttpGet]
        public async Task<IActionResult> getDiagnoserGittId(int id)
        {
            if (id < 0)
            {
                _logger.LogError("Bad id input");
                return BadRequest("Bad id input");
            }
                try
            {
                return Ok(await _diagnoseRepository.hentDiagnoser(id));
            }
                catch (EntityNotFoundException ex)
                {
                    _logger.LogError("bad id");
                    return NotFound("bad id");
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
            if (ModelState.IsValid)
            {
                try
                {
                    return Ok(await _symptomGruppeRepository.hentSymptomGrupper());
                }
                catch (EntityNotFoundException ex)
                {
                    _logger.LogError("bad id");
                    return NotFound("bad id");
                }
                catch (Exception ex)
                {
                    _logger.LogError("Kunne ikke hente symptom grupper");
                    return BadRequest("Something went wrong");
                }
            }
            else
            {
                _logger.LogInformation("Symptomgruppe got bad server input");
                return BadRequest("Symptomgruppe got bad server input");
            }

        }
  
    }

      
}
