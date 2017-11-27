using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Dapper;
using TobeyExamination.ViewModel;


namespace TobeyExamination.Models.Repository
{
    public class EmployeeRepository
    {
        public static string strConn = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        #region 查詢

        public static IEnumerable<EmployeeModel> GetEmployeesAll()
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
                    return conn.Query<EmployeeModel>(sqlQuery);
                }
                #endregion
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public static EmployeeModel GetEmployeesById(string Id)
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
                    return conn.Query<EmployeeModel>(sqlQuery, sqlparam).FirstOrDefault();
                }
                #endregion
            }
            catch (Exception ex)
            {
                return new EmployeeModel();
                throw;
            }
        }

        public static EmployeeModel GetEmployeesByName(string Name)
        {
            try
            {
                #region 參數
                string sqlQuery = String.Empty;
                DynamicParameters sqlparam = new DynamicParameters();
                sqlparam.Add("Name", Name);
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
                                  Where Name = @Name";
                #endregion

                #region SQL 查詢
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    return conn.Query<EmployeeModel>(sqlQuery, sqlparam).FirstOrDefault();
                }
                #endregion
            }
            catch (Exception ex)
            {
                return new EmployeeModel();
                throw;
            }
        }

        #endregion

        #region 新增

        public static bool AddEmployee(AddEmployeeViewModel param)
        {
            bool result = true;
            try
            {
                #region 參數
                string sqlQuery = String.Empty;
                string sqlWhere = String.Empty;
                DynamicParameters sqlparam = new DynamicParameters();
                sqlparam.Add("Name", param.Name);
                if (!String.IsNullOrWhiteSpace(param.EnName))
                {
                    sqlparam.Add("EnName", param.EnName);
                }
                else
                {
                    sqlparam.Add("EnName", null);
                }
                #endregion

                #region SQL 語法

                sqlQuery = @"
                            INSERT INTO Employee
                            (
                              Name
                             ,EnName
                             ,CreateBy
                             ,CreateTime
                            )
                            VALUES
                            (
                              @Name
                             ,@EnName
                             ,'SYS'
                             ,GETDATE() 
                            )";

                #endregion

                #region SQL 查詢
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    conn.Execute(sqlQuery, sqlparam);
                }
                #endregion
            }
            catch (Exception ex)
            {
                result = false;
                throw;
            }
            return result;
        }

        #endregion

        #region 刪除

        #endregion
    }
}