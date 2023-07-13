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
    public class FirstAidInspectionController : BaseController
    {
        // GET: Account
        IFirstAidInspection PPC = new FirstAidInspectionAccess();
        [HttpGet]
        public ActionResult List()
        {
            FirstAidInspectionModel model = new FirstAidInspectionModel();
            FirstAidInspectionModel PPCm = new FirstAidInspectionModel();
            PPCm = PPC.GetFirstAidInspectionData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            FirstAidInspectionModel model = new FirstAidInspectionModel();
            model.FirstAidInspectionID = 0;
            model = PPC.GetProjectCommondata();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(FirstAidInspectionModel model)
        {
            FirstAidInspectionModel PPCm = new FirstAidInspectionModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm.FirstAidInspectionID = model.FirstAidInspectionID;
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "FirstAidInspection");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            FirstAidInspectionModel PPCm = new FirstAidInspectionModel();
            FirstAidInspectionModel model = new FirstAidInspectionModel();
            model.FirstAidInspectionID = ID;
            model.DepartmentName=PPCm.DepartmentName;
            PPCm = PPC.GetFirstAidInspectionById(model);
            PPCm.FirstAidInspectionID = ID;
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(FirstAidInspectionModel model)
        {
            FirstAidInspectionModel PPCm = new FirstAidInspectionModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm.FirstAidInspectionID = model.FirstAidInspectionID;
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "FirstAidInspection");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult GetDepartmentOnSelectUnit(int Unitid)
        {
            FirstAidInspectionModel PPCm = new FirstAidInspectionModel();
            FirstAidInspectionModel model = new FirstAidInspectionModel();
            PPCm = PPC.GetDepartmentByUnit(Unitid);
            return View(PPCm);
        }

    }
}
