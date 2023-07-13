using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace OHCBAL.Interface
{
    public interface IMedicinePrescribe
    {
        MedicinePrescribeModel GetMedicinePrescribeData(MedicinePrescribeModel model);
        MedicinePrescribeModel GetMedicinePrescribeDataById(MedicinePrescribeModel model);
        MedicinePrescribeModel AddOrEdit(MedicinePrescribeModel model);
        MedicinePrescribeModel GetProjectCommondata();
        // MedicinePrescribeModel AddOrEdit(MedicinePrescribeModel model,int  k, DataTable dt);
    }
}

