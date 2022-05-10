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
    public class DepartmentController : Controller
    {
        public DepartmentController() { }

        private IDepartmentRepository _deptRepo;

        public DepartmentController(IDepartmentRepository deptRepository)
        {
            this._deptRepo = deptRepository;
        }

        public ActionResult Index()
        {
            DepartmentListViewModel model = new DepartmentListViewModel
            {
                Departments = _deptRepo.GetAllDepartments
            };
            return View(model);
        }

        public ActionResult Details(int id)
        {
            var department = _deptRepo.GetDepartmentById(id);
            return View(department);
        }

        public ActionResult Create()
        {
            return View(new Department());
        }
        [HttpPost]
        public ActionResult Create(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _deptRepo.SaveDepartment(department);
                    
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(department);
        }

        public ActionResult Edit(int id)
        {
            Department department = _deptRepo.GetDepartmentById(id);
            return View(department);
        }
        [HttpPost]
        public ActionResult Edit(Department department)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _deptRepo.UpdateDepartment(department);
                    
                    return RedirectToAction("Index");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(department);
        }

        [HttpGet]
        public ActionResult Delete(int ID)
        {

            DepartmentActionViewModel model = new DepartmentActionViewModel();

            var department = _deptRepo.GetDepartmentById(ID);

            model.ID = department.ID;

            return PartialView("_Delete", model);
        }

        [HttpPost]
        public JsonResult Delete(DepartmentActionViewModel model)
        {
            JsonResult json = new JsonResult();

            var result = false;

            var department = _deptRepo.GetDepartmentById(model.ID);

            _deptRepo.DeleteDepartment(department);

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