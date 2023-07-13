using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class MedicineRequisitionFromModel
    {
        public int MedicineRequisitionID { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Please Select Unit")]
        public string Unit { get; set; }
        public List<SelectListItem> _DepartmentList { get; set; }
        public List<SelectListItem> _UnitList { get; set; }
        [Required(ErrorMessage = "Please Select Medicinename")]
        public string Medicinename { get; set; }
        public List<SelectListItem> _MedicineList { get; set; }
        [Required(ErrorMessage = "Please Enter Qty")]
        public int Qty { get; set; }
        public int UserUnitID { get; set; }
        //[Required(ErrorMessage = "Please Enter BatchNo")]
        public string Remark { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string ReturnMessage { get; set; }
        public int ReturnCode { get; set; }
        public List<MedicineRequisitionFromModel> _MedicineRequisitionFromList { get; set; }
        public List<DetailsofMedicineRequisition> _DetailsofMedicineRequisitionList { get; set; }
    }
    public class DetailsofMedicineRequisition
    {
        public string Medicinename { get; set; }
        public int Qty { get; set; }
        public string Remark { get; set; }
    }
}

