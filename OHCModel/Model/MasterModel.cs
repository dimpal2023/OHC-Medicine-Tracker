using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class DepartmentMasterModel
    {
        [Required(ErrorMessage = "Please Select Unit")]
        public string Unit { get; set; }
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter The Department Name")]
        public string DepartmentName { get;set; }
        [Required(ErrorMessage = "Please Enter The Status")]
        public string Status { get;set; } 
        public List<SelectListItem> _StatusList { get;set; } 
        public List<SelectListItem> _UnitList { get;set; } 
        public string CreatedBy {get;set; } 
        public string ReturnMessage {get;set; } 
        public int ReturnCode {get;set; }
        public List<DepartmentMasterModel> _DepartmentMasterModelList { get; set; }
    }
}
