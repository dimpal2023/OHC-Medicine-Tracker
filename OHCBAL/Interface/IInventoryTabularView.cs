using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IInventoryTabularView
    {
        InventoryTabularViewModel GetTabularViewData();
        string GetMonthlyInventoryReport(Int64 Selectedyear);   
    }
}
