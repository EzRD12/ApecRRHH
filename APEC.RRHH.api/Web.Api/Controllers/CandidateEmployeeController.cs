using Core.Contracts;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Core.Enums;
using Web.Api.Filters;
using Web.Api.Models;

namespace Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/candidates")]
    public sealed class CandidateEmployeeController: Controller
    {
        private readonly CandidateEmployeeManager _candidateEmployeeManager;
        private readonly EmployeeManager _employeeManager;

        public CandidateEmployeeController(CandidateEmployeeManager candidateEmployeeManager, EmployeeManager employeeManager)
        {
            _candidateEmployeeManager = candidateEmployeeManager;
            _employeeManager = employeeManager;
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

        /// <summary>
        /// Gets all candidate interviews
        /// </summary>
        /// <returns>A set of <see cref="CandidateEmployee"/> availables</returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("interviews/history")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetCandidateInterviewHistory()
        {
            IOperationResult<IEnumerable<CandidateInterview>> operationResult = _candidateEmployeeManager.GetCandidateInterviewHistory();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Creates a candidate interview
        /// </summary>
        /// <returns>A set of <see cref="CandidateEmployee"/> availables</returns>
        [HttpPost]
        [ModelStateFilter]
        [Route("interviews")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateInterview(CandidateInterview interview)
        {
            IOperationResult<CandidateInterview> operationResult = _candidateEmployeeManager.CreateCandidateInterview(interview);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Contract a candidate
        /// </summary>
        /// <returns>A <see cref="CandidateInterview"/></returns>
        [HttpPost]
        [ModelStateFilter]
        [Route("interviews/{interviewId}/contract")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult ContractCandidate(ContractCandidate contractCandidate)
        {
            IOperationResult<CandidateInterview> operationResult = _candidateEmployeeManager.ContractCandidate(contractCandidate.InterviewId);

            CreateEmployee(contractCandidate, operationResult);
            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        private void CreateEmployee(ContractCandidate contractCandidate, IOperationResult<CandidateInterview> operationResult)
        {
            Employee employee = new Employee
            {
                AdmissionDate = DateTime.Now,
                Job = operationResult.OperationResult.Job,
                MonthlySalary = contractCandidate.MonthlySalary,
                Status = FeatureStatus.Enabled,
                User = operationResult.OperationResult.CandidateEmployee.User
            };

            _employeeManager.Create(employee);
        }
    }
}
