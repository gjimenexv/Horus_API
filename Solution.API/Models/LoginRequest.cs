using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Solution.API.Models
{
    public class LoginRequest
    {
        public string Usuario { get; set; }
        public string Contrasena { get; set; }
    }
    public class ResetPasswordEmail
    {
        public string Email { get; set; }
        public string Token { get; set; }
    }
    public class ResetPassword
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Token { get; set; }
    }
    public class ForgotPasswordViewModel
    {
        public string Email { get; set; }
    }
}