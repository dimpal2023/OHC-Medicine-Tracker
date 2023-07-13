using System;
using System.Collections.Generic;
using System.IO.Packaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCModel.Model
{
    public class InventoryTabularViewModel
    {
        public String MedicineName { get; set; }
        public String TotlaPurchase { get; set; }
        public String TotlaIssue { get; set; }
        public String Balance { get; set; }
        public List<InventoryTabularViewModel> _inventoryTabularViewlist { get; set; }
    }

    public class MonthlyInventoryReportModel
    {
        public String MedicineName { get; set; }
        public String MonthName { get; set; }
        public String IssueInMonth { get; set; }
        public String Quantity { get; set; }
        public String AvailableInMonth { get; set; }
        public String TotalPurchase { get; set; }
        public String TotalIssue { get; set; }
        public String Balance { get; set; }
    }
    public class MonthlyInventory 
    {
        public List<MonthlyInventoryReportModel> data { get; set; }

    }

}
