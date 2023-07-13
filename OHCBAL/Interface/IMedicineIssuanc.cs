using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IMedicineIssuanc
    {
        MedicineIssuancetootherunitfirstaddModel GetMedicineIssuancData(MedicineIssuancetootherunitfirstaddModel model);
        MedicineIssuancetootherunitfirstaddModel GetMedicineIssuancById(MedicineIssuancetootherunitfirstaddModel model);
        MedicineIssuancetootherunitfirstaddModel GetMedicineRequsetDataById(MedicineIssuancetootherunitfirstaddModel model);
        MedicineIssuancetootherunitfirstaddModel AddOrEdit(MedicineIssuancetootherunitfirstaddModel model);
        MedicineIssuancetootherunitfirstaddModel GetProjectCommondata();
        //MedicineIssuancetootherunitfirstaddModel GetDepartmentByUnit(int Unit);
    }
}
