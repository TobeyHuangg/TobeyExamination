using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TobeyExamination.Models.Repository;
using TobeyExamination.Models;
namespace TobeyExamination.Domain
{
    public class HomeIndexDomain
    {
        public static IEnumerable<Employee> GetHomeIndex()
        {
            //取得所有員工資料
            IEnumerable<Employee> employeesData = EmployeeRepository.GetEmployeesAll();
            return employeesData;
        }
    }
}