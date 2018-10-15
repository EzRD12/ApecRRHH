using Core.Contracts;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Web.Api.Filters;

namespace Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/employees")]
    public sealed class EmployeeController : Controller
    {
        private readonly EmployeeManager _employeeManager;

        public EmployeeController(EmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }

        /// <summary>
        /// Creates a employee
        /// </summary>
        /// <returns>A employee vacancies available</returns>
        [HttpPost]
        [ModelStateFilter]
        [Route("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateAnEmployee(Employee employee)
        {
            IOperationResult<Employee> operationResult = _employeeManager.Create(employee);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Gets all the employees
        /// </summary>
        /// <returns>A set of <see cref="Employee"/></returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetAllEmployees()
        {
            IOperationResult<IEnumerable<Employee>> operationResult = _employeeManager.GetAll();

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Gets an employees
        /// </summary>
        /// <returns>A <see cref="Employee"/></returns>
        [HttpGet]
        [ModelStateFilter]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetAnEmployee(Guid employeeId)
        {
            IOperationResult<Employee> operationResult = _employeeManager.Find(employeeId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Delete an employee
        /// </summary>
        /// <returns>A <see cref="Employee"/></returns>
        [HttpPatch]
        [ModelStateFilter]
        [Route("{employeeId}")]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult ChangeStatusEmployee(Guid employeeId)
        {
            IOperationResult<Employee> operationResult = _employeeManager.ChangeStatus(employeeId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.OperationResult)
                : BadRequest(operationResult.Message);
        }
    }
}
