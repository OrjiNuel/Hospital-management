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
    public class EmployeeController : Controller
    {
        public EmployeeController() { }

        private IEmployeeRepository _empRepo;
        private IEmployeeTypeRepository _empTypeRepo;

        public EmployeeController(IEmployeeRepository employeeRepo, IEmployeeTypeRepository employeeTypeRepo)
        {
            this._empRepo = employeeRepo;
            this._empTypeRepo = employeeTypeRepo;
        }

        public ActionResult Index()
        {
            EmployeeListViewModel model = new EmployeeListViewModel();

            model.Employees = _empRepo.GetAllEmployees;
           
            model.EmployeeTypes = _empTypeRepo.GetAllEmployeeTypes;

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var employee = _empRepo.GetEmployeeById(id);
            return View(employee);
        }

        public ActionResult Create()
        {
            var employeetTypes = _empTypeRepo.GetAllEmployeeTypes;
            var empType_list = new List<SelectListItem>();
            foreach (var emtype in employeetTypes)
            {
                empType_list.Add(new SelectListItem { Value = emtype.ID.ToString(), Text = emtype.TypeName });
            }
            ViewBag.empType_list = empType_list;

            return View(new Employee());
        }
        [HttpPost]
        public ActionResult Create(Employee employee)
        {
            try
            {
                var employeetTypes = _empTypeRepo.GetAllEmployeeTypes;
                var empType_list = new List<SelectListItem>();
                foreach (var emtype in employeetTypes)
                {
                    empType_list.Add(new SelectListItem { Value = emtype.ID.ToString(), Text = emtype.TypeName });
                }
                ViewBag.empType_list = empType_list;

                if (ModelState.IsValid)
                {
                    _empRepo.SaveEmployee(employee);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(employee);
        }

        public ActionResult Edit(int id)
        {
            Employee employee = _empRepo.GetEmployeeById(id);

            var employeetTypes = _empTypeRepo.GetAllEmployeeTypes;
            var empType_list = new List<SelectListItem>();
            foreach (var emtype in employeetTypes)
            {
                empType_list.Add(new SelectListItem { Value = emtype.ID.ToString(), Text = emtype.TypeName });
            }
            ViewBag.empType_list = empType_list;

            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            try
            {
                var employeetTypes = _empTypeRepo.GetAllEmployeeTypes;
                var empType_list = new List<SelectListItem>();
                foreach (var emtype in employeetTypes)
                {
                    empType_list.Add(new SelectListItem { Value = emtype.ID.ToString(), Text = emtype.TypeName });
                }
                ViewBag.empType_list = empType_list;

                if (ModelState.IsValid)
                {
                    _empRepo.UpdateEmployee(employee);

                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(employee);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {

            EmployeeActionViewModel model = new EmployeeActionViewModel();

            var employee = _empRepo.GetEmployeeById(ID);

            model.ID = employee.ID;

            return PartialView("_Delete", model);
        }


        [HttpPost]
        public JsonResult Delete(EmployeeActionViewModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var employee = _empRepo.GetEmployeeById(model.ID);

            _empRepo.DeleteEmployee(employee);

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