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
    public class ExceptionController : Controller
    {
       IExceptions exc = new ExceptionAccess();
        public ActionResult Index()
        {
            ExceptionModels model = new ExceptionModels();
            ExceptionModels PPCm = new ExceptionModels();
            
            PPCm = exc.GetExceptionData();
            return View(PPCm);
        }
    }
}