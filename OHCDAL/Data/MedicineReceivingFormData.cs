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
    public class MedicineReceivingFormData : ConnectionObjects
    {
        public DataSet SelectAll(MedicineReceivingFormModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                             new SqlParameter("@Id",model.id),
                                            new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
                                           new SqlParameter("@HSNNumber", model.HSNNumber),
                                            new SqlParameter("@Pack", model.Pack),
                                            new SqlParameter("@Quantity", model.Quantity),
                                            new SqlParameter("@BatchNumber", model.BatchNumber),
                                            new SqlParameter("@Rate", model.Rate),
                                            new SqlParameter("@ExpiryDate", model.ExpiryDate),
                                            new SqlParameter("@VenderName", model.VenderName),
                                            new SqlParameter("@CreatedBy", model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineReceivingMasterData", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineReceivingFormData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(MedicineReceivingFormModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={

                                             new SqlParameter("@Mode",11),
                                             new SqlParameter("@Id",model.id),
                                            new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
                                           new SqlParameter("@HSNNumber", model.HSNNumber),
                                            new SqlParameter("@Pack", model.Pack),
                                            new SqlParameter("@Quantity", model.Quantity),
                                            new SqlParameter("@BatchNumber", model.BatchNumber),
                                            new SqlParameter("@Rate", model.Rate),
                                            new SqlParameter("@ExpiryDate", model.ExpiryDate),
                                            new SqlParameter("@VenderName", model.VenderName),
                                            new SqlParameter("@CreatedBy", model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineReceivingMasterData", parameters);
                ReturnResult = Convert.ToInt32(parameters[11].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineReceivingFormData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetMedicineReceivingFormById(MedicineReceivingFormModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                                 new SqlParameter("@Mode",31),
                                             new SqlParameter("@Id",model.id),
                                            new SqlParameter("@MedicineName", model.Medicinename??string.Empty),
                                           new SqlParameter("@HSNNumber", model.HSNNumber),
                                            new SqlParameter("@Pack", model.Pack),
                                            new SqlParameter("@Quantity", model.Quantity),
                                            new SqlParameter("@BatchNumber", model.BatchNumber),
                                            new SqlParameter("@Rate", model.Rate),
                                            new SqlParameter("@ExpiryDate", model.ExpiryDate),
                                            new SqlParameter("@VenderName", model.VenderName),
                                            new SqlParameter("@CreatedBy", model.CreatedBy),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineReceivingMasterData", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineReceivingFormData", "GetMedicineReceivingFormById");
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
                
                ApplicationLogger.LogError(ex, "MedicineReceivingFormData", "GetProjectCommondata");
                //ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }
    }
}
