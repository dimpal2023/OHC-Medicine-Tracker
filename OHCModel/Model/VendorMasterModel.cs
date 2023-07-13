using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public class VendorMasterModel
    {


        public int VendorId { get; set; }
        [Required(ErrorMessage = "Please Enter The Vendor Name")]
        public String VendorName { get; set; }
        [Required(ErrorMessage = "Please Enter The Address")]
        public String Address { get; set; }
        [Required(ErrorMessage = "Please Enter The License No.")]
        public String LicenseNo { get; set; }
        //public int IsActive { get; set; }
        //public String CreatedDate { get; set; }
        //public String CreatedBy { get; set; }
        //public String UpdatedDate { get; set; }
        //public String UpdatedBy { get; set; }

        public string IsActive { get; set; }
        //public string Status { get; set; }
        public List<SelectListItem> _StatusList { get; set; }
        public string CreatedBy { get; set; }
        public string ReturnMessage { get; set; }
        public int ReturnCode { get; set; }


        public List<VendorMasterModel> _VendorMasterList { get; set; }
     


    }
}
