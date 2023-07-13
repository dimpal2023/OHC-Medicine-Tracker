//using OHCDAL.Data;
using OHCDAL.Data;
using Infotech.ClassLibrary;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCDAL.Data
{
    public class AccountData : ConnectionObjects
    {
        public DataSet Login(LoginModel request, out int returnResult)
        {
            returnResult = 0;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters ={

                                                new SqlParameter("@UserId",request.UserID), 
                                            };
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_UserLogin", parameters);
            }
            catch (Exception ex)
            {
                returnResult = -1;
                ApplicationLogger.LogError(ex, "AccountData", "Login");
            }
            return ds;
        }
        public DataSet CheckUserEmail(LoginModel request, out int returnResult)
        {
            returnResult = 0;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters ={

                                            new SqlParameter("@UserId",request.UserID),
                                            new SqlParameter("@Email",request.Email),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                        };
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Sp_CheckUserEmail", parameters);
                returnResult = Convert.ToInt32(parameters[2].Value);
                return ds;
            }
            catch (Exception ex)
            {
                returnResult = -1;
                // ApplicationLogger.LogError(ex, "AccountData", "CheckUserEmail");
                return ds;
            }
            finally
            {
            }
        }
        public DataSet ChangeUserPassword(LoginModel request, out int returnResult)
        {
            returnResult = 0;
            DataSet ds = new DataSet();
            try
            {
                SqlParameter[] parameters ={

                                            new SqlParameter("@UserId",request.UserID),
                                            new SqlParameter("@Email",request.Email),
                                            new SqlParameter("@Password",request.Password),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                        };
                ds = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Sp_OHCChangeUserPassword", parameters);
                returnResult = Convert.ToInt32(parameters[3].Value);
                return ds;
            }
            catch (Exception ex)
            {
                returnResult = -1;
                // ApplicationLogger.LogError(ex, "AccountData", "ChangeUserPassword");
                return ds;
            }
            finally
            {
            }
        }
    }
}
