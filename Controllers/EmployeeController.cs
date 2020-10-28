using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    public class EmployeeController : Controller
    {        
        private readonly EmployeeDBHandle DbHandle;
        public EmployeeController()
        {
            DbHandle = new EmployeeDBHandle();
        }
        // GET: Employee
        [HttpGet]
        
        public ActionResult EmployeeIndex()
        {
            return View(DbHandle.GetAll().ToList());
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Create(Employee e)
        {
            //string message = "InsertSuccess";
            if (ModelState.IsValid)
            {
                try
                {
                    DbHandle.AddEmployee(e);
                    return Json(new { msg = "Data Added succesfully", flag = true }, JsonRequestBehavior.AllowGet);
                }

                catch(Exception ex)
                {
                    return Json(new { msg = ex.Message, flag = false }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                ModelState.AddModelError("", "Model Error");
                return Json(new { msg = "Error", flag = false }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var x = DbHandle.GetByID(id);
            return View(x);
        }

        [HttpPost]
        public JsonResult Edit(int id,Employee e)
        {
            try
            {
                DbHandle.UpdateEmployee(e);
                return Json(new { msg = "Data Edited Succesfully", flag = true }, JsonRequestBehavior.AllowGet);
            }
            catch(Exception ex) 
            {
                return Json(new { msg = ex.Message, flag = false }, JsonRequestBehavior.AllowGet);
            }
            
        }

        //[HttpGet]
        //public ActionResult Delete(int id)
        //{
        //    var x = DbHandle.GetByID(id);
        //    return View(x);
        //}

        
        public ActionResult Delete(int id)
        {
            try
            {
                DbHandle.DeleteEmployee(id);
                //return View();
                return RedirectToAction("Create");
            }
            catch
            {
                return View();
            }
            
        }
    }
}