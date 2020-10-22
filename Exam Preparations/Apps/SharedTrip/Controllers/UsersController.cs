using SharedTrip.Services;
using SharedTrip.ViewModels.Users;
using SUS.HTTP;
using SUS.MvcFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SharedTrip.Controllers
{
    public class UsersController : Controller
    {
        private IUsersService usersService;

        public UsersController(IUsersService usersService)
        {
            this.usersService = usersService;
        }
        public HttpResponse Login()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Login(LoginInputModel input)
        {
            var userId = this.usersService.GetUserId(input.Username, input.Password);
            if (userId==null)
            {
                return this.Error("Invalid username or password.");
            }
            this.SignIn(userId);
            return this.Redirect("/Trips/All");
        }
        public HttpResponse Register()
        {
            return this.View();
        }
        [HttpPost]
        public HttpResponse Register(RegisterInputModel input)
        {
            if (string.IsNullOrEmpty(input.Username)||
                input.Username.Length<5||
                input.Username.Length>20)
            {
                return this.Error("Username should be between 5 and 20 characters long.");
            }
            if (string.IsNullOrEmpty(input.Email))
            {
                return this.Error("Email is required.");
            }
            if (!new EmailAddressAttribute().IsValid(input.Email))
            {
                return this.Error("Not valid Email.");
            }
            if (string.IsNullOrEmpty(input.Password))
            {
                return this.Error("Password is required.");
            }
            if (string.IsNullOrEmpty(input.Password) ||
                input.Username.Length < 6 ||
                input.Username.Length > 20)
            {
                return this.Error("Username should be between 6 and 20 characters long.");
            }
            if (input.Password !=input.ConfirmPassword)
            {
                return this.Error("Passwords don't match.");
            }
            this.usersService.Create(input.Username,
                                     input.Email,
                                     input.Password);
            return this.Redirect("/Users/Login");
        }

        public HttpResponse Logout()
        {
            this.SignOut();
            return this.Redirect("/");
        }
    }
}
