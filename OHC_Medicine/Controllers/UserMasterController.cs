//using FPDAL.Data;
using OHC_Medicine.Models;
using OHCBAL.Business;
using OHCBAL.Interface;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Web;
using System.Web.Mvc;



namespace OHC_Medicine.Controllers
{
    public class UserMasterController : BaseController
    {
        // GET: Account
        IUserMaster PPC = new UserMasterAccess();
        [HttpGet]
        public ActionResult List()
        {
            UserMasterModel model = new UserMasterModel();
            UserMasterModel PPCm = new UserMasterModel();
            //PPCm = PPC.UserMasterData(model);
            
            PPCm = PPC.GetUserMasterData(model);
         
            return View(PPCm);
        }
        public ActionResult Create()
        {
            UserMasterModel model = new UserMasterModel();
            model.UserId = 0;

            model = PPC.GetProjectCommondata();
            //model._StatusList = UtilityAccess.StatusListCategory();

            return View(model);
        }
        [HttpPost]
        public ActionResult Create(UserMasterModel model)
        {
            UserMasterModel PPCm = new UserMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "UserMaster");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Edit(int ID)
        {
            UserMasterModel PPCm = new UserMasterModel();
            UserMasterModel model = new UserMasterModel();
            model.UserId = ID;
            model.DepartmentId=PPCm.DepartmentId;

            PPCm = PPC.GetUserMasterDataById(model);
            return View(PPCm);
        }
        [HttpPost]
        public ActionResult Edit(UserMasterModel model)
        {
            UserMasterModel PPCm = new UserMasterModel();
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.AddOrEdit(model);
            if (PPCm != null)
            {
                TempData["ReturnMessage"] = PPCm.ReturnMessage;
                TempData["ReturnCode"] = PPCm.ReturnCode;
                return RedirectToAction("List", "UserMaster");
            }
            else
            {
                return View();
            }
        }
       
    }
}