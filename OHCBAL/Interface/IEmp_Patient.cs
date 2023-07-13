using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Interface
{
    public interface IEmp_Patient
    {
        Emp_PatientModel GetEmp_PatientData(Emp_PatientModel model);
        Emp_PatientModel GetEmp_PatientDataById(Emp_PatientModel model); 
         Emp_PatientModel AddOrEdit(Emp_PatientModel model);
    }
}

