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
    public class MedicineIssuanceData : ConnectionObjects
    {
        public DataSet SelectAll(MedicineIssuancetootherunitfirstaddModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                             new SqlParameter("@Id",model.MedicineIssuanceID),
                                            new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
                                           new SqlParameter("@DepartmentName", model.DepartmentName),
                                            new SqlParameter("@IssueDate", model.IssueDate),
                                            new SqlParameter("@Quantity", model.Qty),
                                            new SqlParameter("@BatchNumber", model.BatchNo),
                                            new SqlParameter("@CreatedBy", model.CreatedBy),
                                            new SqlParameter("@UserUnitID", model.@UserUnitID),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineIssuanceMasterData", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineIssuanceData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public int AddorEdit(MedicineIssuancetootherunitfirstaddModel model, DataTable dt, out int ReturnResult)
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
                SqlCommand cmd = new SqlCommand("dbo.Sp_MedicineIssuanceMasterData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add(new SqlParameter("@IssuanceId", model.MedicineIssuanceID));
                cmd.Parameters.Add(new SqlParameter("@UnitID", model.Unit));
                cmd.Parameters.Add(new SqlParameter("@DepartmentID", model.DepartmentName));
                cmd.Parameters.Add(new SqlParameter("@IssueDate", model.IssueDate));
                cmd.Parameters.Add(new SqlParameter("@CreatedBy", model.CreatedBy));
                //cmd.Parameters.Add(new SqlParameter("@UserUnitID", model.UserUnitID));
                cmd.Parameters.Add("@activitydata", SqlDbType.Xml).Value = (myDataSet == null ? null : myDataSet.GetXml());
                da = new SqlDataAdapter(cmd);
                da.Fill(dt1);
                int result = Convert.ToInt32(dt1.Rows[0]["returnResult"]);
                return result;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineIssuanceData", "AddOrEdit");
                ReturnResult = -1;
                return 0;
            }
            //DataSet myDataSet = null;
            //ReturnResult = 0;
            //SqlParameter[] parameters ={
            //                                 new SqlParameter("@Mode",11),
            //                                 new SqlParameter("@Id",model.MedicineIssuanceID),
            //                                 new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
            //                                 new SqlParameter("@DepartmentName", model.DepartmentName),
            //                                 new SqlParameter("@IssueDate", model.IssueDate),
            //                                 new SqlParameter("@Quantity", model.Qty),
            //                                 new SqlParameter("@BatchNumber", model.BatchNo),
            //                                 new SqlParameter("@CreatedBy", model.CreatedBy),
            //                                 new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
            //                          };
            //try
            //{
            //    myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineIssuanceMasterData", parameters);
            //    ReturnResult = Convert.ToInt32(parameters[8].Value);
            //    return myDataSet;
            //}
            //catch (Exception ex)
            //{
            //    //ApplicationLogger.LogError(ex, "MedicineIssuanceData", "AddorEdit");
            //    ReturnResult = -1;
            //    return null;
            //}
            //finally
            //{
            //}
        }
        public DataSet GetMedicineIssuancById(MedicineIssuancetootherunitfirstaddModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                              new SqlParameter("@Mode",31),
                                              new SqlParameter("@Id",model.MedicineIssuanceID),
                                              new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
                                              new SqlParameter("@DepartmentName", model.DepartmentName),
                                              new SqlParameter("@IssueDate", model.IssueDate),
                                              new SqlParameter("@Quantity", model.Qty),
                                              new SqlParameter("@BatchNumber", model.BatchNo),
                                              new SqlParameter("@CreatedBy", model.CreatedBy),
                                              new SqlParameter("@UserUnitID", model.@UserUnitID),
                                              new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
                {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineIssuanceMasterData", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineIssuanceData", "GetMedicineIssuancById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        public DataSet MedicineRequsetData(MedicineIssuancetootherunitfirstaddModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                              new SqlParameter("@Id",model.MedicineIssuanceID),
                                              new SqlParameter("@UserUnitID",model.UserUnitID),
                                      };
            try
                {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetMedicineRequestDataFromIssuance", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineIssuanceData", "GetMedicineIssuancById");
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
                ApplicationLogger.LogError(ex, "MedicineIssuanceData", "GetProjectCommondata");
                //ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
        //public DataSet GetDeapartmentDataByUnit(int UnitId)
        //{
        //    DataSet myDataSet = null;

        //    SqlParameter[] parameters ={
        //                                      new SqlParameter("@UnitId",UnitId),
        //                              };
        //    try
        //    {
        //        myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetDepartmentByUnit", parameters);
        //        return myDataSet;
        //    }
        //    catch (Exception ex)
        //    {
        //        //ApplicationLogger.LogError(ex, "ProductProjectReportData", "GetProjectCommondata");
        //        //ReturnResult = -1;
        //        return null;
        //    }
        //    finally

        //    {
        //    }
        //}
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
                ApplicationLogger.LogError(ex, "MedicineIssuanceData", "GetProjectCommondataWithPara");
                return null;
            }
            finally

            {
            }
        }
    }
}
