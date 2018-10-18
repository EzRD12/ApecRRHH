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
    [Route("api/jobs")]
    public sealed class JobController : Controller
    {
        private readonly JobManager _jobManager;
        private readonly EmployeeManager _employeeManager;

        public JobController(JobManager jobManager, EmployeeManager employeeManager)
        {
            _jobManager = jobManager;
            _employeeManager = employeeManager;
        }

        /// <summary>
        /// Creates a job
        /// </summary>
        /// <returns>A job vacancies available</returns>
        [HttpPost]
        [ModelStateFilter]
        [Route("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateAJob([FromBody] Job job)
        {
            IOperationResult<Job> operationResult = _jobManager.Create(job);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Updates a job
        /// </summary>
        /// <returns>A job vacancies available</returns>
        [HttpPut]
        [ModelStateFilter]
        [Route("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAJob(Job job)
        {
            IOperationResult<Job> operationResult = _jobManager.Update(job);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Change a job status
        /// </summary>
        /// <returns>A job vacancies available</returns>
        [HttpPatch]
        [ModelStateFilter]
        [Route("{jobId}/status")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult ChangeJobStatus(Guid jobId)
        {
            IOperationResult<Job> operationResult = _jobManager.ChangeJobStatus(jobId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Get a job employees
        /// </summary>
        /// <returns>A set of <see cref="Employee"/></returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("{jobId}/employees")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetJobEmployeesById(Guid jobId)
        {
            IOperationResult<IEnumerable<Employee>> operationResult = _employeeManager.GetJobEmployees(jobId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }


        /// <summary>
        /// Get a job
        /// </summary>
        /// <returns>A job's instance</returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("{jobId}")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetJobById(Guid jobId)
        {
            IOperationResult<Job> operationResult = _jobManager.Find(jobId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }
    }
}
