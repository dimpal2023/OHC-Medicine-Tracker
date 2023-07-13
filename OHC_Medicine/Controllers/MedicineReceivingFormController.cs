//using FPDAL.Data;
using OHC_Medicine.Models;
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
    public class MedicineReceivingFormController : BaseController
    {
        // GET: Account
        IMedicineRecivingForm PPC = new MedicineReceivingFormAccess();
        [HttpGet]
        public ActionResult List()
        {
            MedicineReceivingFormModel model = new MedicineReceivingFormModel();
            MedicineReceivingFormModel PPCm = new MedicineReceivingFormModel();
            PPCm = PPC.GetMedicineReceivingFormData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            MedicineReceivingFormModel model = new MedicineReceivingFormModel();
            model.id = 0;
            model = PPC.GetProjectCommondata();
            return View(model);
        }
        [HttpPost]
        public ActionResult Create(MedicineReceivingFormModel model)
        {
            MedicineReceivingFormModel PPCm = new MedicineReceivingFormModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicineReceivingForm");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            MedicineReceivingFormModel PPCm = new MedicineReceivingFormModel();
            MedicineReceivingFormModel model = new MedicineReceivingFormModel();
            model.id = ID;
            PPCm = PPC.GetMedicineReceivingFormById(model);
            PPCm.Medicinename = PPCm.Medicinename;
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(MedicineReceivingFormModel model)
        {
            MedicineReceivingFormModel PPCm = new MedicineReceivingFormModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicineReceivingForm");
            }
            else
            {
                return View();
            }
        }
    }
}