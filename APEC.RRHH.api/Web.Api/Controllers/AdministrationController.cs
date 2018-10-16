using Core.Contracts;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Core.Enums;
using Web.Api.Filters;

namespace Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/configuration")]
    public sealed class AdministrationController: Controller
    {
        private readonly ConfigurationManager _configurationManager;

        public AdministrationController(ConfigurationManager configurationManager)
        {
            _configurationManager = configurationManager;
        }

        /// <summary>
        /// Creates a competence
        /// </summary>
        /// <param name="competence">An instance of <see cref="Competence"/></param>
        /// <returns>A competence</returns>
        [HttpPost]
        [Route("competences")]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateCompetence([FromBody] Competence competence)
        {
            IOperationResult<Competence> operationResult = _configurationManager.CreateCompetence(competence);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult)
                : BadRequest(operationResult);
        }

        /// <summary>
        /// Gets all competences
        /// </summary>
        /// <returns>A set of competences</returns>
        [HttpGet]
        [Route("competences")]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetAllCompetences()
        {
            IOperationResult<IEnumerable<Competence>> operationResult = _configurationManager.GetAllCompetences();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult)
                : BadRequest(operationResult);
        }

        /// <summary>
        /// Gets all competences
        /// </summary>
        /// <returns>A set of competences</returns>
        [HttpGet]
        [Route("competences/availables")]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetCompetenceAvailables()
        {
            IOperationResult<IEnumerable<Competence>> operationResult = _configurationManager.GetCompetenceAvailable();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult)
                : BadRequest(operationResult);
        }

        /// <summary>
        /// Changes the competence status
        /// </summary>
        /// <returns>A <see cref="Competence"/></returns>
        [HttpPatch]
        [Route("competences/{competenceId}/status")]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult ChangesCompetenceStatus(Guid competenceId)
        {
            IOperationResult<Competence> operationResult = _configurationManager.ChangeCompetenceState(competenceId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult)
                : BadRequest(operationResult);
        }

        /// <summary>
        /// Changes the language status
        /// </summary>
        /// <returns>A <see cref="Language"/></returns>
        [HttpPatch]
        [Route("languages/{languageId}/status")]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult ChangesLanguageStatus(Guid languageId)
        {
            IOperationResult<Language> operationResult = _configurationManager.ChangeLanguageState(languageId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult)
                : BadRequest(operationResult);
        }

        /// <summary>
        /// Creates a language
        /// </summary>
        /// <param name="language">An instance of <see cref="Language"/></param>
        /// <returns>A language</returns>
        [HttpPost]
        [Route("languages")]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateLanguage([FromBody] Language language)
        {
            IOperationResult<Language> operationResult = _configurationManager.CreateLanguage(language);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult)
                : BadRequest(operationResult);
        }

        /// <summary>
        /// Get all the languages
        /// </summary>
        /// <returns>A set of languages</returns>
        [HttpGet]
        [Route("languages")]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetAllLanguages()
        {
            IOperationResult<IEnumerable<Language>> operationResult = _configurationManager.GetAllLanguages();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult)
                : BadRequest(operationResult);
        }

        /// <summary>
        /// Get all the languages
        /// </summary>
        /// <returns>A set of languages</returns>
        [HttpGet]
        [Route("languages/availables")]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetLanguagesAvailables()
        {
            IOperationResult<IEnumerable<Language>> operationResult = _configurationManager.GetLanguageAvailables();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult)
                : BadRequest(operationResult);
        }
    }
}
