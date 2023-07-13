using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class Emp_PatientModel
    {


        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Please Enter The EmployeeName")]
        public String EmployeeName { get; set; }
        //[Required(ErrorMessage = "Please Enter The EmployeeCode")]
        public String EmployeeCode { get; set; }
        [Required(ErrorMessage = "Please Enter The Dob")]
        public String Dob { get; set; }
        //public Nullable<System.DateTime> Dob { get; set; }
        [Required(ErrorMessage = "Please Enter The Address")]
        public String Address { get; set; }
        public String EmployeeType { get; set; }
        //public int IsActive { get; set; }
        //public String CreatedDate { get; set; }
        //public String CreatedBy { get; set; }
        //public String UpdatedDate { get; set; }
        //public String UpdatedBy { get; set; }

        public string IsActive { get; set; }
        public bool IsOutsideWorker { get; set; }
        public List<SelectListItem> _StatusList { get; set; }
        public string CreatedBy { get; set; }
        public string ReturnMessage { get; set; }
        public int ReturnCode { get; set; }


        public List<Emp_PatientModel> _Emp_PatientList { get; set; }




    }
}
