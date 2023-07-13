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
    public class FirstAidVolunteerData : ConnectionObjects
    {
        public DataSet SelectAll(FAVModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                            new SqlParameter("@Id",model.Id),
                                            new SqlParameter("@VolunteerName",model.VolunteerName??string.Empty),
                                            new SqlParameter("@DepartmentId",model.DepartmentName),
                                            new SqlParameter("@EmpCode",model.EMPCode),
                                            new SqlParameter("@Address",model.Address),
                                            new SqlParameter("@IsActive",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_FirstAidVolunteerMasterData", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidVolunteerData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public DataSet GetCommonData(FAVModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",51),
                                            new SqlParameter("@Id",model.Id),
                                            new SqlParameter("@VolunteerName",model.VolunteerName??string.Empty),
                                            new SqlParameter("@DepartmentId",model.DepartmentName),
                                            new SqlParameter("@EmpCode",model.EMPCode),
                                            new SqlParameter("@Address",model.Address),
                                            new SqlParameter("@IsActive",model.Status),
                                            new SqlParameter("@UnitId",model.Unit),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_FirstAidVolunteerMasterData", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidVolunteerData", "GetCommonData");

                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(FAVModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",11),
                                            new SqlParameter("@Id",model.Id),
                                          new SqlParameter("@VolunteerName",model.VolunteerName??string.Empty),
                                            new SqlParameter("@DepartmentId",model.DepartmentName),
                                            new SqlParameter("@EmpCode",model.EMPCode),
                                            new SqlParameter("@Address",model.Address),
                                            new SqlParameter("@IsActive",model.Status),
                                            new SqlParameter("@UnitId",model.Unit),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@MobileNO",model.MobileNo),
                new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null)

                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_FirstAidVolunteerMasterData", parameters);
                ReturnResult = Convert.ToInt32(parameters[10].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidVolunteerData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetFirstAidVolunteerDataById(FAVModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",31),
                                             new SqlParameter("@Id",model.Id),
                                             new SqlParameter("@VolunteerName",model.VolunteerName??string.Empty),
                                            new SqlParameter("@DepartmentId",model.DepartmentName),
                                            new SqlParameter("@EmpCode",model.EMPCode),
                                            new SqlParameter("@Address",model.Address),
                                            new SqlParameter("@UnitId",model.Unit),
                                            new SqlParameter("@IsActive",model.Status),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_FirstAidVolunteerMasterData", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidVolunteerData", "GetFirstAidVolunteerDataById");
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
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_CommonData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidVolunteerData", "GetProjectCommondata");
                //ReturnResult = -1;
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
                ApplicationLogger.LogError(ex, "FirstAidVolunteerData", "GetProjectCommondataWithPara");

                return null;
            }
            finally

            {
            }
        }
    }
}
