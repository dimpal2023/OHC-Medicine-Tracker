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
    public class DashboardController : BaseController
    {
        // GET: Account
        IDashboardDetail PPC = new DashboardDetailAccess();
        public ActionResult OHCDashboard()
        {
            DashboardModel model = new DashboardModel();
            DashboardModel PPCm = new DashboardModel();
            model.UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            model.CreatedBy = Session["PNICode"].ToString();
            PPCm = PPC.GetDashboardData(model);
            PPCm.UserUnitID = model.UserUnitID;
            return View(PPCm);
        }
    }
}