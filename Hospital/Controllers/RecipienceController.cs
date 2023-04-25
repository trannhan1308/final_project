using OA.DTO.Auths;
using OA.DTO.KindOfSicks;
using OA.DTO.Medicines;
using OA.DTO.Patients;
using OA.DTO.Recipiences;
using OA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{    
    public class RecipienceController : Controller
    {
        private readonly CoreContext context;
        public RecipienceController()
        {
            context = new CoreContext();
        }
        public ActionResult Index()
        {
            var models = context.Recipiences.Where(z => z.IsDelete == false)
                    .Select(z => new RecipienceViewDTO
                    {
                        Id = z.Id,
                        Name = z.Name,
                        Description = z.Description
                    }).ToList();

            return View(models);
        }

        public ActionResult New() 
        {
            var model = new RecipienceDTO();
            ViewBag.Patients = context.Patients.Where(z => z.IsDelete == false)
                    .Select(z => new PatientsDTO
                    {
                        Id = z.Id,
                        Name = z.Name
                    }).ToList();
            ViewBag.Medicines = context.Medicines.Where(z => z.IsDelete == false)
                    .Select(z => new MedicinesDTO
                    {
                        Id = z.Id,
                        Name = z.Name
                    }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult New(RecipienceDTO model)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.Patients = context.Patients.Where(z => z.IsDelete == false)
                       .Select(z => new PatientsDTO
                       {
                           Id = z.Id,
                           Name = z.Name
                       }).ToList();
                ViewBag.Medicines = context.Medicines.Where(z => z.IsDelete == false)
                    .Select(z => new MedicinesDTO
                    {
                        Id = z.Id,
                        Name = z.Name
                    }).ToList();
                return View(model);
            }
            var Seq = context.Recipiences.Count(z => z.IsActive) + 1;
            var Code = string.Format("{0:D4}", Seq);
            // Add toa thuốc
            var Recipience = new OA.Entities.Recipience.RecipienceEntities
            {
                Name = model.Name,
                PatientId = model.PatientId,
                Description = model.Description,
                CreatedAt = DateTime.Now,
                IsActive = true,
                UpdatedAt = DateTime.Now
            };
            context.Recipiences.Add(Recipience);
            var Result = context.SaveChanges();
            if(Result == 1)
            {
                //Kiểm tra và lưu chi tiết toa thuốc
                if (model.Medicine != null && model.Medicine.Any())
                {
                    model.Medicine = model.Medicine.GroupBy(g => g.Id).Select(s => new MedicinesDTO()
                    {
                        Id = s.Key,
                        Quantity = s.Select(s1 => s1.Quantity).FirstOrDefault(),
                        GiaBan = s.Select(s1 => s1.GiaBan).FirstOrDefault()
                    }).ToList();
                    foreach (var item in model.Medicine)
                    {
                        context.RecipienceDetails.Add(new OA.Entities.RecipienceDetail.RecipienceDetailEntities
                        {
                            RecipienceId = Recipience.Id,
                            MedicineId = item.Id,
                            Quantity = item.Quantity,
                            Price = item.GiaBan,
                            CreatedAt = DateTime.Now,
                            IsActive = true,
                            UpdatedAt = DateTime.Now
                        });
                    }
                }
                context.SaveChanges();
                return RedirectToAction("Index", "Recipience");
            }
            else
            {
                ViewBag.Patients = context.Patients.Where(z => z.IsDelete == false)
                       .Select(z => new PatientsDTO
                       {
                           Id = z.Id,
                           Name = z.Name
                       }).ToList();
                ViewBag.Medicines = context.Medicines.Where(z => z.IsDelete == false)
                    .Select(z => new MedicinesDTO
                    {
                        Id = z.Id,
                        Name = z.Name
                    }).ToList();
                TempData["MessagesError"] = "Create disease type information failure";
                return View(model);
            }    
        }

        public ActionResult Edit(int id)
        {
            var model = context.Recipiences.Where(z => z.IsDelete == false && z.Id == id)
                   .Select(z => new RecipienceDTO
                   {
                       Id = z.Id,
                       Name = z.Name,
                       PatientId = z.PatientId,
                       Description = z.Description
                   }).FirstOrDefault();
            var modelDetail = context.RecipienceDetails.Join(context.Medicines, r => r.MedicineId, m => m.Id, (r, m) => new { r, m })
                    .Where(z => z.r.IsDelete == false && z.r.RecipienceId == id)
                    .Select(z => new MedicinesDTO
                    {
                        Id = z.m.Id,
                        Name = z.m.Name,
                        Quantity = z.r.Quantity,
                        GiaBan = z.m.GiaBan
                    }).ToList();
            if (model == null)
            {
                model = new RecipienceDTO();
            }
            else
            {
                model.Medicine.AddRange(modelDetail);
            }
            ViewBag.Patients = context.Patients.Where(z => z.IsDelete == false)
                       .Select(z => new PatientsDTO
                       {
                           Id = z.Id,
                           Name = z.Name
                       }).ToList();
            ViewBag.Medicines = context.Medicines.Where(z => z.IsDelete == false)
                    .Select(z => new MedicinesDTO
                    {
                        Id = z.Id,
                        Name = z.Name
                    }).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(RecipienceDTO model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Patients = context.Patients.Where(z => z.IsDelete == false)
                       .Select(z => new PatientsDTO
                       {
                           Id = z.Id,
                           Name = z.Name
                       }).ToList();
                ViewBag.Medicines = context.Medicines.Where(z => z.IsDelete == false)
                    .Select(z => new MedicinesDTO
                    {
                        Id = z.Id,
                        Name = z.Name
                    }).ToList();
                return View(model);
            }
            var entities = context.Recipiences.FirstOrDefault(z => z.Id == model.Id);
            entities.Name = model.Name;
            entities.PatientId = model.PatientId;
            entities.Description = model.Description;
            entities.IsActive = model.IsActive;
            entities.UpdatedAt = DateTime.Now;
            var Response = context.SaveChanges();
            if (Response == 1)
            {
                var entityDetail = context.RecipienceDetails.Where(z => z.RecipienceId == model.Id);
                context.RecipienceDetails.RemoveRange(entityDetail);
                context.SaveChanges();
                //Kiểm tra và lưu chi tiết toa thuốc
                if (model.Medicine != null && model.Medicine.Any())
                {
                    model.Medicine = model.Medicine.GroupBy(g => g.Id).Select(s => new MedicinesDTO()
                    {
                        Id = s.Key,
                        Quantity = s.Select(s1=>s1.Quantity).FirstOrDefault(),
                        GiaBan = s.Select(s1 => s1.GiaBan).FirstOrDefault()
                    }).ToList();
                    foreach (var item in model.Medicine)
                    {
                        context.RecipienceDetails.Add(new OA.Entities.RecipienceDetail.RecipienceDetailEntities
                        {
                            RecipienceId = model.Id,
                            MedicineId = item.Id,
                            Quantity = item.Quantity,
                            Price = item.GiaBan,
                            CreatedAt = DateTime.Now,
                            IsActive = true,
                            UpdatedAt = DateTime.Now
                        });
                    }
                    context.SaveChanges();
                }
                return RedirectToAction("Index", "Recipience");
            }
            else
            {
                ViewBag.Patients = context.Patients.Where(z => z.IsDelete == false)
                       .Select(z => new PatientsDTO
                       {
                           Id = z.Id,
                           Name = z.Name
                       }).ToList();
                ViewBag.Medicines = context.Medicines.Where(z => z.IsDelete == false)
                    .Select(z => new MedicinesDTO
                    {
                        Id = z.Id,
                        Name = z.Name
                    }).ToList();
                TempData["MessagesError"] = "Edit disease type information failure\r\n";
                return View(model);
            }
        }

        public ActionResult Destroy(int id)
        {
            var entityDetail = context.RecipienceDetails.Where(z => z.MedicineId == id);
            context.RecipienceDetails.RemoveRange(entityDetail);
            var result = context.SaveChanges();
            if (result == 1)
            {
                var entity = context.Recipiences.FirstOrDefault(z => z.Id == id);
                if (entity != null)
                {
                    context.Recipiences.Remove(entity);
                    var Response = context.SaveChanges();
                    if (Response >= 1)
                    {
                        return Json(new { success = true, message = "Delete patient information successfully!" }, JsonRequestBehavior.AllowGet);
                    }
                    else
                    {
                        return Json(new { success = false, message = "Can not delete patient information." }, JsonRequestBehavior.AllowGet);
                    }
                }
                else
                {
                    return Json(new { success = false, message = "Can not delete patient information." }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                return Json(new { success = false, message = "Can not delete patient information." }, JsonRequestBehavior.AllowGet);
            }            
        }
    }
}