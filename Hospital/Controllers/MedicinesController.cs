using OA.DTO.Medicines;
using OA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class MedicinesController : Controller
    {
        
        public ActionResult Index()
        {
            using(var context = new CoreContext())
            {
                var models = context.Medicines.Where(z => z.IsDelete == false).Select(z => new MedicinesDTO
                {
                    Id = z.Id,
                    GiaBan = z.GiaBan,
                    GiaNhap = z.GiaNhap,
                    Name = z.Name,
                    NgayNhap = z.NgayNhap,
                    Code = z.Code,
                    IsActive = z.IsActive,
                    Quantity = z.Quantity
                }).ToList();

                return View(models);
            }
        }

        public ActionResult New()
        {
            var model = new MedicinesDTO();
            return View(model);
        }

        [HttpPost]
        public ActionResult New(MedicinesDTO model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using(var context = new CoreContext())
            {
                var Seq = context.Medicines.Count(z => z.IsActive) + 1;
                var Code = string.Format("{0:D4}", Seq);
                context.Medicines.Add(new OA.Entities.Medicine.MedicineEntities
                {
                    Name = model.Name,
                    Code = Code,
                    GiaBan = model.GiaBan,
                    GiaNhap = model.GiaNhap,
                    IsActive = true,
                    NgayNhap = model.NgayNhap,
                    Quantity = model.Quantity,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                });
                var Result = context.SaveChanges();
                if(Result == 1)
                {
                    TempData["MessagesSuccessful"] = "Create drug information successfully.";
                    return RedirectToAction("Index", "Medicines");
                }
                else
                {
                    TempData["MessagesError"] = "Create drug information failed";
                    return View(model);
                }
            }
           
        }

        public ActionResult Edit(int Id)
        {
            using(var context = new CoreContext())
            {
                var model = context.Medicines.Where(z => z.Id == Id).Select(z => new MedicinesDTO
                {
                    Id = z.Id,
                    GiaBan = z.GiaBan,
                    GiaNhap = z.GiaNhap,
                    Name = z.Name,
                    NgayNhap = z.NgayNhap,
                    Code = z.Code,
                    IsActive = z.IsActive,
                    Quantity = z.Quantity
                }).FirstOrDefault();
                return View(model);
            }
        }

        [HttpPost]
        public ActionResult Edit(MedicinesDTO model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using(var context = new CoreContext())
            {
                var Entity = context.Medicines.Find(model.Id);
                Entity.Name = model.Name;
                Entity.NgayNhap = model.NgayNhap;
                Entity.GiaBan = model.GiaBan;
                Entity.GiaNhap = model.GiaNhap;
                Entity.Quantity = model.Quantity;
                Entity.UpdatedAt = DateTime.Now;

                var Result = context.SaveChanges();
                if(Result >= 0)
                {
                    TempData["MessagesSuccessful"] = "Edit drug information successfully.";
                    return RedirectToAction("Index", "Medicines");
                }
                else
                {
                    TempData["MessagesError"] = "Edit drug information failed\r\n";
                    return View(model);
                }
            }
        }

        public ActionResult Destroy(int Id)
        {
            using (var context = new CoreContext())
            {
                var entity = context.Medicines.FirstOrDefault(z => z.Id == Id);
                if (entity != null)
                {
                    entity.IsDelete = true;
                    entity.IsActive = false;
                    entity.UpdatedAt = DateTime.Now;
                    var Response = context.SaveChanges();
                    if (Response >= 1)
                    {
                        return Json(new { success = true, message = "Delete drug information successfully" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Can not delete drug information." }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Không thể Delete information thuốc." }, JsonRequestBehavior.AllowGet);
                }
            }
        }
    }
}