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
    public class MedicineRequisitionFromController : BaseController
    {
        // GET: Account
        IMedicineRequisitionFrom PPC = new MedicineRequisitionFromAccess();
        [HttpGet]
        public ActionResult List()
        {
            MedicineRequisitionFromModel model = new MedicineRequisitionFromModel();
            MedicineRequisitionFromModel PPCm = new MedicineRequisitionFromModel();
           model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            PPCm = PPC.GetMedicineRequisitionData(model);
            return View(PPCm);
        }
        public ActionResult Create()
        {
            MedicineRequisitionFromModel model = new MedicineRequisitionFromModel();
            model.MedicineRequisitionID = 0;
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            model = PPC.GetProjectCommondata();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(MedicineRequisitionFromModel model)
        {
            MedicineRequisitionFromModel PPCm = new MedicineRequisitionFromModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm.MedicineRequisitionID = model.MedicineRequisitionID;
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicineRequisitionFrom");
            }
            else
            {
                return View();
            }
        }

        public ActionResult Edit(int ID)
        {
            MedicineRequisitionFromModel PPCm = new MedicineRequisitionFromModel();
            MedicineRequisitionFromModel model = new MedicineRequisitionFromModel();
            model.MedicineRequisitionID = ID;
            model.DepartmentName = PPCm.DepartmentName;
            PPCm = PPC.GetMedicineRequisitionById(model);
            PPCm.MedicineRequisitionID = model.MedicineRequisitionID;
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(MedicineRequisitionFromModel model)
        {
            MedicineRequisitionFromModel PPCm = new MedicineRequisitionFromModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm.MedicineRequisitionID = model.MedicineRequisitionID;
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "MedicineRequisitionFrom");
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public ActionResult GetDepartmentOnSelectUnit(int Unitid)
        {
            MedicineRequisitionFromModel PPCm = new MedicineRequisitionFromModel();
            MedicineRequisitionFromModel model = new MedicineRequisitionFromModel();
            PPCm = PPC.GetDepartmentByUnit(Unitid);
            return View(PPCm);
        }

    }
}
