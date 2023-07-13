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
    public class FirstAidLocationData : ConnectionObjects
    {
        public DataSet SelectAll(FALModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                            new SqlParameter("@Id",model.Id),
                                            new SqlParameter("@LocationName",model.LocationName??string.Empty),
                                                       new SqlParameter("@DepartmentId",model.DepartmentName),
                                            new SqlParameter("@IsActive",model.Status),
                                            new SqlParameter("@UnitId",model.Unit),
                                            new SqlParameter("@StationNo",model.StationNumber),
                                            new SqlParameter("@StationManager",model.EmployeeCode),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_FirstAidLocationMasterData", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidLocationData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(FALModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",11),
                                            new SqlParameter("@Id",model.Id),
                                            new SqlParameter("@LocationName",model.LocationName??string.Empty),
                                           new SqlParameter("@DepartmentId",model.DepartmentName),
                                            new SqlParameter("@IsActive",model.Status),
                                            new SqlParameter("@UnitId",model.Unit),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@StationNo",model.StationNumber),
                                            new SqlParameter("@StationManager",model.EmployeeCode),
                                             new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null)

                                      };
            try
            {  
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_FirstAidLocationMasterData", parameters);
                ReturnResult = Convert.ToInt32(parameters[9].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidLocationData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetFirstAidLocationDataById(FALModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",31),
                                             new SqlParameter("@Id",model.Id),
                                             new SqlParameter("@LocationName",model.LocationName??string.Empty),
                                             new SqlParameter("@DepartmentId",model.DepartmentName),
                                             new SqlParameter("@IsActive",model.Status),
                                             new SqlParameter("@UnitId",model.Unit),
                                             new SqlParameter("@StationNo",model.StationNumber),
                                             new SqlParameter("@StationManager",model.EmployeeCode),
                                             new SqlParameter("@CreatedBy",model.CreatedBy),
                                             new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_FirstAidLocationMasterData", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidLocationData", "GetFirstAidLocationDataById");
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
                ApplicationLogger.LogError(ex, "FirstAidLocationData", "GetProjectCommondata");
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
                ApplicationLogger.LogError(ex, "FirstAidLocationData", "GetProjectCommondataWithPara");
                return null;
            }
            finally

            {
            }
        }
    }
}
