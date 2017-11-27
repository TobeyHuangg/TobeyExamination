using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TobeyExamination.Models.Repository;
using TobeyExamination.Models;
using TobeyExamination.ViewModel;
namespace TobeyExamination.Domain
{
    public class HomeDomain
    {
        public static IEnumerable<EmployeeModel> GetHomeIndex()
        {
            //取得所有員工資料
            return EmployeeRepository.GetEmployeesAll();
        }

        public static string AddEmployee(AddEmployeeViewModel param)
        {
            string result = string.Empty;
            //判斷Name是否重複
            if (EmployeeRepository.GetEmployeesByName(param.Name) == null)
            {
                //新增員工資料
                if (!EmployeeRepository.AddEmployee(param))
                {
                    result = "新增錯誤";
                }
            }
            else
            {
                result = "名字已新增過";
            }
            return result;
        }

        public static UpdEmployeeViewModel GetUpdEmployee(int Id)
        {

            UpdEmployeeViewModel result = new UpdEmployeeViewModel();
            //取得員工資料
            EmployeeModel data = EmployeeRepository.GetEmployeesById(Id);
            if (data != null)
            {
                result.Id = data.Id;
                result.Name = data.Name;
                result.EnName = data.EnName;
            }
            return result;
        }

        public static string UpdEmployee(UpdEmployeeViewModel param)
        {

            string result = string.Empty;
            //判斷Name是否重複
            if (EmployeeRepository.GetEmployeesByName(param.Name, param.Id) == null)
            {
                //更新員工資料         
                bool data = EmployeeRepository.UpdEmployee(param);
                if (!data)
                {
                    result = "更新失敗";
                }
            }
            else
            {
                result = "名字已新增過";
            }

            return result;
        }
    }
}