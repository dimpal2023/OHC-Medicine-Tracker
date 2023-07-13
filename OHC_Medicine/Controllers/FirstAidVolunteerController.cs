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
    public class FirstAidVolunteerController : BaseController
    {
        // GET: Account
        IFirstAidVolunteer PPC = new FirstAidVolunteerAccess();
        [HttpGet]
        public ActionResult List()
        {
            FAVModel model = new FAVModel();
            FAVModel PPCm = new FAVModel();
            PPCm = PPC.GetFirstAidVolunteerData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            FAVModel model = new FAVModel();
            model.Id = 0;
            model = PPC.GetProjectCommondata();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FAVModel model)
        {
            FAVModel PPCm = new FAVModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);

            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "FirstAidVolunteer");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int ID)
        {
            FAVModel PPCm = new FAVModel();
            FAVModel model = new FAVModel();
            model.Id = ID;
            model.DepartmentName = PPCm.DepartmentName;
            PPCm = PPC.GetFirstAidVolunteerDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(FAVModel model)
        {
            FAVModel PPCm = new FAVModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "FirstAidVolunteer");
            }
            else
            {
                return View();
            }
        }
    }
}