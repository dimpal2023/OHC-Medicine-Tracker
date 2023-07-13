using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class MedicineReceivingFormModel
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Please Select Medicine")]
        public string Medicinename { get; set; }
        public List<SelectListItem> _MedicineNameList { get; set; }
        [Required(ErrorMessage = "Please Enter the  HSN Number")]
        public string HSNNumber { get; set; }
        [Required(ErrorMessage = "Please Select Pack")]
        public string Pack { get; set; }
        public List<SelectListItem> _PackList { get; set; }
        [Required(ErrorMessage = "Please Enter Quantity")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "Please Enter Batch Number")]
        public string BatchNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Rate")]
        public Decimal Rate { get; set; }
        [Required(ErrorMessage = "Please Emter  Expiry Date")]
        public String ExpiryDate { get; set; }
        [Required(ErrorMessage = "Please Select Vender")]
        public String VenderName { get; set; }
        public List<SelectListItem> _VenderNameList { get; set; }
        public string CreatedBy { get; set; }
        public string ReturnMessage { get; set; }
        public int ReturnCode { get; set; }
        public List<MedicineReceivingFormModel> _MedicineReceivingFormModelList { get; set; }
    }
}
