using Infotech.ClassLibrary;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCDAL.Data
{
    public class MedicineExpiryData : ConnectionObjects
    {
        public DataSet GetAllMedicine()
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                            new SqlParameter("@ID",""),
                                            new SqlParameter("@MedicineName",""),
                                            new SqlParameter("@Type",""), 
                                            new SqlParameter("@Status",""),
                                            new SqlParameter("@CreatedBy",""),
                                            new SqlParameter("@Remark ",""),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineMaster", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineExpiryData", "GetAllMedicine");

                return null;
            }
            finally

            {
            }
        }
        public DataSet GetMedicineByMedId(MedicineExpiryModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                         new SqlParameter("@MedicineId",model.MedicineName),
                                         new SqlParameter("@UserUnitId",model.UserUnitID),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_GetExpiryMedicine", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineExpiryData", "GetMedicineByMedId");

                return null;
            }
            finally

            {
            }
        }
    }
}
