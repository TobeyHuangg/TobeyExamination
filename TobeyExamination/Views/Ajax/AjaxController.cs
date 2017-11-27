using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TobeyExamination.Domain;

namespace TobeyExamination.Views.Ajax
{
    public class AjaxController : AsyncController
    {

        public void DelEmployeeAsync(delEmployeeParan data)
        {
            var status = false;
            if (data != null) {
                 status = AjaxDomain.DelEmployee(data.Id);
            }
            AsyncManager.Parameters["model"] = status;
            AsyncManager.OutstandingOperations.Decrement();
        }

        public ActionResult DelEmployeeCompleted(object model)
        {
            return Json(model);
        }
        public class delEmployeeParan
        {
            public int Id { get; set; }
        }
    }
}