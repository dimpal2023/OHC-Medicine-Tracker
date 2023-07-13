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
    public class AccountController : Controller
    {
        // GET: Account
        IAccount login = new AccountAccess();
        public ActionResult Index()
        {
            LoginModel model = new LoginModel();
            model.EncryptedUserId = Function.ReadCookie("EncryptedUserId");
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(LoginModel model)
        {
            LoginRespone result = login.Login(model);
            if (result.UserInfo != null && result.ReturnCode == "1")
            {
                Function.WriteCookie("EncryptedPNICode", Convert.ToString(result.UserInfo.PNICode));
                Function.WriteCookie("FP_LoggedUserName", result.UserInfo.FirstName);
                Function.WriteCookie("FP_LoggedUserType", Convert.ToString(result.UserInfo.UserType));
                Session["OHC_EncryptedUserId"] = result.UserInfo.UserId;
                Session["OHC_LoggedUserName"] = result.UserInfo.FirstName;
                Session["Password"] = result.UserInfo.Password;
                Session["OHC_UserEmail"] = result.UserInfo.Email;
                Session["PNICode"] = result.UserInfo.PNICode;
                Session["UserType"] = result.UserInfo.UserType;
                Session["UserUnitId"] = result.UserInfo.UnitID;
                if (result.UserInfo.UnitID == 1)
                {
                    Session["UnitName"] = "UNIT I";
                }
                else if (result.UserInfo.UnitID == 2)
                {
                    Session["UnitName"] = "UNIT II";
                }
                else if (result.UserInfo.UnitID == 3)
                {
                    Session["UnitName"] = "UNIT III";
                }
                else if (result.UserInfo.UnitID == 4)
                {
                    Session["UnitName"] = "UNIT IV";
                }
                else if (result.UserInfo.UnitID == 4)
                {
                    Session["UnitName"] = "UNIT IV (SANDILA)";
                }
                else if (result.UserInfo.UnitID == 4)
                {
                    Session["UnitName"] = "PNS";
                }
                return RedirectToAction("OHCDashboard", "Dashboard");
            }
            else
                ViewBag.Message = result.ReturnMessage;
            return View();
        }
        public ActionResult LogOut()
        {
            Function.DeleteCookie("EncryptedUserId");
            Function.DeleteCookie("FP_LoggedUserName");
            Function.DeleteCookie("FP_LoggedUserType");
            Session.Clear();
            Session.Abandon();
            return RedirectToAction("Index", "Account");
        }
        public ActionResult UserEmail()
        {
            LoginModel model = new LoginModel();
            model.EncryptedUserId = Function.ReadCookie("EncryptedUserId");
            return View(model);
        }
        [HttpPost]
        public ActionResult UserEmail(LoginModel model)
        {

            model.UserID = Function.ReadCookie("EncryptedUserId");
            Session["PPR_UserEmail"] = model.Email;
            LoginModel result = login.CheckUserEmail(model);

            if (result != null && result.ReturnCode > 0)
            {
                Session["UniqueCode"] = result.OTP;

                return RedirectToAction("OTP", "account");
            }
            else
                ViewBag.Message = result.ReturnMessage;
            return View();
        }

        public ActionResult OTP()
        {
            LoginModel model = new LoginModel();
            model.EncryptedUserId = Function.ReadCookie("EncryptedUserId");
            return View(model);
        }
        [HttpPost]
        public ActionResult OTP(LoginModel model)
        {
            LoginModel result = new LoginModel();
            model.UserID = Function.ReadCookie("EncryptedUserId");
            if (Session["UniqueCode"].ToString() == model.OTP)
            {
                return RedirectToAction("ResetPassword", "account", new { UserId = 0 });
            }
            else
                ViewBag.Message = "Please enter a valid OTP.";
            return View();
        }
        public ActionResult ResetPassword(string UserId)
        {
            LoginModel model = new LoginModel();
            model.UserID = UserId;
            return View(model);
        }
        [HttpPost]
        public ActionResult ResetPassword(LoginModel model)
        {
            LoginModel result = new LoginModel();
            model.UserID = Function.ReadCookie("EncryptedUserId");
            try
            {
                if (!string.IsNullOrEmpty(model.OldPassword))
                {
                    if (model.OldPassword == Session["Password"].ToString())
                    {
                        model.Email = Session["PPR_UserEmail"].ToString();
                        result = login.ChangePassword(model);
                        if (result != null)
                        {
                            Function.DeleteCookie("EncryptedUserId");
                            Function.DeleteCookie("FP_LoggedUserName");
                            Function.DeleteCookie("FP_LoggedUserType");
                            Session.Clear();
                            Session.Abandon();
                            TempData["ReturnMessage"] = result.ReturnMessage;
                            TempData["ReturnCode"] = result.ReturnCode;
                            ViewBag.Code = 17;
                            TempData["ChangePass"] = "U";
                            return RedirectToAction("Index", "account", new { ReturnMessage = result.ReturnMessage, result.ReturnCode });
                        }
                    }
                    else
                    {
                        ViewBag.Message = "Old password is not correct.";
                    }
                }
                else
                {
                    model.Email = Session["PPR_UserEmail"].ToString();
                    result = login.ChangePassword(model);
                    if (result != null)
                    {
                        Function.DeleteCookie("EncryptedUserId");
                        Function.DeleteCookie("FP_LoggedUserName");
                        Function.DeleteCookie("FP_LoggedUserType");
                        Session.Clear();
                        Session.Abandon();
                        TempData["ReturnMessage"] = result.ReturnMessage;
                        TempData["ReturnCode"] = result.ReturnCode;
                        return RedirectToAction("Index", "account", new { ReturnMessage = result.ReturnMessage, result.ReturnCode });
                    }
                }
                return View(model); ;
            }
            catch (Exception ex)
            {
                //ApplicationLogger.LogError(ex, "AccountController", "ResetPassword");
                return View(); ;
            }

        }
    }
}