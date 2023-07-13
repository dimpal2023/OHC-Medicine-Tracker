using Infotech.ClassLibrary;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OHCDAL.Data
{
    public class UserMasterData : ConnectionObjects
    {
        public DataSet SelectAll(UserMasterModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                            new SqlParameter("@UserId",model.UserId),
                                            new SqlParameter("@UserName",model.UserName??string.Empty),

                                         
                                               new SqlParameter("@Password",model.Password??string.Empty),
                                                  new SqlParameter("@Email",model.Email??string.Empty),
                                                     new SqlParameter("@EmployeeCode",model.EmployeeCode??string.Empty),
                                                       new SqlParameter("@DepartmentId",model.DepartmentId),



                                            new SqlParameter("@IsActive",model.IsActive),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_UserMaster", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(UserMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                             new SqlParameter("@Mode",11),
                                            new SqlParameter("@UserId",model.UserId),
                                            new SqlParameter("@UserName",model.UserName??string.Empty),
                                               new SqlParameter("@Password",model.Password??string.Empty),
                                                  new SqlParameter("@Email",model.Email??string.Empty),
                                                     new SqlParameter("@EmployeeCode",model.EmployeeCode??string.Empty),
                                                       new SqlParameter("@DepartmentId",model.DepartmentId),
                                                       new SqlParameter("@UnitId",model.Unit),
                                            new SqlParameter("@IsActive",model.IsActive),
                                             new SqlParameter("@UserType",model.EmpType),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),

                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_UserMaster", parameters);
                ReturnResult = Convert.ToInt32(parameters[0].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetUserMasterDataById(UserMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",31),
                                            new SqlParameter("@UserId",model.UserId),
                                            new SqlParameter("@UserName",model.UserName??string.Empty),
                                            new SqlParameter("@Password",model.Password??string.Empty),
                                            new SqlParameter("@Email",model.Email??string.Empty),
                                            new SqlParameter("@EmployeeCode",model.EmployeeCode??string.Empty),
                                            new SqlParameter("@DepartmentId",model.DepartmentId),
                                            new SqlParameter("@IsActive",model.IsActive),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_UserMaster", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterData", "GetUserMasterDataById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }

        public DataSet GetProjectCommondata()
        {
            DataSet myDataSet = null;

            SqlParameter[] parameters ={
                //new SqlParameter("@CommandType","Department"),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_CommonData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterData", "GetProjectCommondata");
                return null;
            }
            finally

            {
            }
        }
        public DataSet GetProjectCommondataWithPara(int Id)
        {
            DataSet myDataSet = null;

            SqlParameter[] parameters ={
                              new SqlParameter("@Id",Id),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_CommonDataWithPara", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterData", "GetProjectCommondataWithPara");
                return null;
            }
            finally

            {
            }
        }
    }
}
