using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Entities;
using NuelClinics.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuelClinics.Controllers
{
    public class AppointmentController : Controller
    {
        public AppointmentController() { }

        private IAppointmentRepository _appRepo;
        private IServiceRepository _serveRepo;

        public AppointmentController(IAppointmentRepository appRepository, IServiceRepository serveRepository)
        {
            this._appRepo = appRepository;
            this._serveRepo = serveRepository;
        }

        public ActionResult Index()
        {
            AppointmentViewModel model = new AppointmentViewModel();

            model.Appointments = _appRepo.GetAllAppointments;

            model.Services = _serveRepo.GetAllServices;

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var appointment = _appRepo.GetAppointmentById(id);
            return View(appointment);
        }

        public ActionResult Create()
        {
            var services = _serveRepo.GetAllServices;
            var service_list = new List<SelectListItem>();
            foreach (var serve in services)
            {
                service_list.Add(new SelectListItem { Value = serve.ID.ToString(), Text = serve.Name });
            }
            ViewBag.service_list = service_list;

            return View(new Appointment());
        }
        [HttpPost]
        public ActionResult Create(Appointment appointment)
        {
            try
            {
                var services = _serveRepo.GetAllServices;
                var service_list = new List<SelectListItem>();
                foreach (var serve in services)
                {
                    service_list.Add(new SelectListItem { Value = serve.ID.ToString(), Text = serve.Name });
                }
                ViewBag.service_list = service_list;

                if (ModelState.IsValid)
                {
                    _appRepo.SaveAppointment(appointment);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(appointment);
        }

        public ActionResult Edit(int id)
        {
            Appointment appointment = _appRepo.GetAppointmentById(id);

            var services = _serveRepo.GetAllServices;
            var service_list = new List<SelectListItem>();
            foreach (var serve in services)
            {
                service_list.Add(new SelectListItem { Value = serve.ID.ToString(), Text = serve.Name });
            }
            ViewBag.service_list = service_list;

            return View(appointment);
        }
        [HttpPost]
        public ActionResult Edit(Appointment appointment)
        {
            try
            {
                var services = _serveRepo.GetAllServices;
                var service_list = new List<SelectListItem>();
                foreach (var serve in services)
                {
                    service_list.Add(new SelectListItem { Value = serve.ID.ToString(), Text = serve.Name });
                }
                ViewBag.service_list = service_list;

                if (ModelState.IsValid)
                {
                    _appRepo.UpdateAppointment(appointment);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(appointment);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {

            AppointmentActionViewModel model = new AppointmentActionViewModel();

            var appointment = _appRepo.GetAppointmentById(ID);

            model.ID = appointment.ID;

            return PartialView("_Delete", model);
        }


        [HttpPost]
        public JsonResult Delete(AppointmentActionViewModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var appointment = _appRepo.GetAppointmentById(model.ID);

            _appRepo.DeleteAppointment(appointment);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Employment." };
            }

            return json;
        }

    }
}