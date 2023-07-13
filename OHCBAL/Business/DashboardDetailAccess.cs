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
    public class DashboardDetailAccess : IDashboardDetail
    {
        DashboardDetailData PPCdata = new DashboardDetailData();

        public DashboardModel GetDashboardData(DashboardModel model)
        {
            DashboardModel response = new DashboardModel();
            MedicineStatus medicineStatus = new MedicineStatus();
            OPDCountUnitWise opd = new OPDCountUnitWise();
            List<MedicineStatus> medicineStatusList = new List<MedicineStatus>();
            DataSet ds = PPCdata.GetDashboardData(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.PendingRequset = Convert.ToInt32(ds.Tables[0].Rows[0]["PendingRequest"]);
                        response.CurrentStock = Convert.ToInt32(ds.Tables[0].Rows[0]["CurrentStock"]);
                        response.TodayPurchase = Convert.ToInt32(ds.Tables[0].Rows[0]["TodayPurchase"]);
                        response.TotalIssue = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalIssue"]);
                        response.TodayPrescribe = Convert.ToInt32(ds.Tables[0].Rows[0]["TodayPrescribe"]);
                        response.TodayIssue = Convert.ToInt32(ds.Tables[0].Rows[0]["TodayIssue"]);
                        response.TodayInspection = Convert.ToInt32(ds.Tables[0].Rows[0]["TodayInspection"]);
                        response.TotalCertifiedfirstAider = Convert.ToInt32(ds.Tables[0].Rows[0]["TotalVolunteer"]);
                    }
                    if(ds.Tables[1].Rows.Count > 0)
                    {
                        foreach(DataRow row in ds.Tables[1].Rows)
                        {
                            medicineStatus = new MedicineStatus();
                            medicineStatus.MedicineName = Convert.ToString(row["MedicineName"]);
                            medicineStatus.Quantity = Convert.ToInt32(row["AvailableQty"]);
                            medicineStatusList.Add(medicineStatus);
                        }
                    }
                    if(ds.Tables[2].Rows.Count > 0)
                    {
                        
                            opd.Unit1=Convert.ToString(ds.Tables[2].Rows[0]["Unit1"]);
                            opd.Unit2 = Convert.ToString(ds.Tables[2].Rows[0]["Unit2"]);
                            opd.Unit3 = Convert.ToString(ds.Tables[2].Rows[0]["Unit4"]);
                            opd.Unit4 = Convert.ToString(ds.Tables[2].Rows[0]["Unit4"]);
                            opd.Unit5 = Convert.ToString(ds.Tables[2].Rows[0]["Unit5"]);
                        
                    }
                }
                response._UnitWiseList = opd;
                response._MedicineStatusList=medicineStatusList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "InventoryTabularViewAccess", "GetTabularViewData");
                return null;
            }
        }
    }
}
