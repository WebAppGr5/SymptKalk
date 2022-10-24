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

        public IActionResult listen1(List<string> symptomliste)  {

            try
            {
                //Liste over id(som i database id) av symptomer i entitet Symptom
                List<int> ids = new List<int>();
                //Relativt til første id i databasen, med tanke på symptomer
                for (int i = 0; i < symptomliste.Count; i++)
                {
                    string val = symptomliste.ElementAt(i);
                    //Hvorvidt en har symptomet
                    if (val == "checked")
                    {
                        ids.Add(i);
                    }

                }
                List<SymptomBilde> symptombilder = _symptomBildeRepository.hentSymptomBilder(ids);
                List<DiagnoseListModel> diagnoser = _diagnoseRepository.hentDiagnoser(symptombilder);
                return Ok(diagnoser);
            }
            catch(Exception ex)
            {
                _logger.LogError("Klarte ikke å konverte mellom listen over false/true kinda strenger for at et symptom er tilstede, til liste over diagnoser");
                return BadRequest(new List<Diagnose>());
            }
        //=50
        }

        //Liste over streng av int, tilsvarende id; "1" "2" "3" ...
        public IActionResult listen2( List<string> symptomliste)
        {

            try {

                List<int> ids = new List<int>();

                List<int> symptomListe = symptomliste.ConvertAll((x) => int.Parse(x.ToString()));
                List<SymptomBilde> symptombilder = _symptomBildeRepository.hentSymptomBilder(ids);
                List<DiagnoseListModel> diagnoser = _diagnoseRepository.hentDiagnoser(symptombilder);
                return Ok(diagnoser);
            }
            catch (Exception ex)
            {
                _logger.LogError("Klarte ikke å konverte mellom listen over false/true kinda strenger for at et symptom er tilstede, til liste over diagnoser");
                return BadRequest(new List<Diagnose>());
            }

        }
        //Liste over int id, f.eks 1 2 4 6 7
        public IActionResult listen3( List<int> symptomliste)
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


        public IActionResult getDiagnoserGittSymptomer1(List<Symptom> symptomer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    List<SymptomBilde> symptombilder = _symptomBildeRepository.hentSymptomBilder(symptomer);
                    List<DiagnoseListModel> diagnoser = _diagnoseRepository.hentDiagnoser(symptombilder);
                    return Ok(diagnoser);
                }
                catch (Exception ex)
                {
                    _logger.LogError("listen over symptomer klarte ikke input valideringen");
                    return BadRequest("Something went wrong");
                }
            }


            else
    {
        _logger.LogError("Listen av symptomene feilet input valideringen");
        return BadRequest("Something went wrong");

            }
          }

        //Ikke ferdig

        public IActionResult getDiagnoserGittSymptomer2( String symptomer)
        {

                try
                {
                    if (symptomer == null)
                        return NotFound(new List<DiagnoseListModel>());

                    List<int> symptomListe = symptomer.Split("-").ToList().ConvertAll((x) => int.Parse(x.ToString()));
                    List<SymptomBilde> symptombilder = _symptomBildeRepository.hentSymptomBilder(symptomListe);
                    List<DiagnoseListModel> diagnoser = _diagnoseRepository.hentDiagnoser(symptombilder);
                    return Ok(diagnoser);
                }

                catch (Exception ex)
                {
                   _logger.LogError("Kunne ikke konvertere streng av symptom id'er til liste over diagnoser");
                  return BadRequest("Something went wrong");
                }
            }

        public IActionResult getSymptomer()
        {
            try
            {
                return Ok(_symptomRepository.hentSymptomer());
             }

            catch (Exception ex) {
               _logger.LogError("Kunne ikke hente symptomer");
               return BadRequest("Something went wrong");
            }
         }

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

        public IActionResult getDiagnoserGittId( int id)
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