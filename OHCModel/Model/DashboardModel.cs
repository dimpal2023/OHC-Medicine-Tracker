using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCModel.Model
{
    public class DashboardModel
    {
        public Int32 PendingRequset { get; set; }
        public Int32 CurrentStock { get; set; }
        public Int32 TodayPurchase { get; set; }
        public Int32 TotalIssue { get; set; }
        public Int32 TodayPrescribe { get; set; }
        public Int32 TodayIssue { get; set; }
        public Int32 TodayInspection { get; set; }
        public Int32 TotalCertifiedfirstAider { get; set; }
        public Int32 UserUnitID { get; set; }
        public string CreatedBy { get; set; }
        public List<MedicineStatus> _MedicineStatusList { get; set; }
        public OPDCountUnitWise _UnitWiseList { get; set; }
    }
    public class MedicineStatus
    {
        public string MedicineName { get; set; }
        public Int32 Quantity { get; set; }
    }
    public class OPDCountUnitWise
    {
        public string Unit1 { get; set; }
        public string Unit2 { get; set; }
        public string Unit3 { get; set; }
        public string Unit4 { get; set; }
        public string Unit5 { get; set; }
    }
}
