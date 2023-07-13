using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IFirstAidInspection
    {
        FirstAidInspectionModel GetFirstAidInspectionData(FirstAidInspectionModel model);
        FirstAidInspectionModel GetFirstAidInspectionById(FirstAidInspectionModel model);
        FirstAidInspectionModel AddOrEdit(FirstAidInspectionModel model);
        FirstAidInspectionModel GetProjectCommondata();
        FirstAidInspectionModel GetDepartmentByUnit(int Unit);
    }
}
