using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Endava.iAcademy.Domain;
using Endava.iAcademy.Repository;
using Endava.iAcademy.Repository.Repositories;
using Endava.iAcademy.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Endava.iAcademy.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUsersRepository _usersRepository;

        public AccountController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }


        [HttpGet]
        public IActionResult AccessDenied()
        {
            return Unauthorized("You must be an admin");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _usersRepository.CheckUserPassword(model.Password, model.Email);
                if (user != null)   
                {
                    await Authenticate(model.Email, user.Id, user.Role); // autentificare

                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Incorrect login or password");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _usersRepository.GetUserByEmail(model.Email);

                if (user == null)
                {
                    var userToRegister = new User()
                    {
                        Email = model.Email,
                        Password =  model.Password,
                        RoleId = RolesConstants.Customer.Id,
                    };

                    // adaugam userul in db
                    var domainUser = _usersRepository.RegisterUser(userToRegister);

                    await Authenticate(model.Email, domainUser.Id, domainUser.Role); // autentificare

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect login or password");
            }
            return View(model);
        }
        private async Task Authenticate(string userName, int userId, Role role)
        {
            // CLAIM - obiectul claim ne ofera o informatie oarecare despre user , ce putem sa o folosim pentru autorizarea in aplicatie.
            //Issuer: "Proprietare" sau denumirea sistemului , care ne-a dat claim
            //Subject: ClaimsIdentity returneaza informatia despre utilizator intr-un obiect ClaimsIdentity
            // Type: returneaza tipul obiectului claim
            //Value: returneaza valoarea obiectului claim

            //Cu ajutorul obiectului ClaimsIdentity , care returneaza user.identity , noi putem manipula obiectele claim de la userul curent.
            

            // cream un claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userName),
            };
            
            claims.Add(new Claim(ClaimsIdentity.DefaultRoleClaimType, role.Name));
            claims.Add(new Claim(ClaimTypes.PrimarySid, userId.ToString()));

            // cream obiectul ClaimsIdentity
            ClaimsIdentity identity = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // instalam Authentification cookie
            //Obiectul creat ClaimsIdentity se transmite in constructorul ClaimsPrincipal. Care defapt obiectul ClaimsPrincipal o sa ne arate aceea
            //ce noi v-om obtine in orice controller prin HttpContext.User.
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
