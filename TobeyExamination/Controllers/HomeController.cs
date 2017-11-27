using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TobeyExamination.Models;
using TobeyExamination.Domain;
using TobeyExamination.ViewModel;

namespace TobeyExamination.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var viewData = HomeDomain.GetHomeIndex();
            return View(viewData);
        }

        public ActionResult AddEmployee()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddEmployee(AddEmployeeViewModel param)
        {
            //表單驗證
            if (ModelState.IsValid)
            {
                var Data = HomeDomain.AddEmployee(param);
                if (String.IsNullOrWhiteSpace(Data))
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["message"] = Data;
                    return View();
                }
            }
            return View();
        }
    }
}