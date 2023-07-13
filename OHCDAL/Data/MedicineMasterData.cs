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
    public class MedicineMasterData : ConnectionObjects
    {
        public DataSet SelectAll(MedicineMasterModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                            new SqlParameter("@Mode",41),
                                            new SqlParameter("@ID",model.Id),
                                            new SqlParameter("@MedicineName",model.MedicineName??string.Empty),
                                            new SqlParameter("@Type",model.Type??string.Empty),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@Remark",model.Remark??string.Empty),
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
                ApplicationLogger.LogError(ex, "MedicineMasterData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(MedicineMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                             new SqlParameter("@Mode",11),
                                            new SqlParameter("@ID",model.Id),
                                            new SqlParameter("@MedicineName",model.MedicineName??string.Empty),
                                            new SqlParameter("@Type",model.Type??string.Empty),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@Remark",model.Remark??string.Empty),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),

                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineMaster", parameters);
                ReturnResult = Convert.ToInt32(parameters[0].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineMasterData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetDepartmentMasterDataById(MedicineMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",31),
                                             new SqlParameter("@ID",model.Id),
                                            new SqlParameter("@MedicineName",model.MedicineName??string.Empty),
                                            new SqlParameter("@Type",model.Type??string.Empty),
                                            new SqlParameter("@Status",model.Status),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                            new SqlParameter("@Remark",model.Remark??string.Empty),
                                            new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_MedicineMaster", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineMasterData", "GetDepartmentMasterDataById");
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
                ApplicationLogger.LogError(ex, "MedicineMasterData", "GetProjectCommondata");
                //ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }

    }
}
