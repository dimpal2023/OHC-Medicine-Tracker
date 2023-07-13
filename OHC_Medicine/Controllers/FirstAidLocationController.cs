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
    public class FirstAidLocationController : BaseController
    {
        // GET: Account
        IFirstAidLocation PPC = new FirstAidLocationAccess();
        [HttpGet]
        public ActionResult List()
        {
            FALModel model = new FALModel();
            FALModel PPCm = new FALModel();
            PPCm = PPC.GetFirstAidLocationData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            FALModel model = new FALModel();
            model.Id = 0;
            model = PPC.GetProjectCommondata();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FALModel model)
        {
            FALModel PPCm = new FALModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "FirstAidLocation");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            FALModel PPCm = new FALModel();
            FALModel model = new FALModel();
            model.Id = ID;
            model.DepartmentName = PPCm.DepartmentName;
            PPCm = PPC.GetFirstAidLocationDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(FALModel model)
        {
            FALModel PPCm = new FALModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "FirstAidLocation");
            }
            else
            {
                return View();
            }
        }
    }
}