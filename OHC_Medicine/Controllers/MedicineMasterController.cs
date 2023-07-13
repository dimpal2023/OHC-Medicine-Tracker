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
    public class MedicineMasterController : BaseController
    {
        // GET: Account
        IMedicineMaster PPC = new MedicineMasterAccess();
        [HttpGet]
        public ActionResult List()
        {
            MedicineMasterModel model = new MedicineMasterModel();
            model = PPC.GetMedicineMasterData(model);
            return View(model);
        }

        public ActionResult Create()
        {
            MedicineMasterModel model = new MedicineMasterModel();
            MedicineMasterModel PPCm = new MedicineMasterModel();
            model.Id = 0;
            model._StatusList = UtilityAccess.StatusListCategory();
            //model._MedicineType = UtilityAccess.DrpPackList(1);
            PPCm = PPC.GetProjectCommondata();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MedicineMasterModel model)
        {
            MedicineMasterModel PPCm = new MedicineMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicineMaster");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            MedicineMasterModel model = new MedicineMasterModel();
            model.Id = ID;
            model = PPC.GetMedicineMasterDataById(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(MedicineMasterModel model)
        {
            MedicineMasterModel PPCm = new MedicineMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicineMaster");
            }
            else
            {
                return View();
            }
        }
    }
}