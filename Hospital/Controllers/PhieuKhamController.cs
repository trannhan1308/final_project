using OA.DTO.Auths;
using OA.DTO.PhieuKhams;
using OA.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Hospital.Controllers
{
    public class PhieuKhamController : Controller
    {
        public ActionResult Index()
        {
            using(var context = new CoreContext())
            {
                var models = context.PhieuKhams.Join(context.Users, p => p.DoctorId, u => u.Id, (p, u) => new { p, u })
                    .Join(context.Patients, p1 => p1.p.PatientId, pa => pa.Id, (p1, pa) => new { p = p1.p, u = p1.u, pa })
                    .Where(z => z.p.IsDelete == false)
                    .Select(z => new PhieuKhamViewDTO
                    {
                        Id = z.p.Id,
                        Code = z.p.Code,
                        CreatedAt = z.p.CreatedAt,
                        PatientName = z.pa.Name,
                        PatientId = z.pa.Id,
                        Price = z.p.Price,
                        TrieuChung = z.p.TrieuChung,
                        DoctorName = z.u.Name,
                        NgayTaiKham = z.p.NgayTaiKham
                    }).ToList();

                return View(models);
            }
            
        }
        public ActionResult New()
        {
            var model = new PhieuKhamsDTO();
            return View(model);
        }
        [HttpPost]
        public ActionResult New(PhieuKhamsDTO model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using(var context = new CoreContext())
            {
                var Seq = context.Patients.Count(z => z.IsActive) + 1;
                var Code = string.Format("{0:D4}", Seq);
                var Partient = new OA.Entities.Patient.PatientEntities
                {
                    Address = model.Patient.Address,
                    Code = Code,
                    CreatedAt = DateTime.Now,
                    Gender = model.Patient.Gender,
                    DateOfBirth = model.Patient.DateOfBirth,
                    IsActive = true,
                    Name = model.Patient.Name,
                    UpdatedAt = DateTime.Now,
                    Room = "201"
                };
                
                var Doctor = Session["Users"] as UsersDTO;
                Seq = context.PhieuKhams.Count(z => z.IsActive) + 1;
                Code = string.Format("{0:D4}", Seq);
                Partient.PhieuKhams.Add(new OA.Entities.PhieuKham.PhieuKhamEntities
                {
                    Code = Code,
                    CreatedAt = DateTime.Now,
                    IsActive = true,
                    PatientId = Partient.Id,
                    Price = model.Price,
                    TrieuChung = model.TrieuChung,
                    DoctorId = Doctor.Id,
                    UpdatedAt = DateTime.Now
                });
                context.Patients.Add(Partient);
                var Result = context.SaveChanges();
                if(Result >= 1)
                {
                    TempData["MessagesSuccessful"] = "Create a successful examination card.";
                    return RedirectToAction("Index", "PhieuKham");
                }
                else
                {
                    TempData["MessagesError"] = "Create a examination card fail";
                    return View(model);
                }
            }
        }

        public ActionResult PhieuHen(int patientId)
        {
            var model = new PhieuHenDTO();
            model.PatientId = patientId;
            return View(model);
        }

        [HttpPost]
        public ActionResult PhieuHen(PhieuHenDTO model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }
            using(var context = new CoreContext())
            {
                var Doctor = Session["Users"] as UsersDTO;
                var Seq = context.PhieuKhams.Count(z => z.IsActive) + 1;
                var Code = string.Format("{0:D4}", Seq);
                context.PhieuKhams.Add(new OA.Entities.PhieuKham.PhieuKhamEntities
                {
                    Code = Code,
                    CreatedAt = model.NgayHen,
                    IsActive = true,
                    PatientId = model.PatientId,
                    Price = model.Price,
                    TrieuChung = model.TrieuChung,
                    DoctorId = Doctor.Id,
                    UpdatedAt = DateTime.Now,
                    NgayTaiKham = model.NgayHen
                });
                var Result = context.SaveChanges();
                if (Result >= 1)
                {
                    TempData["MessagesSuccessful"] = "Create a successful examination card.";
                    return RedirectToAction("Index", "PhieuKham");
                }
                else
                {
                    TempData["MessagesError"] = "Appointment creation failed";
                    return View(model);
                }

            }
        }
    }
}