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
    [Route("api/accounts")]
    public class DashboardController : Controller
    {
        private readonly JobManager _jobManager;
        private readonly EmployeeManager _employeeManager;
        private readonly CandidateEmployeeManager _candidateEmployeeManager;

        public DashboardController(JobManager jobManager, CandidateEmployeeManager candidateEmployeeManager)
        {
            _jobManager = jobManager;
            _candidateEmployeeManager = candidateEmployeeManager;
        }

        /// <summary>
        /// Gets vacancies available 
        /// </summary>
        /// <returns>A job vacancies available</returns>
        [HttpGet]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetVacanciesAvailable()
        {
            IOperationResult<IEnumerable<Job>> operationResult = _jobManager.GetVacanciesAvailable();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Gets all employees
        /// </summary>
        /// <returns>All employees</returns>
        [HttpGet]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetAllEmployees()
        {
            IOperationResult<IEnumerable<Employee>> operationResult = _employeeManager.GetAll();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Gets vacancies available 
        /// </summary>
        /// <returns>A job vacancies available</returns>
        [HttpGet]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetCandidateEmployeeOnAcceptationProcess()
        {
            IOperationResult<IEnumerable<CandidateEmployee>> operationResult = _candidateEmployeeManager.GetCandidateOnAcceptationProcess();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }
    }
}