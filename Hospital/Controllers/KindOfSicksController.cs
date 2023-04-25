using OA.DTO.Auths;
using OA.DTO.KindOfSicks;
using OA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{    
    public class KindOfSicksController : Controller
    {
        private readonly CoreContext context;
        public KindOfSicksController()
        {
            context = new CoreContext();
        }
        public ActionResult Index()
        {
            var models = context.LoaiBenhs.Where(w => w.IsActive).Select(z => new KindOfSickDTO
            {
                Id = z.Id,
                Code = z.Code,
                Name = z.Name,
                Description = z.Description,
                CreatedAt = z.CreatedAt,
                CreatedBy = z.CreatedBy,
                UpdatedAt = z.UpdatedAt,
                UpdatedBy = z.UpdatedBy,
                IsActive = z.IsActive,
                IsDelete = z.IsDelete
            }).ToList();

            return View(models);
        }

        public ActionResult New() 
        {
            var model = new KindOfSickDTO();
            return View(model);
        }

        [HttpPost]
        public ActionResult New(KindOfSickDTO model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            var Seq = context.LoaiBenhs.Count(z => z.IsActive) + 1;
            var Code = string.Format("{0:D4}", Seq);
            context.LoaiBenhs.Add(new OA.Entities.LoaiBenh.LoaiBenhEntities
            {
                Code = Code,
                Name = model.Name,
                Description = model.Description,
                CreatedAt = DateTime.Now,
                IsActive = true,
                UpdatedAt = DateTime.Now
            });
            var Result = context.SaveChanges();
            if(Result == 1)
            {
                TempData["MessagesSuccessful"] = "Create successful disease information.";
                return RedirectToAction("Index", "KindOfSicks");
            }
            else
            {
                TempData["MessagesError"] = "Create disease type information failure";
                return View(model);
            }    
        }

        public ActionResult Edit(int id)
        {
            var model = context.LoaiBenhs.Where(w => w.Id == id).Select(z => new KindOfSickDTO
            {
                Id = z.Id,
                Code = z.Code,
                Name = z.Name,
                Description = z.Description,
                CreatedAt = z.CreatedAt,
                CreatedBy = z.CreatedBy,
                UpdatedAt = z.UpdatedAt,
                UpdatedBy = z.UpdatedBy,
                IsActive = z.IsActive,
                IsDelete = z.IsDelete
            }).FirstOrDefault();
            if (model == null)
            {
                model = new KindOfSickDTO();
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(KindOfSickDTO model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var entities = context.LoaiBenhs.FirstOrDefault(z => z.Id == model.Id);
            entities.Name = model.Name;
            entities.Description = model.Description;
            entities.IsActive = model.IsActive;
            entities.UpdatedAt = DateTime.Now;
            var Response = context.SaveChanges();
            if (Response == 1)
            {
                TempData["MessagesSuccessful"] = "Edit successful disease information.";
                return RedirectToAction("Index", "KindOfSicks");
            }
            else
            {
                TempData["MessagesError"] = "Edit disease type information failure";
                return View(model);
            }
        }

        public ActionResult Destroy(int id)
        {
            var entity = context.LoaiBenhs.FirstOrDefault(z => z.Id == id);
            if (entity != null)
            {
                entity.IsDelete = true;
                entity.IsActive = false;
                entity.UpdatedAt = DateTime.Now;
                var Response = context.SaveChanges();
                if (Response >= 1)
                {
                    return Json(new { success = true, message = "Successful disease eradication!" }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { success = false, message = "Can't delete disease type." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Can't delete disease type." }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}