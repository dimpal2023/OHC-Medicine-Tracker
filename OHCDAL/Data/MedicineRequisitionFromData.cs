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
    public class MedicineRequisitionFromData : ConnectionObjects
    {
        public DataSet SelectAll(MedicineRequisitionFromModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                            new SqlParameter("@Id",model.MedicineRequisitionID),
                                            new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
                                            new SqlParameter("@DepartmentName", model.DepartmentName),
                                            new SqlParameter("@Quantity", model.Qty),
                                            new SqlParameter("@Remark", model.Remark),
                                            new SqlParameter("@CreatedBy", model.CreatedBy),
                                            new SqlParameter("@UserUnitId", model.UserUnitID),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineRequisitionDetails", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public int AddorEdit(MedicineRequisitionFromModel model, DataTable dt, out int ReturnResult)
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
                SqlCommand cmd = new SqlCommand("dbo.Sp_MedicineRequisitionMasterData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@RequisitionId", model.MedicineRequisitionID));
                cmd.Parameters.Add(new SqlParameter("@UnitID", model.Unit));
                cmd.Parameters.Add(new SqlParameter("@DepartmentID", model.DepartmentName));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", model.CreatedBy));
                cmd.Parameters.Add("@activitydata", SqlDbType.Xml).Value = (myDataSet == null ? null : myDataSet.GetXml());
                da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                int result = Convert.ToInt32(dt1.Rows[0]["returnResult"]);
                return result;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromData", "AddOrEdit");
                ReturnResult = -1;
                return 0;
            }
        }
        public DataSet GetMedicineReceivingFormById(MedicineRequisitionFromModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                              new SqlParameter("@Mode",31),
                                              new SqlParameter("@Id",model.MedicineRequisitionID),
                                              new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
                                              new SqlParameter("@DepartmentName", model.DepartmentName),
                                              new SqlParameter("@Quantity", model.Qty),
                                              new SqlParameter("@Remark", model.Remark),
                                              new SqlParameter("@CreatedBy", model.CreatedBy),
                                              new SqlParameter("@UserUnitId", model.UserUnitID),
                                              new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineRequisitionDetails", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromData", "GetMedicineReceivingFormById");
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
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromData", "GetProjectCommondata");
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
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromData", "GetDeapartmentDataByUnit");
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
