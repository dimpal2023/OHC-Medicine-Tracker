using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace OHCModel.Model
{
    public class MedicineIssuancetootherunitfirstaddModel
    {
        public int MedicineIssuanceID { get; set; }
        [Required(ErrorMessage = "Please Select Department")]
        public string DepartmentName { get; set; }
        [Required(ErrorMessage = "Please Select Unit")]
        public string Unit { get; set; }
        public List<SelectListItem>_DepartmentList { get; set; }
        public List<SelectListItem>_UnitList { get; set; }
        [Required(ErrorMessage = "Please Enter the Issue Date")]
        public string IssueDate { get; set; }
        [Required(ErrorMessage = "Please Select Medicine")]
        public string Medicinename { get; set; }
        public List<SelectListItem> _MedicineList { get; set; }
        [Required(ErrorMessage = "Please Enter the Quantity")]
        
        public int Qty { get; set; }
        public int UserUnitID { get; set; }
        public string AvailableQty { get; set; }
        [Required(ErrorMessage = "Please Enter The BatchNo")]
        public string BatchNo { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedDate { get; set; }
        public string UpdatedBy { get; set; }
        public string UpdatedDate { get; set; }
        public string ReturnMessage { get; set; }
        public int ReturnCode { get; set; }
        public List<MedicineIssuancetootherunitfirstaddModel> _MedicineIssuanceList { get; set; }
        public List<DetailsofMedicine> _DetailsofMedicineList { get; set; }
    }
    public class DetailsofMedicine 
    {
        //[Required(ErrorMessage = "Please Select Medicine")]
        public string Medicinename { get; set; }
        //[Required(ErrorMessage = "Please Enter The Quantity")]
        public int Qty { get; set; }
        public int AvailableQty { get; set; }
        //[Required(ErrorMessage = "Please Enter The BatchNo")]
        public string BatchNo { get; set; }
    }

}
