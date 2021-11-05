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
    public class LoginController : Controller
    {
        private static string apiKey = "AIzaSyBZcrxGT-CbftnpTCGoby_fBpi-Juq8XTw";
        public IActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logins(LoginModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var auth = new FirebaseAuthProvider(new FirebaseConfig(apiKey));
                    var a = await auth.SignInWithEmailAndPasswordAsync(model.Email, model.Password);
                    string token = a.FirebaseToken;
                    var user = a.User;
                    if (!string.IsNullOrEmpty(token))
                    {
                        SignInUser(model.Email, token, true);
                        RedirectToAction("Index","Home");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "not detected");

                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return View();
        }
        private void SignInUser(string email, string token, bool isPersistent)
        {
            var claims = new List<Claim>();
            try
            {
                claims.Add(new Claim(ClaimTypes.Email, email));
                claims.Add(new Claim(ClaimTypes.Name, email));
                claims.Add(new Claim(ClaimTypes.Authentication, token));
                var claimidens = new ClaimsIdentity(claims);
                //var test = HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(claimidens));

                var grandmaIdentity = new ClaimsIdentity(claims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                var test = HttpContext.SignInAsync(userPrincipal);
                var status = test.Status;
                var testdata = test.IsCompleted;
                //var ctx = HttpContext.SignInAsync(claimidens);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void abandonsess()
        {
            HttpContext.Session.Clear();
        }
        private void SignOut(string email, string token, bool isPersistent)
        {
            var claims = new List<Claim>();
            try
            {
                claims.Add(new Claim(ClaimTypes.Email, email));
                claims.Add(new Claim(ClaimTypes.Name, email));
                claims.Add(new Claim(ClaimTypes.Authentication, token));
                var claimidens = new ClaimsIdentity(claims);
                //var test = HttpContext.SignInAsync(IdentityConstants.ApplicationScheme, new ClaimsPrincipal(claimidens));

                var grandmaIdentity = new ClaimsIdentity(claims, "User Identity");

                var userPrincipal = new ClaimsPrincipal(new[] { grandmaIdentity });
                var test = HttpContext.SignInAsync(userPrincipal);
                var status = test.Status;
                var testdata = test.IsCompleted;
                HttpContext.SignOutAsync(token);
                //var ctx = HttpContext.SignInAsync(claimidens);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
