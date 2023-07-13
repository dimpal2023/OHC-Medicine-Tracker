using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IVendorMaster
    {
        VendorMasterModel GetVendorMasterData(VendorMasterModel model);
        VendorMasterModel GetVendorMasterDataById(VendorMasterModel model);
        VendorMasterModel AddOrEdit(VendorMasterModel model);
    }
}

