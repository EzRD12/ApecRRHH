using System;
using System.Collections.Generic;
using Core.Contracts;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Filters;

namespace Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/departaments")]
    public sealed class DepartamentController: Controller
    {
        private readonly DepartamentManager _departamentManager;
        private readonly JobManager _jobManager;

        public DepartamentController(DepartamentManager departamentManager, JobManager jobManager)
        {
            _departamentManager = departamentManager;
            _jobManager = jobManager;
        }

        /// <summary>
        /// Creates a departament
        /// </summary>
        /// <returns>A departament vacancies available</returns>
        [HttpPost]
        [ModelStateFilter]
        [Route("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateDepartment(Departament departament)
        {
            IOperationResult<Departament> operationResult =  _departamentManager.Create(departament);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Gets all the departament
        /// </summary>
        /// <returns>A departament </returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetAllDepartament()
        {
            IOperationResult<IEnumerable<Departament>> operationResult = _departamentManager.GetAll();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Get a departament
        /// </summary>
        /// <returns>A departament </returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("{departamentId}")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetDepartament(Guid departamentId)
        {
            IOperationResult<Departament> operationResult = _departamentManager.Find(departamentId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Get a departament
        /// </summary>
        /// <returns>A departament </returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("{departamentId}/jobs")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetDepartamentJobs(Guid departamentId)
        {
            IOperationResult<IEnumerable<Job>> operationResult = _jobManager.GetByDepartament(departamentId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }
    }
}
