using Core.Contracts;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        /// <returns>An instance of <see cref="CandidateEmployee"/></returns>
        [HttpPost]
        [ModelStateFilter]
        [Route("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateACandidateEmployee([FromBody] CandidateEmployee candidateEmployee)
        {
            IOperationResult<CandidateEmployee> operationResult = _candidateEmployeeManager.Create(candidateEmployee);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Gets all candidate employees actives
        /// </summary>
        /// <returns>A set of <see cref="CandidateEmployee"/> availables</returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetCandidateEmployeesAvailables()
        {
            IOperationResult<IEnumerable<CandidateEmployee>> operationResult = _candidateEmployeeManager.GetAllActives();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }
    }
}
