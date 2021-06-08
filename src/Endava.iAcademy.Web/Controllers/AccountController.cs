using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Endava.iAcademy.Domain;
using Endava.iAcademy.Repository;
using Endava.iAcademy.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

namespace Endava.iAcademy.Web.Controllers
{
    public class AccountController : Controller
    {
        private EndavaiAcademyDbContext db;
        public AccountController(EndavaiAcademyDbContext context)
        {
            db = context;
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
                // TODO: Extract this into IUsersRepository.CheckUserPassword
                User user = await db.Users
                    .Include(x => x.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email && u.Password == model.Password);

                if (user != null)   
                {
                    await Authenticate(model.Email, user.Role); // autentificare

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
                // TODO: Extract this into IUsersRepository.GetUserByEmail
                User user = await db.Users
                    .Include(x => x.Role)
                    .FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user == null)
                {
                    // adaugam userul in db
                    // TODO: Extract this into IUsersRepository.RegisterUser
                    var domainUser = new User
                    {
                        RoleId = RolesConstants.Customer.Id, // Admin by default
                        Email = model.Email,
                        Password = model.Password,
                    };
                    
                    db.Users.Add(domainUser);

                    await db.SaveChangesAsync();

                    await Authenticate(model.Email, user.Role); // autentificare

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Incorrect login or password");
            }
            return View(model);
        }
        private async Task Authenticate(string userName, Role role)
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

            // cream obiectul ClaimsIdentity
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            // instalam Authentification cookie
            //Obiectul creat ClaimsIdentity se transmite in constructorul ClaimsPrincipal. Care defapt obiectul ClaimsPrincipal o sa ne arate aceea
            //ce noi v-om obtine in orice controller prin HttpContext.User.
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
