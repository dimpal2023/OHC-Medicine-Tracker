using OHCBAL.Interface;
using OHCDAL.Data;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OHCBAL.Business
{
    public class InventoryTabularViewAccess : IInventoryTabularView
    {
        InventoryTabularViewData PPCdata = new InventoryTabularViewData();

        public InventoryTabularViewModel GetTabularViewData()
        {
            InventoryTabularViewModel response = new InventoryTabularViewModel();
            List<InventoryTabularViewModel> responseList = new List<InventoryTabularViewModel>();
            DataSet ds = PPCdata.GetTabularViewData();
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new InventoryTabularViewModel();
                            response.MedicineName = Convert.ToString(row["MedicineName"]);
                            response.TotlaPurchase = Convert.ToString(row["TotalPurchase"]);
                            response.TotlaIssue = Convert.ToString(row["TotalIssue"]);
                            response.Balance = Convert.ToString(row["CurrentStock"]);
                            //if(string.IsNullOrEmpty(response.TotlaPurchase))
                            //{
                            //    response.TotlaPurchase = "0";
                            //}
                            //if (string.IsNullOrEmpty(response.TotlaIssue))
                            //{
                            //    response.TotlaIssue = "0";
                            //}
                            //response.Balance = Convert.ToString(Convert.ToInt16(response.TotlaPurchase) - Convert.ToInt16(response.TotlaIssue));
                            responseList.Add(response);
                        }
                    }
                }
                response._inventoryTabularViewlist = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "InventoryTabularViewAccess", "GetTabularViewData");
                return null;
            }
        }
        public string GetMonthlyInventoryReport(Int64 Selectedyear)
        {
            int returnResult = 0;
            MonthlyInventoryReportModel response = new MonthlyInventoryReportModel();
            List<MonthlyInventoryReportModel> responseList = new List<MonthlyInventoryReportModel>();
            DataSet ds = PPCdata.GetMonthlyInventoryViewData(Selectedyear);
            try
            {
                string json = "";
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            json += row[0];
                        }
                    }
                }
                return json;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "InventoryTabularViewAccess", "GetMonthlyInventoryReport");
                returnResult = -1;
                return null;
            }

        }
    }
}
