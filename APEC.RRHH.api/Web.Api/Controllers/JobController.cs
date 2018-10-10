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

        public JobController(JobManager jobManager)
        {
            _jobManager = jobManager;
        }

        /// <summary>
        /// Creates a job
        /// </summary>
        /// <returns>A job vacancies available</returns>
        [HttpPost]
        [ModelStateFilter]
        [HttpPatch("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateAJob(Job job)
        {
            IOperationResult<Job> operationResult = _jobManager.Create(job);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Updates a job
        /// </summary>
        /// <returns>A job vacancies available</returns>
        [HttpPut]
        [ModelStateFilter]
        [HttpPatch("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult UpdateAJob(Job job)
        {
            IOperationResult<Job> operationResult = _jobManager.Update(job);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Updates a job
        /// </summary>
        /// <returns>A job vacancies available</returns>
        [HttpDelete]
        [ModelStateFilter]
        [HttpPatch("{jobId}")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult DisableAJob(Guid jobId)
        {
            IOperationResult<IEnumerable<Employee>> operationResult = _jobManager.DisableJob(jobId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }


        /// <summary>
        /// Get a job
        /// </summary>
        /// <returns>A job's instance</returns>
        [HttpGet]
        [ModelStateFilter]
        [HttpPatch("{jobId}")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetJobById(Guid jobId)
        {
            IOperationResult<Job> operationResult = _jobManager.Find(jobId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }
    }
}
