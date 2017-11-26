using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;


namespace TobeyExamination.Models.Repository
{
    public class EmployeeRepository
    {
        public static string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static IEnumerable<Employee> GetEmployeesAll()
        {
            try
            {
                #region 參數
                string sqlQuery = String.Empty;
                #endregion

                #region SQL 語法

                sqlQuery = @"
                                  Select Id
                                        ,Name 
                                        ,EnName 
                                        ,CreateBy
                                        ,CreateTime 
                                        ,UpdateBy 
                                        ,UpdateTime 
                                  From Employee";
                #endregion

                #region SQL 查詢
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    return conn.Query<Employee>(sqlQuery);
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public Employee GetEmployeesById(string Id)
        {
            try
            {
                #region 參數
                string sqlQuery = String.Empty;
                DynamicParameters sqlparam = new DynamicParameters();
                sqlparam.Add("Id", Id);
                #endregion

                #region SQL 語法

                sqlQuery = @"
                                  Select Id
                                        ,Name 
                                        ,EnName 
                                        ,CreateBy
                                        ,CreateTime 
                                        ,UpdateBy 
                                        ,UpdateTime 
                                  From Employee 
                                  Where Id = @Id";
                #endregion

                #region SQL 查詢
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    return conn.Query<Employee>(sqlQuery, sqlparam).FirstOrDefault();
                }
                #endregion
            }
            catch (Exception ex)
            {
                return new Employee();
                throw;
            }
        }
    }
}