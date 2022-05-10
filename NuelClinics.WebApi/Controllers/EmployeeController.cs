using NuelClinics.Areas.Admin.Models;
using NuelClinics.Domain.Abstract;
using NuelClinics.Domain.Concrete;
using NuelClinics.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace NuelClinics.WebApi.Controllers
{
    public class EmployeeController : ApiController
    {
        public EmployeeController() { }

        private IEmployeeRepository _empRepo;

        public EmployeeController(IEmployeeRepository repository)
        {
            this._empRepo = repository;
        }

        [HttpGet]
        [Route("Employee/get")]
        public IHttpActionResult Get()
        {
            var emp = _empRepo.GetAllEmployees.ToList();
            return Ok(emp);
        }

        [HttpGet]
        [Route("Employee/get/{id}")]
        public Employee Get(int id)
        {
           return _empRepo.GetEmployeeById(id);
        }

        [HttpPost]
        [Route("Employee/post")]
        public IHttpActionResult Post([FromBody]Employee employee)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _empRepo.SaveEmployee(employee);

                    return Ok("Successfully added");
                }
                else
                {
                    return BadRequest("Error please check");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message.ToString());
            }
        }

        [HttpPut]
        [Route("Employee/{id}")]
        public IHttpActionResult Put(int id, [FromBody]Employee employee)
        {
            var emp = _empRepo.GetEmployeeById(id);

            emp.ID = employee.ID;
            emp.Name = employee.Name;
            emp.Phone = employee.Phone;
            emp.Email = employee.Email;
            emp.Address = employee.Address;
            emp.Date_Of_Birth = employee.Date_Of_Birth;
            emp.Age = employee.Age;
            emp.Start_Date = employee.Start_Date;
            emp.EmployeeTypeId = employee.EmployeeTypeId;

            _empRepo.UpdateEmployee(employee);

            return Ok("Successfully updated");
        }

        [HttpDelete]
        [Route("Employee/{id}")]
        public HttpResponseMessage Delete(int id)
        {
                var entity = _empRepo.GetAllEmployees.FirstOrDefault(e => e.ID == id);
                if (entity == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Employee with id=" + id.ToString() + "not found to delete");
                }
                else
                {
                    _empRepo.DeleteEmployee(entity);
                    return Request.CreateResponse(HttpStatusCode.OK, "Employee Successfully deleted!");
                }
          
        }

    }
}
