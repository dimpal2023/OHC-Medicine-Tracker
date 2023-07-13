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
    public class VendorMasterData : ConnectionObjects
    {
        public DataSet SelectAll(VendorMasterModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
           new SqlParameter("@Mode",41),

                                             new SqlParameter("@VendorId", model.VendorId),
            new SqlParameter("@VendorName", model.VendorName??string.Empty),
            new SqlParameter("@Address", model.Address??string.Empty),
            new SqlParameter("@LicenseNo", model.LicenseNo??string.Empty),
                  new SqlParameter("@IsActive",model.IsActive),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),


                                                      new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_VendorMaster", parameters);
                //ReturnResult = Convert.ToInt32(parameters[3].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "VendorMasterData", "SelectAll");

                return null;
            }
            finally

            {
            }
        }
        public DataSet AddorEdit(VendorMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                             new SqlParameter("@Mode",11),
                                              new SqlParameter("@VendorId", model.VendorId),
                                             new SqlParameter("@VendorName", model.VendorName??string.Empty),
                                       new SqlParameter("@Address", model.Address??string.Empty),
                                        new SqlParameter("@LicenseNo", model.LicenseNo??string.Empty),
                                            new SqlParameter("@IsActive",model.IsActive),
                                            new SqlParameter("@CreatedBy",model.CreatedBy),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_VendorMaster", parameters);
                ReturnResult = Convert.ToInt32(parameters[0].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "VendorMasterData", "AddorEdit");
                ReturnResult = -1;
                return null;
            }
            finally
            {
            }
        }
        public DataSet GetVendorMasterDataById(VendorMasterModel model, out int ReturnResult)
        {
            DataSet myDataSet = null;
            ReturnResult = 0;
            SqlParameter[] parameters ={
                                             new SqlParameter("@Mode",31),

           new SqlParameter("@VendorId", model.VendorId),
    new SqlParameter("@VendorName", model.VendorName??string.Empty),


    new SqlParameter("@Address", model.Address??string.Empty),


    new SqlParameter("@LicenseNo", model.LicenseNo??string.Empty),

            new SqlParameter("@IsActive",model.IsActive),
       new SqlParameter("@CreatedBy",model.CreatedBy),

                                              new SqlParameter("@returnResult", SqlDbType.Int, 4, ParameterDirection.Output, false, 0, 0, System.String.Empty, DataRowVersion.Default, null),
                                      };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.Proc_VendorMaster", parameters);
                //ReturnResult = Convert.ToInt32(parameters[1].Value);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "VendorMasterData", "GetVendorMasterDataById");
                ReturnResult = -1;
                return null;
            }
            finally

            {
            }
        }

    }
}

