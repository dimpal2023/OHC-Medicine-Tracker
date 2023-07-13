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
    public class InventoryTabularViewData : ConnectionObjects
    {
        public DataSet GetTabularViewData()
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={

                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetInventoryTabularviewData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "InventoryTabularViewData", "GetTabularViewData");
                return null;
            }
            finally
            {
            }
        }

        public DataSet GetMonthlyInventoryViewData(Int64 Selectedyear)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                 new SqlParameter("@Selectedyear",Selectedyear),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.GetMonthlyInventoryData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "InventoryTabularViewData", "GetMonthlyInventoryViewData");
                return null;
            }
            finally
            {
            }
        }
    }
}
