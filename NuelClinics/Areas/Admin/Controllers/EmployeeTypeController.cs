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
    public class EmployeeTypeController : Controller
    {
        public EmployeeTypeController() { }

        private IEmployeeTypeRepository _empTypeRepo;

        public EmployeeTypeController(IEmployeeTypeRepository typeRepository)
        {
            this._empTypeRepo = typeRepository;
        }

        public ActionResult Index()
        {
            EmployeeTypeListViewModel model = new EmployeeTypeListViewModel
            {
                EmployeeTypes = _empTypeRepo.GetAllEmployeeTypes
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var employeeType = _empTypeRepo.GetEmployeeTypeById(id);
            return View(employeeType);
        }

        public ActionResult Create()
        {
            return View(new EmployeeType());
        }
        [HttpPost]
        public ActionResult Create(EmployeeType employeeType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empTypeRepo.SaveEmployeeType(employeeType);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(employeeType);
        }

        public ActionResult Edit(int id)
        {
            EmployeeType employeeType = _empTypeRepo.GetEmployeeTypeById(id);
            return View(employeeType);
        }
        [HttpPost]
        public ActionResult Edit(EmployeeType employeeType)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empTypeRepo.UpdateEmployeeType(employeeType);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(employeeType);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {

            EmployeeTypeActionViewModel model = new EmployeeTypeActionViewModel();

            var employeeType = _empTypeRepo.GetEmployeeTypeById(ID);

            model.ID = employeeType.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(EmployeeTypeActionViewModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var employeeType = _empTypeRepo.GetEmployeeTypeById(model.ID);

            _empTypeRepo.DeleteEmployeeType(employeeType);

            if (result)
            {
                json.Data = new { Success = true };
            }
            else
            {
                json.Data = new { Success = false, Message = "Unable to perform action on Department." };
            }

            return json;
        }

    }
}