using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IMaster
    {
        DepartmentMasterModel GetDepartmentMasterData(DepartmentMasterModel model);
        DepartmentMasterModel GetDepartmentMasterDataById(DepartmentMasterModel model);
        DepartmentMasterModel AddOrEdit(DepartmentMasterModel model);
        DepartmentMasterModel GetProjectCommondata();
    }
}
