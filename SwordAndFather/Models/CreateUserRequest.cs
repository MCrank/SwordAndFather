using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SwordAndFather.Models
{
    // This class is used to control user input for POST request to add User
    public class CreateUserRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
