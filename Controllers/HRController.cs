using Final_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Final_Project.Controllers
{
    public class HRController : Controller
    {
        private readonly EmployeeDBHandle DbHandle;
        public HRController()
        {
            DbHandle = new EmployeeDBHandle();
        }
        // GET: Employee
        public ActionResult Index()
        {
            return View(DbHandle.GetAll());
        }
    }
}