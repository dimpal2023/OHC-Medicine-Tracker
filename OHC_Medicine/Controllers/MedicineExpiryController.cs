using OHCBAL.Business;
using OHCBAL.Interface;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OHC_Medicine.Controllers
{
    public class MedicineExpiryController : BaseController
    {
        // GET: MedicineExpiry
        IMedicineExpiry PPC = new MedicineExpiryAccess();
        public ActionResult Expiry()
        {
            MedicineExpiryModel model = new MedicineExpiryModel();
            model.UserUnitID = Session["UserUnitId"].ToString();
            model = PPC.GetMedicineExpiryDate(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Expiry(MedicineExpiryModel model)
        {
            MedicineExpiryModel result = new MedicineExpiryModel();
            model.UserUnitID = Session["UserUnitId"].ToString();
            result = PPC.GetMedicineExpiryDate(model);
            return View(result);
        }
    }
}