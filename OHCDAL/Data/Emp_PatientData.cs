//using FPDAL.Data;
using OHCDAL.Data;
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
    public class Emp_PatientData : ConnectionObjects
    {
        public DataSet SelectAll(Emp_PatientModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                              new SqlParameter("@Mode",41),
                                              new SqlParameter("@EmployeeId", model.EmployeeId),
                                              new SqlParameter("@EmployeeName", model.EmployeeName??string.Empty),
                                              new SqlParameter("@EmployeeCode", model.EmployeeCode??string.Empty),
                                              new SqlParameter("@Dob", model.Dob),
                                              new SqlParameter("@Address", model.Address ?? string.Empty),
                                              new SqlParameter("@EmployeeType", model.EmployeeType ?? string.Empty),
                                              new SqlParameter("@IsActive", model.IsActive),
                                              new SqlParameter("@IsOutside", model.IsOutsideWorker),
                                              new SqlParameter("@CreatedBy", model.CreatedBy),
                                              new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_Emp_Patient", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "Emp_PatientData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(Emp_PatientModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                              new SqlParameter("@Mode",11),
                                              new SqlParameter("@EmployeeId", model.EmployeeId),
                                              new SqlParameter("@EmployeeName", model.EmployeeName??string.Empty),
                                              new SqlParameter("@EmployeeCode", model.EmployeeCode??string.Empty),
                                              new SqlParameter("@Dob", model.Dob),
                                              new SqlParameter("@Address", model.Address??string.Empty),
                                              new SqlParameter("@EmployeeType", model.EmployeeType??string.Empty),
                                              new SqlParameter("@IsActive", model.IsActive),
                                              new SqlParameter("@IsOutside", model.IsOutsideWorker),
                                              new SqlParameter("@CreatedBy",model.CreatedBy),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_Emp_Patient", parameters);
                ReturnResult = Convert.ToInt32(parameters[0].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "Emp_PatientData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetEmp_PatientDataById(Emp_PatientModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                              new SqlParameter("@Mode",31),
                                              new SqlParameter("@EmployeeId", model.EmployeeId),
                                              new SqlParameter("@EmployeeName", model.EmployeeName??string.Empty),
                                              new SqlParameter("@EmployeeCode", model.EmployeeCode??string.Empty),
                                              new SqlParameter("@Dob", model.Dob),
                                              new SqlParameter("@Address", model.Address??string.Empty),
                                              new SqlParameter("@EmployeeType", model.EmployeeType??string.Empty),
                                              new SqlParameter("@IsActive",model.IsActive),
                                              new SqlParameter("@IsOutside", model.IsOutsideWorker),
                                              new SqlParameter("@CreatedBy",model.CreatedBy),
                                              new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_Emp_Patient", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "Emp_PatientData", "GetEmp_PatientDataById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
    }
}

