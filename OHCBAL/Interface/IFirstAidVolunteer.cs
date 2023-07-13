using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IFirstAidVolunteer
    {
        FAVModel GetFirstAidVolunteerData(FAVModel model);
        FAVModel GetFirstAidVolunteerDataById(FAVModel model);
        FAVModel GetCommonData(FAVModel model);
        FAVModel AddOrEdit(FAVModel model);
        FAVModel GetProjectCommondata();
    }
}
