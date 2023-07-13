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
    public class VendorMasterController : BaseController
    {
        // GET: Account
        IVendorMaster PPC = new VendorMasterAccess();
        [HttpGet]
        public ActionResult List()
        {
            VendorMasterModel model = new VendorMasterModel();
            VendorMasterModel PPCm = new VendorMasterModel();
            //PPCm = PPC.UserMasterData(model);
            PPCm = PPC.GetVendorMasterData(model);

           

            return View(PPCm);
        }

        public ActionResult Create()
        {
            VendorMasterModel model = new VendorMasterModel();
            model.VendorId = 0;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(VendorMasterModel model)
        {
            VendorMasterModel PPCm = new VendorMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "VendorMaster");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            VendorMasterModel PPCm = new VendorMasterModel();
            VendorMasterModel model = new VendorMasterModel();
            model.VendorId = ID;
            PPCm = PPC.GetVendorMasterDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(VendorMasterModel model)
        {
            VendorMasterModel PPCm = new VendorMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "VendorMaster");
            }
            else
            {
                return View();
            }
        }
    }
}