using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace OHCModel.Model
{
    public  class MedicineExpiryModel
    {
        public string MedicineId { get;set; }   
        public string MedicineName { get;set; }
        public string Status { get;set; }
        public string MedicineType { get; set; }
        public string MedicineExpiryDate { get;set; }   
        public string Quantity { get; set; }
        public string Name { get; set; }
        public string UserUnitID { get; set; }
        public int UnitID { get; set; }
        public List<SelectListItem> _MedicineNameList { get; set; }
        public List<MedicineExpiryModel> medicineExpiryModels { get; set; } 
                            
    }
}
