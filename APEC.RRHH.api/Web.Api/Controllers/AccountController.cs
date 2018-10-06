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
    [Route("api/accounts")]
    public class AccountController : Controller
    {
        private readonly UserManager _userManager;

        public AccountController(UserManager userManager) 
            => _userManager = userManager;


        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
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

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
