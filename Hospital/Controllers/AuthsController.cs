using OA.DTO.Auths;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OA.Entities;

namespace Hospital.Controllers
{
    public class AuthsController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModels model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using (var _context = new CoreContext())
            {
                var User = _context.Users.Where(z => z.IsActive && z.Email == model.Email && z.Password == model.Password)
                                        .Select(z => new UsersDTO
                                        {
                                            Id = z.Id,
                                            Name = z.Name,
                                            Email = z.Email
                                        }).FirstOrDefault();

                if (User != null)
                {
                    TempData["MessagesSuccessful"] = "Logged in successfully.";
                    Session["Users"] = User;
                }
                else
                {
                    TempData["MessagesError"] = "Login information is incorrect.";
                    return View(model);
                }
            }

            return RedirectToAction("Index", "Home");
        }
    }
}