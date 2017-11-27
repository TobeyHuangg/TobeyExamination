using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TobeyExamination.Models.Repository;

namespace TobeyExamination.Domain
{
    public class AjaxDomain
    {
        public static bool DelEmployee(int Id) {
            //取得所有員工資料
            return EmployeeRepository.DelEmployee(Id);
        }
    }
}