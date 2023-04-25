using OA.DTO.Auths;
using OA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class UsersController : Controller
    {
        public ActionResult Index()
        {
            using(var context = new CoreContext())
            {
                var models = context.Users.Where(z => z.IsDelete == false).Select(z => new UsersDTO
                {
                    Id = z.Id,
                    Code = z.Code,
                    Name = z.Name,
                    Address = z.Address,
                    DateOfBirth = z.DateOfBirth,
                    Email = z.Email,
                    Gender = z.Gender,
                    Phone = z.Phone,
                    Password = z.Password,
                    Position = z.Position
                }).ToList();

                return View(models);
            }
        }

        public ActionResult New() 
        {
            var model = new UsersDTO();
            return View(model);
        }

        [HttpPost]
        public ActionResult New(UsersDTO model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using(var context = new CoreContext())
            {
                var EmailExists = context.Users.Any(z => z.Email == model.Email && z.IsActive);
                if(EmailExists)
                {
                    ModelState.AddModelError("Email", "Email exist.");
                    return View(model);
                }
                var Seq = context.Users.Count(z => z.IsActive) + 1;
                var Code = string.Format("{0:D4}", Seq);
                context.Users.Add(new OA.Entities.Users.UsersEntities
                {
                    Code = Code,
                    Name = model.Name,
                    Address = model.Address,
                    CreatedAt = DateTime.Now,
                    DateOfBirth = model.DateOfBirth,
                    Email = model.Email,
                    Gender = model.Gender,
                    IsActive = true,
                    Password = model.Password,
                    Phone = model.Phone,
                    Position = model.Position,
                    UpdatedAt = DateTime.Now
                });
                var Result = context.SaveChanges();
                if(Result == 1)
                {
                    TempData["MessagesSuccessful"] = "Create successful employee information.";
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    TempData["MessagesError"] = "Create employee information failed";
                    return View(model);
                }
            }          
        }

        public ActionResult Edit(int Id)
        {
            using(var context = new CoreContext())
            {
                var model = context.Users.Where(z => z.Id == Id).Select(z => new UsersDTO
                {
                    Id = z.Id,
                    Name = z.Name,
                    Code = z.Code,
                    Address = z.Address,
                    Email = z.Email,
                    Gender = z.Gender,
                    IsActive = z.IsActive,
                    Phone = z.Phone,
                    DateOfBirth = z.DateOfBirth,
                    Position = z.Position,
                    Password = z.Password
                }).FirstOrDefault();

                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(UsersDTO model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using(var context = new CoreContext())
            {
                var Entity = context.Users.Find(model.Id);
                Entity.Name = model.Name;
                Entity.Address = model.Address;
                Entity.Gender = model.Gender;
                Entity.Position = model.Position;
                Entity.Phone = model.Phone;
                Entity.UpdatedAt = DateTime.Now;

                var Result = context.SaveChanges();
                if(Result >= 0)
                {
                    TempData["MessagesSuccessful"] = "Edit successful employee information.";
                    return RedirectToAction("Index", "Users");
                }
                else
                {
                    TempData["MessagesError"] = "Edit employee information failed";
                    return View(model);
                }
            }
        }


        public ActionResult Destroy(int Id)
        {
            using(var context = new CoreContext())
            {
                var entity = context.Users.FirstOrDefault(z => z.Id == Id);
                if (entity != null)
                {
                    entity.IsDelete = true;
                    entity.IsActive = false;
                    entity.UpdatedAt = DateTime.Now;
                    var Response = context.SaveChanges();
                    if (Response >= 1)
                    {
                        return Json(new { success = true, message = "Delete successful employee information!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Unable to delete employee information." }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Unable to delete employee information." }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}