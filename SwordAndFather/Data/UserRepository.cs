﻿using System.Collections.Generic;
using SwordAndFather.Models;

namespace SwordAndFather.Data
{
    public class UserRepository
    {
        static List<User> _users = new List<User>();

        public User AddUser(string userName, string password)
        {
            var newUser = new User(userName, password);
            newUser.Id = _users.Count + 1;
            _users.Add(newUser);

            return newUser;
        }
    }
}