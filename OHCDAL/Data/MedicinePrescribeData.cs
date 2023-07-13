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
    public class MedicinePrescribeData : ConnectionObjects
    {
        public DataSet SelectAll(MedicinePrescribeModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                            new SqlParameter("@Mode",41),
                            new SqlParameter("@Id", model.Id),
                            new SqlParameter("@EmployeeId", model.EmployeeId),
                            new SqlParameter("@EmployeeName", model.EmployeeName??string.Empty),
                            new SqlParameter("@Problem", model.Problem??string.Empty),
                            new SqlParameter("@IsActive", model.IsActive),
                            new SqlParameter("@Gender ", model.Gender),
                            new SqlParameter("@UnitID", model.Unit),
                            new SqlParameter("@DepartmentID", model.Department),
                            new SqlParameter("@Date", model.Date),
                            new SqlParameter("@Time", model.Time),
                            new SqlParameter("@SuggestedBy", model.SuggestedBy),
                            new SqlParameter("@Treatment", model.Treatment),
                            new SqlParameter("@CheckUp", model.VitalCheckUp),
                            new SqlParameter("@UserUnitID", model.UserUnitID),
                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                            };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicinePrescribe", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicinePrescribeData", "SelectAll");
                ex.Message.ToString();
                return null;
            }
            finally

            {
            }
        }
        public int AddorEdit(MedicinePrescribeModel model,DataTable dt,out int ReturnResult)
        {
            try
            {
                DataTable dt1 = new DataTable();
                ReturnResult = 0;
                dt.TableName = "tblItem";
                DataSet myDataSet = new DataSet("myDataSet");
                myDataSet.Tables.Add(dt);
                string constr = ConfigurationManager.ConnectionStrings["OHC"].ConnectionString;
                SqlConnection con = new SqlConnection(constr);
                SqlDataAdapter da = new SqlDataAdapter();
                SqlCommand cmd = new SqlCommand("Sp_MedicinePrescribeMasterData", con);//dbo.Proc_MedicineIssuanceMasterData
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@Id", model.Id));
                cmd.Parameters.Add(new SqlParameter("@EmployeeId", model.EmployeeCode));
                cmd.Parameters.Add(new SqlParameter("@EmployeeName", model.EmployeeName ?? string.Empty));
                cmd.Parameters.Add(new SqlParameter("@Problem", model.Problem ?? string.Empty));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", model.CreatedBy ?? string.Empty));
                cmd.Parameters.Add(new SqlParameter("@IsActive", model.IsActive));
                cmd.Parameters.Add(new SqlParameter("@Gender", model.Gender));
                cmd.Parameters.Add(new SqlParameter("@UnitID", model.Unit));
                cmd.Parameters.Add(new SqlParameter("@DepartmentID", model.Department));
                cmd.Parameters.Add(new SqlParameter("@EmergencyContact", model.EmergencyContactNo));
                cmd.Parameters.Add(new SqlParameter("@Mobile", model.Mobile));
                cmd.Parameters.Add(new SqlParameter("@DOB", model.DOB));
                cmd.Parameters.Add(new SqlParameter("@Address", model.Address));
                cmd.Parameters.Add(new SqlParameter("@Company", model.CompanyName));
                cmd.Parameters.Add(new SqlParameter("@IsReffer", model.IsReffered));
                cmd.Parameters.Add(new SqlParameter("@IsOutsideEmployee", model.IsOutsideWorker));
                cmd.Parameters.Add(new SqlParameter("@Date", model.Date));
                cmd.Parameters.Add(new SqlParameter("@Time", model.Time));
                cmd.Parameters.Add(new SqlParameter("@SuggestedBy", model.SuggestedBy));
                cmd.Parameters.Add(new SqlParameter("@Treatment", model.Treatment));
                cmd.Parameters.Add(new SqlParameter("@CheckUp", model.VitalCheckUp));
                cmd.Parameters.Add(new SqlParameter("@FirstAidCheckUp", model.FirstAidCheckUp));
                cmd.Parameters.Add(new SqlParameter("@DepartmentName", model.MasterDepartment));
                cmd.Parameters.Add(new SqlParameter("@HospitalName", model.HospitalName));
                cmd.Parameters.Add(new SqlParameter("@AttendeeName", model.AttendeeName));
                cmd.Parameters.Add(new SqlParameter("@AttendeeMobileNumber", model.AttendeeMobileNumber));
                cmd.Parameters.Add(new SqlParameter("@RefferbyVehicle", model.RefferbyVehicle));
                cmd.Parameters.Add(new SqlParameter("@PatientStatus", model.PatientStatus));
                cmd.Parameters.Add(new SqlParameter("@UserUnitID", model.UserUnitID));
                cmd.Parameters.Add(new SqlParameter("@SuggestedDetails", model.SuggestedDetails));
                cmd.Parameters.Add(new SqlParameter("@PatientStatusCloseDescription", model.PatientStatusCloseDiscription));
                cmd.Parameters.Add(new SqlParameter("@PatinetFitnessCretificate", model.PatientFitnessCertificate));
                cmd.Parameters.Add(new SqlParameter("@ReferByVehicleWhenEmpOutside", model.ReferbyOtherVehicle));
                cmd.Parameters.Add("@activitydata", SqlDbType.Xml).Value = (myDataSet == null ? null : myDataSet.GetXml());
                da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                int result = Convert.ToInt32(dt1.Rows[0]["returnResult"]);
                return result;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicinePrescribeData", "AddOrEdit");
                ReturnResult = -1;
                return 0;
            }
        }
        public DataSet GetMedicinePrescribeDataById(MedicinePrescribeModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                            new SqlParameter("@Mode",31),
                            new SqlParameter("@Id", model.Id),
                             new SqlParameter("@EmployeeId", model.EmployeeId),
                            new SqlParameter("@EmployeeName", model.EmployeeName??string.Empty),
                            new SqlParameter("@Problem", model.Problem??string.Empty),
                            new SqlParameter("@Gender ", model.Gender),
                            new SqlParameter("@UnitID", model.Unit),
                            new SqlParameter("@DepartmentID", model.Department),
                            new SqlParameter("@Date", model.Date),
                            new SqlParameter("@Time", model.Time),
                            new SqlParameter("@SuggestedBy", model.SuggestedBy),
                            new SqlParameter("@Treatment", model.Treatment),
                            new SqlParameter("@CheckUp", model.VitalCheckUp),
                            new SqlParameter("@IsActive", model.IsActive),
                            new SqlParameter("@UserUnitID", model.UserUnitID),
                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                            };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicinePrescribe", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicinePrescribeData", "GetMedicinePrescribeDataById");
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
                ApplicationLogger.LogError(ex, "MedicinePrescribeData", "GetProjectCommondata");

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


