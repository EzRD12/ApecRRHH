using Core.Contracts;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Api.Filters;

namespace Web.Api.Controllers
{
    public sealed class CandidateEmployeeController: Controller
    {
        private readonly CandidateEmployeeManager _candidateEmployeeManager;

        public CandidateEmployeeController(CandidateEmployeeManager candidateEmployeeManager)
        {
            _candidateEmployeeManager = candidateEmployeeManager;
        }

        /// <summary>
        /// Creates a candidate employee
        /// </summary>
        /// <returns>A candidateEmployee vacancies available</returns>
        [HttpPost]
        [ModelStateFilter]
        [Route("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateACandidateEmployee(CandidateEmployee candidateEmployee)
        {
            IOperationResult<CandidateEmployee> operationResult = _candidateEmployeeManager.Create(candidateEmployee);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }
    }
}
