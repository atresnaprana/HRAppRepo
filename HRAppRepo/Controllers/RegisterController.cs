using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HRAppRepo.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using System.Web;
using Firebase.Auth;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Owin;

namespace HRAppRepo.Controllers
{
    public class RegisterController : Controller
    {
        private static string apiKey = "AIzaSyBZcrxGT-CbftnpTCGoby_fBpi-Juq8XTw";

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            try
            {
                var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                var a = await auth.CreateUserWithEmailAndPasswordAsync(model.Email, model.Password, model.Name);
                ModelState.AddModelError(string.Empty, "Please Verify your Email");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);

            }
            return View();
        }
    }
}
