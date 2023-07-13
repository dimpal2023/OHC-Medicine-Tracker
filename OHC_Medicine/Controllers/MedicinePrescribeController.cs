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
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace OHC_Medicine.Controllers
{
    public class MedicinePrescribeController : BaseController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OHC"].ConnectionString);
        // GET: Account
        IMedicinePrescribe PPC = new MedicinePrescribeAccess();
        [HttpGet]
        public ActionResult List()
        {
            MedicinePrescribeModel model = new MedicinePrescribeModel();
            MedicinePrescribeModel PPCm = new MedicinePrescribeModel();
            //PPCm = PPC.MedicinePrescribeData(model);
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            PPCm = PPC.GetMedicinePrescribeData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            MedicinePrescribeModel model = new MedicinePrescribeModel();
            model.Id = 0;
            DateTime date= DateTime.Today;
            model = PPC.GetProjectCommondata();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MedicinePrescribeModel model, string[] test1, string[] test2)
        {
            MedicinePrescribeModel PPCm = new MedicinePrescribeModel();
            model.CreatedBy = Session["PNICode"].ToString();
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            if(string.IsNullOrEmpty(model.AttendeeName))
            {
                model.AttendeeName = model.AttendeeNameforOutsideEmp;
            }
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicinePrescribe");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            MedicinePrescribeModel PPCm = new MedicinePrescribeModel();
            MedicinePrescribeModel model = new MedicinePrescribeModel();
            model.Id = ID;
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            PPCm = PPC.GetMedicinePrescribeDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(MedicinePrescribeModel model)
        {
            MedicinePrescribeModel PPCm = new MedicinePrescribeModel();
            model.CreatedBy = Session["PNICode"].ToString();
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            if (model.MasterDepartment!=null)
            {
                model.Department = model.DepartmentID;
            }
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicinePrescribe");
            }
            else
            {
                return View();
            }
        }
        
        public JsonResult MedicineTreatmentSlip(int Id)
        {
            MedicinePrescribeModel PPCm = new MedicinePrescribeModel();
            MedicinePrescribeModel model = new MedicinePrescribeModel();
            model.Id = Id;
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            PPCm = PPC.GetMedicinePrescribeDataById(model);
            return Json(PPCm, JsonRequestBehavior.AllowGet);
        }
    }
}