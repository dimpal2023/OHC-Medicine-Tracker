using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IMedicineRecivingForm
    {
        MedicineReceivingFormModel GetMedicineReceivingFormData(MedicineReceivingFormModel model);
        MedicineReceivingFormModel GetMedicineReceivingFormById(MedicineReceivingFormModel model);
        MedicineReceivingFormModel AddOrEdit(MedicineReceivingFormModel model);
        MedicineReceivingFormModel GetProjectCommondata();
    }
}
