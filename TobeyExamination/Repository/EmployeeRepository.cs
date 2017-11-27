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

        public static EmployeeModel GetEmployeesById(int Id)
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
            }
        }

        public static EmployeeModel GetEmployeesByName(string Name ,int Id=0)
        {
            try
            {
                #region 參數
                string sqlQuery = String.Empty;
                string sqlWhere = String.Empty;
                DynamicParameters sqlparam = new DynamicParameters();
                if (!String.IsNullOrWhiteSpace(Name))
                {
                    sqlparam.Add("Name", Name.Trim());
                    sqlWhere = " Where Name = @Name";
                }

                //更新判斷除了本身之外的Name是否重複
                if (Id!=0)
                {
                    sqlparam.Add("Id", Id);
                    sqlWhere += " AND Id <> @Id";
                }

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
                                  From Employee ";
                
                #endregion

                #region SQL 查詢
                using (SqlConnection conn = new SqlConnection(strConn))
                {
                    return conn.Query<EmployeeModel>(sqlQuery + sqlWhere, sqlparam).FirstOrDefault();
                }
                #endregion
            }
            catch (Exception ex)
            {
                return new EmployeeModel();
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
                DynamicParameters sqlparam = new DynamicParameters();
                sqlparam.Add("Name", param.Name.Trim());
                if (!String.IsNullOrWhiteSpace(param.EnName))
                {
                    sqlparam.Add("EnName", param.EnName.Trim());
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
            }
            return result;
        }

        #endregion

        #region 更新

        public static bool UpdEmployee(UpdEmployeeViewModel param)
        {
            bool result = true;
            try
            {
                #region 參數
                string sqlQuery = String.Empty;
                DynamicParameters sqlparam = new DynamicParameters();
                sqlparam.Add("Id", param.Id);
                sqlparam.Add("Name", param.Name.Trim());
                if (!String.IsNullOrWhiteSpace(param.EnName))
                {
                    sqlparam.Add("EnName", param.EnName.Trim());
                }
                else
                {
                    sqlparam.Add("EnName", null);
                }
                #endregion

                #region SQL 語法

                sqlQuery = @"
                            UPDATE Employee
                            SET Name = @Name , EnName = @EnName 
                            Where Id =@Id";
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
            }
            return result;
        }

        #endregion

        #region 刪除

        public static bool DelEmployee(int Id)
        {
            bool result = true;
            try
            {
                #region 參數
                string sqlQuery = String.Empty;
                DynamicParameters sqlparam = new DynamicParameters();
                sqlparam.Add("Id", Id);
                #endregion

                #region SQL 語法

                sqlQuery = @"
                            DELETE FROM Employee
                            Where Id =@Id";
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
            }
            return result;
        }
        #endregion
    }
}