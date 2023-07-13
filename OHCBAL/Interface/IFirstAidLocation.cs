using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IFirstAidLocation
    {
        FALModel GetFirstAidLocationData(FALModel model);
        FALModel GetFirstAidLocationDataById(FALModel model);
        FALModel AddOrEdit(FALModel model);
        FALModel GetProjectCommondata();
    }
}
