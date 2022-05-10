using NuelClinics.Areas.Admin.Models;
using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NuelClinics.Areas.Admin.Controllers
{
    public class ServiceController : Controller
    {
        private IServiceRepository _serveRepo;

        public ServiceController(IServiceRepository serviceRepo)
        {
            this._serveRepo = serviceRepo;
        }
        public ActionResult Index()
        {
            ServiceListViewModel model = new ServiceListViewModel
            {
                Services = _serveRepo.GetAllServices
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var service = _serveRepo.GetServiceById(id);
            return View(service);
        }

        public ActionResult Create()
        {
            return View(new Service());
        }
        [HttpPost]
        public ActionResult Create(Service service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serveRepo.SaveService(service);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(service);
        }

        public ActionResult Edit(int id)
        {
            Service service = _serveRepo.GetServiceById(id);
            return View(service);
        }
        [HttpPost]
        public ActionResult Edit(Service service)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _serveRepo.UpdateService(service);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(service);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {

            ServiceActionViewModel model = new ServiceActionViewModel();

            var service = _serveRepo.GetServiceById(ID);

            model.ID = service.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(ServiceActionViewModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var service = _serveRepo.GetServiceById(model.ID);

            _serveRepo.DeleteService(service);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Service." };
            }

            return json;
        }

    }
}