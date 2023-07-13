using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class MedicineMasterModel
    { 
        public int Id { get; set; }
        [Required(ErrorMessage = "Please enter the Medicine Name")]
        public string MedicineName { get;set; }
        [Required(ErrorMessage = "Please Select Type")]
        public string Type { get; set; }
        public List<SelectListItem> _MedicineType { get; set; }

        public string Status { get;set; } 
        public string Remark { get;set; } 
        public List<SelectListItem> _StatusList { get;set; } 
        public string CreatedBy {get;set; } 
        public string ReturnMessage {get;set; } 
        public int ReturnCode {get;set; }
        public List<MedicineMasterModel> _MedicineMasterModel { get; set; }
    }
}
