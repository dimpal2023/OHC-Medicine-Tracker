using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IUserMaster
    {
        UserMasterModel GetUserMasterData(UserMasterModel model);
        UserMasterModel GetUserMasterDataById(UserMasterModel model);
        UserMasterModel AddOrEdit(UserMasterModel model);
        UserMasterModel GetProjectCommondata();
    }
}
