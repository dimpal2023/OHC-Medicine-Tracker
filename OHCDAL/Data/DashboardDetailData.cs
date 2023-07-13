using Infotech.ClassLibrary;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OHCDAL.Data;

namespace OHCDAL.Data
{
    public class DashboardDetailData : ConnectionObjects
    {
        public DataSet GetDashboardData(DashboardModel model)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                        new SqlParameter("@UserUnitID",model.UserUnitID),
                                        //new SqlParameter("@CreatedBy",model.CreatedBy),
                                       };
            try
            {
                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "dbo.DashboardData", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DashboardDetailData", "DashboardData");
                return null;
            }
            finally
            {
            }
        }
    }
}
