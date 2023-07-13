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
    public class DepartmentMasterController : BaseController
    {
        // GET: Account
        IMaster PPC = new MasterAccess();
        [HttpGet]
        public ActionResult List()
        {
            DepartmentMasterModel model = new DepartmentMasterModel();
            DepartmentMasterModel PPCm = new DepartmentMasterModel();
            PPCm = PPC.GetDepartmentMasterData(model);
            return View(PPCm);
        }

        public ActionResult Create()
        {
            DepartmentMasterModel model = new DepartmentMasterModel();
            model.Id = 0;
            model = PPC.GetProjectCommondata();
            model._StatusList = UtilityAccess.StatusListCategory();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(DepartmentMasterModel model)
        {
            DepartmentMasterModel PPCm = new DepartmentMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "DepartmentMaster");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        { 
            DepartmentMasterModel model = new DepartmentMasterModel();
            model.Id = ID;
            model = PPC.GetDepartmentMasterDataById(model);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(DepartmentMasterModel model)
        {
            DepartmentMasterModel PPCm = new DepartmentMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "DepartmentMaster");
            }
            else
            {
                return View();
            }
        }
    }
}