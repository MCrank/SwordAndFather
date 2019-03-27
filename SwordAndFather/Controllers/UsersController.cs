﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SwordAndFather.Models;

namespace SwordAndFather.Controllers
{
    // Attributes
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        static List<User> _users = new List<User>();

        [HttpPost("register")]
        public ActionResult AddUser(CreateUserRequest createRequest)
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