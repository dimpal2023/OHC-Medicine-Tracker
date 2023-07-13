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
    public class FirstAidInspectionData : ConnectionObjects
    {
        public DataSet SelectAll(FirstAidInspectionModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                            new SqlParameter("@Id",model.FirstAidInspectionID),
                                            new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
                                            new SqlParameter("@DepartmentName", model.DepartmentName),
                                            new SqlParameter("@Location", model.Location),
                                            new SqlParameter("@Unit", model.Unit),
                                            new SqlParameter("@Shift", model.Shift),
                                            new SqlParameter("@Frequency", model.Frequency),
                                            new SqlParameter("@DateofInspection", model.DateOfInspection),
                                            new SqlParameter("@NextDueOn", model.NextDueOn),
                                            new SqlParameter("@CreatedBy", model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_FirstAidInspectionDetails", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
               ApplicationLogger.LogError(ex, "FirstAidInspectionData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public int AddorEdit(FirstAidInspectionModel model, DataTable dt, out int ReturnResult)
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
                SqlCommand cmd = new SqlCommand("dbo.Sp_FirstAidInspectionMasterData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@FirstAidInspectionID", model.FirstAidInspectionID));
                cmd.Parameters.Add(new SqlParameter("@InspectionType", model.InspectionType));
                cmd.Parameters.Add(new SqlParameter("@UnitID", model.Unit));
                cmd.Parameters.Add(new SqlParameter("@DepartmentID", model.DepartmentName));
                cmd.Parameters.Add(new SqlParameter("@LocationID", model.Location));
                cmd.Parameters.Add(new SqlParameter("@Frequency", model.Frequency));
                cmd.Parameters.Add(new SqlParameter("@Shift", model.Shift));
                cmd.Parameters.Add(new SqlParameter("@DateofInspection", model.DateOfInspection));
                cmd.Parameters.Add(new SqlParameter("@NextDueOn", model.NextDueOn));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", model.CreatedBy));
                cmd.Parameters.Add("@activitydata", SqlDbType.Xml).Value = (myDataSet == null ? null : myDataSet.GetXml());
                da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                int result = Convert.ToInt32(dt1.Rows[0]["returnResult"]);
                return result;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidInspectionData", "AddOrEdit");
                ReturnResult = -1;
                return 0;
            }
        }
        public DataSet GetMedicineReceivingFormById(FirstAidInspectionModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                 new SqlParameter("@Mode",31),
                                            new SqlParameter("@Id",model.FirstAidInspectionID),
                                            new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
                                            new SqlParameter("@DepartmentName", model.DepartmentName),
                                            new SqlParameter("@Location", model.Location),
                                            new SqlParameter("@Unit", model.Unit),
                                            new SqlParameter("@Shift", model.Shift),
                                            new SqlParameter("@Frequency", model.Frequency),
                                            new SqlParameter("@NextDueOn", model.NextDueOn),
                                            new SqlParameter("@DateofInspection", model.DateOfInspection),
                                            new SqlParameter("@CreatedBy", model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_FirstAidInspectionDetails", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidInspectionData", "GetMedicineReceivingFormById");
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
                //ApplicationLogger.LogError(ex, "ProductProjectReportData", "GetProjectCommondata");
                //ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetDeapartmentDataByUnit(int UnitId)
        {
            DataSet myDataSet = null;

            SqlParameter[] parameters ={
                                              new SqlParameter("@UnitId",UnitId),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetDepartmentByUnit", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                //ApplicationLogger.LogError(ex, "ProductProjectReportData", "GetProjectCommondata");
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

                return null;
            }
            finally

            {
            }
        }
    }
}
