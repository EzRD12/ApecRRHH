using System;
using Core.Contracts;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Web.Api.Filters;

namespace Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/jobs")]
    public sealed class DepartamentController: Controller
    {
        private readonly DepartamentManager _departamentManager;

        public DepartamentController(DepartamentManager departamentManager)
        {
            _departamentManager = departamentManager;
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
        /// Creates a departament
        /// </summary>
        /// <returns>A departament </returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("")]
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
    }
}
