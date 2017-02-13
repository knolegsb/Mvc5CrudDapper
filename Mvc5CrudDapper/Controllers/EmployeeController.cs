using Mvc5CrudDapper.Models;
using Mvc5CrudDapper.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mvc5CrudDapper.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee/GetAllEmployeeDetails
        public ActionResult GetAllEmployeeDetails()
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            return View(empRepo.GetAllEmployees());
        }

        // GET: Employee/AddEmployee
        public ActionResult AddEmployee()
        {
            return View();
        }

        // POST: Employee/AddEmployee
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    EmployeeRepository empRepo = new EmployeeRepository();
                    empRepo.AddEmployee(emp);

                    ViewBag.Message = "Recortds added successfully.";
                }
                return View();
            }
            catch
            {
                return View();
            }
        }       

        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Details/5
        public ActionResult EditEmployeeDetails(int id)
        {
            EmployeeRepository empRepo = new EmployeeRepository();
            return View(empRepo.GetAllEmployees().Find(emp => emp.Id == id));
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult EditEmployeeDetails(int id, Employee obj)
        {
            try
            {
                EmployeeRepository empRepo = new EmployeeRepository();

                empRepo.UpdateEmployee(obj);

                return RedirectToAction("GetAllEmployeeDetails");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        //public ActionResult Delete(int id)
        //{
        //    return View();
        //}

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult DeleteEmployee(int id, FormCollection collection)
        {
            try
            {
                EmployeeRepository empRepo = new EmployeeRepository();

                if (empRepo.DeleteEmployee(id))
                {
                    ViewBag.AlertMessge = "Employee details deleted successfully";
                }
                return RedirectToAction("GetAllEmployeeDetails");
            }
            catch
            {
                return RedirectToAction("GetAllEmployeeDetails");
            }
        }
    }
}
