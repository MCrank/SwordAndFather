using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwordAndFather.Models;

namespace SwordAndFather.Controllers
{
    /// <summary>
    /// This controller handles all of the user requests for Sword & Father
    /// </summary>
    // Attributes
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static List<User> _users = new List<User>();

        /// <summary>
        /// Creates a new user in the system
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     {
        ///         username: "mr_robot",
        ///         password: "bigB0y!"
        ///     }
        ///     
        /// </remarks>
        /// <param name="createRequest"></param>
        /// <returns>The newly created User</returns>
        /// <response code="201">Returns the newly created User</response>
        /// <response code="400">If the createResponse is formatted incorrect</response>
        [HttpPost("register")]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public ActionResult AddUser([FromBody]CreateUserRequest createRequest)
        {
            if (string.IsNullOrEmpty(createRequest.UserName) 
                || string.IsNullOrEmpty(createRequest.Password))
            {
                return BadRequest(new { error = "Users must have a username and password" });
            }
            var newUser = new User(createRequest.UserName, createRequest.Password);
            newUser.Id = _users.Count + 1;
            _users.Add(newUser);

            return Created($"api/users/{newUser.Id}", newUser);
        }
    }
}