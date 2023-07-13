using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IMedicineRequisitionFrom
    {
        MedicineRequisitionFromModel GetMedicineRequisitionData(MedicineRequisitionFromModel model);
        MedicineRequisitionFromModel GetMedicineRequisitionById(MedicineRequisitionFromModel model);
        MedicineRequisitionFromModel AddOrEdit(MedicineRequisitionFromModel model);
        MedicineRequisitionFromModel GetProjectCommondata();
        MedicineRequisitionFromModel GetDepartmentByUnit(int Unit);
    }
}
