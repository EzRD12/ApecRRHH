using Core.Contracts;
using Core.Managers;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using Web.Api.Filters;

namespace Web.Api.Controllers
{
    [Produces("application/json")]
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly UserManager _userManager;
        private readonly CandidateEmployeeManager _candidateEmployeeManager;


        public AccountController(UserManager userManager, CandidateEmployeeManager candidateEmployeeManager)
        {
            _userManager = userManager;
            _candidateEmployeeManager = candidateEmployeeManager;
        }


        /// <summary>
        /// Authenticates an user 
        /// </summary>
        /// <param name="authenticateUserRequest">An instance of <see cref="AuthenticateUserRequest"/></param>
        /// <returns>Retrieves an identification for the user</returns>
        [HttpPost]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult Authenticate([FromBody] AuthenticateUserRequest authenticateUserRequest)
        {
            IOperationResult<User> operationResult = _userManager.Authenticate(authenticateUserRequest);

            return operationResult.Success
                ? (IActionResult) Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Authenticates an user 
        /// </summary>
        /// <param name="userId">An instance of <see cref="Guid"/></param>
        /// <returns>Retrieves an identification for the user</returns>
        [HttpGet]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult GetUser([FromBody] Guid userId)
        {
            IOperationResult<User> operationResult = _userManager.Find(userId);

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }

        /// <summary>
        /// Creates an user 
        /// </summary>
        /// <param name="user">An instance of <see cref="User"/></param>
        /// <returns>Retrieves an identification for the user</returns>
        [HttpPost]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult CreateUser([FromBody] User user)
        {
            IOperationResult<User> operationResult = _userManager.Create(user);

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            CandidateEmployee candidateEmployee = new CandidateEmployee
            {
                User = operationResult.Entity
            };

            IOperationResult<CandidateEmployee> candidateEmployeeOperationResult = _candidateEmployeeManager.Create(candidateEmployee);

            return operationResult.Success
                ? (IActionResult)Ok(candidateEmployeeOperationResult.Entity)
                : BadRequest(candidateEmployeeOperationResult.Message);
        }

        /// <summary>
        /// Creates an user 
        /// </summary>
        /// <param name="user">An instance of <see cref="User"/></param>
        /// <returns>Retrieves an identification for the user</returns>
        [HttpPut]
        [ModelStateFilter]
        [ProducesResponseType(typeof(Guid), 200)]
        [ProducesResponseType(typeof(Error), 400)]
        [ProducesResponseType(typeof(Error), 500)]
        [ProducesResponseType(404)]
        public IActionResult UpdateUser([FromBody] User user)
        {
            IOperationResult<User> operationResult = _userManager.Update(user);

            if (!operationResult.Success)
            {
                return BadRequest(operationResult.Message);
            }

            return operationResult.Success
                ? (IActionResult)Ok(operationResult.Entity)
                : BadRequest(operationResult.Message);
        }
    }
}
