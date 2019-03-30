using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwordAndFather.Data;
using SwordAndFather.Models;
using SwordAndFather.Validators;

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
        // Dig into the access Modifiers
        readonly UserRepository _userRepository;
        readonly CreateUserRequestValidator _validator;

        // UsersController Constructor
        public UsersController()
        {
            _validator = new CreateUserRequestValidator();
            _userRepository = new UserRepository();
        }

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
            if (_validator.Validate(createRequest))
            {
                return BadRequest(new { error = "Users must have a username and password" });
            }
            
            var newUser = _userRepository.AddUser(createRequest.UserName, createRequest.Password);

            // http response
            return Created($"api/users/{newUser.Id}", newUser);
        }
    }
}