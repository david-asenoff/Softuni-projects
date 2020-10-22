using System;
using System.Collections.Generic;
using System.Text;

namespace SharedTrip.ViewModels.Users
{
    public class RegisterInputModel
    {
        // prop names are to be taken from the view tag 'name' value
        public string Username { get; set; } 
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
