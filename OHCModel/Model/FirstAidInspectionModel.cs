using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class FirstAidInspectionModel
    {
        public int FirstAidInspectionID { get; set; }
        
        //[Required(ErrorMessage = "Please Select Inspection Type")]
        public string InspectionType { get; set; }
        public List<SelectListItem> _InspectionTypeList { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Please Select Unit")]
        public string Unit { get; set; }
        public List<SelectListItem> _DepartmentList { get; set; }

        public List<SelectListItem> _UnitList { get; set; }
        [Required(ErrorMessage = "Please Select Medicine")]
        public string Medicinename { get; set; }
        public List<SelectListItem> _MedicineList { get; set; }
        [Required(ErrorMessage = "Please Enter The Date Of Inspection")]
        public string DateOfInspection { get; set; }
        [Required(ErrorMessage = "Please Select Medicine")]
        public string Location { get; set; }
        public List<SelectListItem> _LocationList { get; set; }
        [Required(ErrorMessage = "Please Enter The Shift")]
        public string Shift { get; set; }
        [Required(ErrorMessage = "Please Enter The Frequency")]
        public string Frequency { get; set; }
        [Required(ErrorMessage = "Please Enter The Next Due On")]
        public string NextDueOn { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string ReturnMessage { get; set; }
        public int ReturnCode { get; set; }
        public List<FirstAidInspectionModel> _FirstAidInspectionModelList { get; set; }
        public List<DetailsFirstAidInspection> _DetailsFirstAidInspectionList { get; set; }
    }
    public class DetailsFirstAidInspection
    {
        [Required(ErrorMessage = "Please Select Medicine")]
        public string Medicinename { get; set; }
        [Required(ErrorMessage = "Please Enter The Freeze Quantity")]
        public int FreezeQty { get; set; }
        [Required(ErrorMessage = "Please Enter The Available Quantity")]
        public int AvailableQty { get; set; }
        [Required(ErrorMessage = "Please Enter The Date of Exp")]
        public string DateofExp { get; set; }
        //[Required(ErrorMessage = "Please Enter The Remark")]
        public string Remark { get; set; }
    }
}

