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
    public class InventoryTabularviewController : BaseController
    {
        // GET: Account
        IInventoryTabularView PPC = new InventoryTabularViewAccess();
        [HttpGet]
        public ActionResult List()
        {
            InventoryTabularViewModel model = new InventoryTabularViewModel();
            InventoryTabularViewModel PPCm = new InventoryTabularViewModel();
            PPCm = PPC.GetTabularViewData();
            return View(PPCm);
        }
    }
}