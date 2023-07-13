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
    public class Emp_PatientController : BaseController
    {
        // GET: Account
        IEmp_Patient PPC = new Emp_PatientAccess();
        [HttpGet]
        public ActionResult List()
        {
            Emp_PatientModel model = new Emp_PatientModel();
            Emp_PatientModel PPCm = new Emp_PatientModel();
            //PPCm = PPC.UserMasterData(model);
            PPCm = PPC.GetEmp_PatientData(model);

            return View(PPCm);
        }

        public ActionResult Create()
        {
            Emp_PatientModel model = new Emp_PatientModel();
            model.EmployeeId = 0;
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Emp_PatientModel model)
        {
            Emp_PatientModel PPCm = new Emp_PatientModel();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "Emp_Patient");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            Emp_PatientModel PPCm = new Emp_PatientModel();
            Emp_PatientModel model = new Emp_PatientModel();
            model.EmployeeId = ID;
            PPCm = PPC.GetEmp_PatientDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(Emp_PatientModel model)
        {
            Emp_PatientModel PPCm = new Emp_PatientModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "Emp_Patient");
            }
            else
            {
                return View();
            }
        }
    }
}