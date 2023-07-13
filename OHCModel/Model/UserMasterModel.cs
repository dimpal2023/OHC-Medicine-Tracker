using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class UserMasterModel
    {
         
        public int UserId { get; set; }
        [Required(ErrorMessage = "Please Enter The User Name")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Please Enter The Password")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Please Enter The Email")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Please enter valid email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter The Employee Code")]
        public string EmployeeCode { get; set; }
        [Required(ErrorMessage = "Please Select  Department Name")]
        public int DepartmentId { get; set; }
        [Required(ErrorMessage = "Please Select  Unit")]
       
        public int Unit { get; set; }
        [Required(ErrorMessage = "Please Enter The Employee Type")]
        public string EmpType { get; set; }
        public List<SelectListItem> _EmpTypeList { get; set; }

        //[Required(ErrorMessage = "Please enter the Status")]
        public string IsActive { get; set; }
        //public string Status { get; set; }
        public List<SelectListItem> _StatusList { get; set; }
        public string CreatedBy { get; set; }
        public string ReturnMessage { get; set; }
        public int ReturnCode { get; set; }
        public List<UserMasterModel> _UserMasterModelList { get; set; }
        public List<SelectListItem> _DepartmentList { get; set; }
        public List<SelectListItem> _UnitList { get; set; }
        public string Department { get; set; }
        public string Dob { get; set; }
        public string Address { get; set; }
        public string Mobile { get; set; }

    }
}
