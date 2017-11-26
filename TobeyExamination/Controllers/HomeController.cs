using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TobeyExamination.Models;
using TobeyExamination.Domain;

namespace TobeyExamination.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var viewData = HomeIndexDomain.GetHomeIndex();
            return View(viewData);
        }
    }
}