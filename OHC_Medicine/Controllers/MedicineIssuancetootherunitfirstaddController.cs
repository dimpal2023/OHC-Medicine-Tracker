//using FPDAL.Data;
using OHC_Medicine.Models;
using OHCBAL.Business;
using OHCBAL.Interface;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace OHC_Medicine.Controllers
{
    public class MedicineIssuancetootherunitfirstaddController : BaseController
    {
        // GET: Account
        IMedicineIssuanc PPC = new MedicineIssuanceAccess();
        [HttpGet]
        public ActionResult List()
        {
            MedicineIssuancetootherunitfirstaddModel model = new MedicineIssuancetootherunitfirstaddModel();
            MedicineIssuancetootherunitfirstaddModel PPCm = new MedicineIssuancetootherunitfirstaddModel();
            PPCm = PPC.GetMedicineIssuancData(model);
            return View(PPCm);
        }
        public ActionResult Create(int ID)
        {
            MedicineIssuancetootherunitfirstaddModel PPCm = new MedicineIssuancetootherunitfirstaddModel();
            MedicineIssuancetootherunitfirstaddModel model = new MedicineIssuancetootherunitfirstaddModel();
            
            if (ID == 0)
            {
                model.MedicineIssuanceID = 0;
                model = PPC.GetProjectCommondata();
                return View(model);
            }
            else
            {
                model.MedicineIssuanceID = ID;
                model.DepartmentName = PPCm.DepartmentName;
                model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
                PPCm = PPC.GetMedicineRequsetDataById(model);
                //PPCm.MedicineIssuanceID = model.MedicineIssuanceID;
                return View(PPCm);
            }
            
        }
        
        [HttpPost]
        public ActionResult Create(MedicineIssuancetootherunitfirstaddModel model)
        {
            MedicineIssuancetootherunitfirstaddModel PPCm = new MedicineIssuancetootherunitfirstaddModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm.MedicineIssuanceID = model.MedicineIssuanceID;
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicineIssuancetootherunitfirstadd");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            MedicineIssuancetootherunitfirstaddModel PPCm = new MedicineIssuancetootherunitfirstaddModel();
            MedicineIssuancetootherunitfirstaddModel model = new MedicineIssuancetootherunitfirstaddModel();
            model.MedicineIssuanceID = ID;
            model.DepartmentName = PPCm.DepartmentName;
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            PPCm = PPC.GetMedicineIssuancById(model);
            PPCm.MedicineIssuanceID=model.MedicineIssuanceID;
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(MedicineIssuancetootherunitfirstaddModel model)
        {
            MedicineIssuancetootherunitfirstaddModel PPCm = new MedicineIssuancetootherunitfirstaddModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm.MedicineIssuanceID = model.MedicineIssuanceID;
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicineIssuancetootherunitfirstadd");
            }
            else
            {
                return View();
            }
        }
        //[HttpPost]
        //public ActionResult GetDepartmentOnSelectUnit(int Unitid)
        //{
        //    MedicineIssuancetootherunitfirstaddModel PPCm = new MedicineIssuancetootherunitfirstaddModel();
        //    MedicineIssuancetootherunitfirstaddModel model = new MedicineIssuancetootherunitfirstaddModel();
        //    PPCm = PPC.GetDepartmentByUnit(Unitid);
        //    return View(PPCm);
        //}
    }
}
