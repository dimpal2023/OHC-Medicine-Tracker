using OHCBAL.Business;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace OHC_Medicine.Controllers
{
    public class UtilityController : Controller
    {
        // GET: Utility
        [HttpPost]
        public ActionResult GetDepartment(String UnitId, Boolean IsAll)
        {
            if (String.IsNullOrEmpty(UnitId))
                UnitId = "0";
            UtilityAccess utilityAccess = new UtilityAccess();
            var stateData = utilityAccess.DepartmentByUnit(Convert.ToInt32(UnitId),IsAll);
            return Json(stateData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetLocation(String DepartmentId, Boolean IsAll)
        {
            if (String.IsNullOrEmpty(DepartmentId))
                DepartmentId = "0";
            UtilityAccess utilityAccess = new UtilityAccess();
            var stateData = utilityAccess.LocationByDepartment(Convert.ToInt32(DepartmentId), IsAll);
            return Json(stateData, JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetMedicineDetail(String MedicineID, Boolean IsAll)
        {
            if (String.IsNullOrEmpty(MedicineID))
                MedicineID = "0";
            int UserUnitID = Convert.ToInt32(Session["UserUnitId"]);
            UtilityAccess utilityAccess = new UtilityAccess();
            var stateData = utilityAccess.MedicineDetails(Convert.ToInt32(MedicineID), Convert.ToInt32(UserUnitID));
            return Json(stateData, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult FindEmployee_Data(string query, int Type)
        {
            //List<UserMasterModel> result = new List<UserMasterModel>();
            UserMasterModel result1 = new UserMasterModel();
            query = query.ToUpper();
            try
            {
                UserMasterModel PPCm = new UserMasterModel();
                UtilityAccess utilityAccess = new UtilityAccess();
                PPCm.Unit = Type;
                PPCm.EmployeeCode = query;
                PPCm = utilityAccess.FindEmployee_Data(PPCm);

                var result = PPCm._UserMasterModelList;
                var list = (from q in result
                            select new { Name = q.UserName, Empid = q.EmployeeCode, EMAIL = q.Email, Dob = q.Dob, Address = q.Address, EmpType = q.EmpType, Mobile = q.Mobile,DepartMent= q.Department }).ToList();

                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(result1, JsonRequestBehavior.AllowGet);
            }
        }
    }
}