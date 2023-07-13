using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class FALModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter The Location Name")]
        public string LocationName { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public List<SelectListItem> _DepartmentList { get; set; }
        [Required(ErrorMessage = "Please Select Status")]
        public string Status { get; set; }
        public List<SelectListItem> _StatusList { get; set; }
        [Required(ErrorMessage = "Please Select Unit")]
        public string Unit { get; set; }
        public List<SelectListItem> _UnitList { get; set; }
        public string CreatedBy { get; set; }
        [Required(ErrorMessage = "Please Enter The Station Number")]
        public string StationNumber { get; set; }
        [Required(ErrorMessage = "Please Enter The Station Manager")]
        public string StationManager { get; set; }
        [Required(ErrorMessage = "Please Enter The Employee Code")]
        public string HdnEmployeeCode { get; set; }
        public string EmployeeCode { get; set; }
        public string ReturnMessage { get; set; }
        public int ReturnCode { get; set; }
        public List<FALModel> _FALModelList { get; set; }
    }
    public class FAVModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter The Volunteer Name")]
        public string VolunteerName{ get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public string DepartmentName { get; set; }
        public List<SelectListItem> _DepartmentList { get; set; }
        [Required(ErrorMessage = "Please Select Status")]
        public string Status { get; set; }
        public List<SelectListItem> _StatusList { get; set; }
        [Required(ErrorMessage = "Please Enter The EMPCode")]
        public string EMPCode{ get; set; }
        [Required(ErrorMessage = "Please Enter The Address")]
        public string Address{ get; set; }
        [Required(ErrorMessage = "Please Enter Mobile Number")]
        public string MobileNo{ get; set; }
        public string CreatedBy { get; set; }
        public string ReturnMessage { get; set; }
        public int ReturnCode { get; set; }
        [Required(ErrorMessage = "Please Select Unit")]
        public string Unit { get; set; }
        public List<SelectListItem> _UnitList { get; set; }
        public List<FAVModel> _FAVModelList { get; set; }
    }
}
