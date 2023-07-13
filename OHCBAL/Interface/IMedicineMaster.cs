using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IMedicineMaster
    {
        MedicineMasterModel GetMedicineMasterData(MedicineMasterModel model);
        MedicineMasterModel GetMedicineMasterDataById(MedicineMasterModel model);
        MedicineMasterModel AddOrEdit(MedicineMasterModel model);
        MedicineMasterModel GetProjectCommondata();
    }
}
