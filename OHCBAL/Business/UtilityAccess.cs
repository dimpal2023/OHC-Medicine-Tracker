using OHCDAL.Data;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace OHCBAL.Business
{
    public class UtilityAccess : System.Web.Mvc.ActionFilterAttribute
    {
        //public static string BaseUrl = ConfigurationManager.AppSettings["baseurl"].ToString();
        public enum DropdownType
        {
            All = 0,
            Required = 1,
            NoRequired = 2,
        }
        private UtilityData utilityData = new UtilityData();
        public static List<SelectListItem> DepartmentList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                DropdownType drpType = (DropdownType)Type;
                switch (drpType)
                {
                    case DropdownType.All:
                        _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                        break;
                    case DropdownType.Required:
                        _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                        break;
                    case DropdownType.NoRequired:
                        _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                        break;
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["DepartmentName"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static List<SelectListItem> DropDownList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                DropdownType drpType = (DropdownType)Type;
                switch (drpType)
                {
                    case DropdownType.All:
                        _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                        break;
                    case DropdownType.Required:
                        _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                        break;
                    case DropdownType.NoRequired:
                        _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                        break;
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["Value"]), Text = Convert.ToString(row["Text"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }

        public static List<SelectListItem> MedDropDownList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                DropdownType drpType = (DropdownType)Type;
                switch (drpType)
                {
                    case DropdownType.All:
                        _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                        break;
                    case DropdownType.Required:
                        _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                        break;
                    case DropdownType.NoRequired:
                        _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                        break;
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["Name"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static List<SelectListItem> UnitList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            try
            {
                DropdownType drpType = (DropdownType)Type;
                switch (drpType)
                {
                    case DropdownType.All:
                        _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                        break;
                    case DropdownType.Required:
                        _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                        break;
                    case DropdownType.NoRequired:
                        _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                        break;
                }
                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        _items.Add(new SelectListItem { Value = Convert.ToString(row["ID"]), Text = Convert.ToString(row["Unit"]) });
                    }
                }
                return _items;
            }
            catch (Exception ex)
            {
                ///ApplicationLogger.LogError(ex, "UtilityAccess", "RenderCountryList");
                return _items;
            }
        }
        public static List<SelectListItem>DrpPackList(DataTable dt, Int32 Type)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            DropdownType drpType = (DropdownType)Type;
            switch (drpType)
            {
                case DropdownType.All:
                    _items.Add(new SelectListItem { Value = "-1", Text = "All" });
                    break;
                case DropdownType.Required:
                    _items.Add(new SelectListItem { Value = "", Text = "--Select--" });
                    break;
                case DropdownType.NoRequired:
                    _items.Add(new SelectListItem { Value = "0", Text = "--Select--" });
                    break;
            }
            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    _items.Add(new SelectListItem { Value = Convert.ToString(row["Value"]), Text = Convert.ToString(row["Text"]) });
                }
            }
            return _items;
            //_items.Add(new SelectListItem { Value = "Capsule", Text = "Capsule" });
            //_items.Add(new SelectListItem { Value = "Tablet", Text = "Tablet" });
            //_items.Add(new SelectListItem { Value = "Syrup", Text = "Syrup" });
            //_items.Add(new SelectListItem { Value = "Powder", Text = "Powder" });
            //return _items;
        }
        public static List<SelectListItem> DrpInspectionTypeList()
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            //dropdowntype drptype = (dropdowntype)type;
            //switch (drptype)
            //{
                //case dropdowntype.all:
                //    _items.add(new selectlistitem { value = "-1", text = "all" });
                //    break;
                //case dropdowntype.required:
                //    _items.add(new selectlistitem { value = "", text = "--select--" });
                //    break;
                //case dropdowntype.norequired:
                //    _items.add(new selectlistitem { value = "0", text = "--select--" });
                //    break;
            //}
            _items.Add(new SelectListItem { Value = "FirstAid", Text = "First Aid" });
            _items.Add(new SelectListItem { Value = "Ambulance", Text = "Ambulance" });
            _items.Add(new SelectListItem { Value = "EmergencyKit", Text = "Emergency Kit" });
            return _items;
        }
        public static List<SelectListItem> StatusListCategory()
        {
            List<SelectListItem> _items = new List<SelectListItem>(); 
            _items.Add(new SelectListItem { Value = "1", Text = "Active" });
            _items.Add(new SelectListItem { Value = "2", Text = "Inactive" });
            return _items;
        }
        public static List<SelectListItem> RenderList(DataTable dt, int Type)
        {
            List<SelectListItem> list = new List<SelectListItem>();
            try
            {
                switch (Type)
                {
                    case 0:
                        list.Add(new SelectListItem
                        {
                            Value = "-1",
                            Text = "All"
                        });
                        break;
                    case 1:
                        list.Add(new SelectListItem
                        {
                            Value = "",
                            Text = "--Select--"
                        });
                        break;
                    case 2:
                        list.Add(new SelectListItem
                        {
                            Value = "0",
                            Text = "--Select--"
                        });
                        break;
                }

                if (dt != null && dt.Rows.Count > 0)
                {
                    foreach (DataRow row in dt.Rows)
                    {
                        list.Add(new SelectListItem
                        {
                            Value = Convert.ToString(row["Value"]),
                            Text = Convert.ToString(row["Text"])
                        });
                    }
                }

                return list;
            }
            catch (Exception ex)
            {
                //ApplicationLogger.LogError(ex, "UtilityAccess", "RenderList");
                return list;
            }
        }
        public List<SelectListItem> DepartmentByUnit(int CountryId, bool IsAll)
        {
            try
            {
                int type = 0;
                if (!IsAll)
                {
                    type = 1;
                }

                return RenderList(utilityData.DepartmentByUnit(CountryId).Tables[0], type);
            }
            catch (Exception ex)
            {
                //ApplicationLogger.LogError(ex, "UtilityAccess", "StatesByCountry");
                return null;
            }
        }
        public List<SelectListItem> LocationByDepartment(int DepartmentId, bool IsAll)
        {
            try
            {
                int type = 0;
                if (!IsAll)
                {
                    type = 1;
                }
                return RenderList(utilityData.LocationByDepartment(DepartmentId).Tables[0], type);
            }
            catch (Exception ex)
            {
                //ApplicationLogger.LogError(ex, "UtilityAccess", "StatesByCountry");
                return null;
            }
        }
        public MedicineIssuancetootherunitfirstaddModel MedicineDetails(int MedicineId,int UserUnitId)
        {
            return utilityData.MedicineDetails(MedicineId, UserUnitId);
        }
        public UserMasterModel FindEmployee_Data(UserMasterModel model)
        {
            try
            {
                UserMasterModel response1 = new UserMasterModel();
                DataSet ds = utilityData.FindEmployee_Data(model.Unit, model.EmployeeCode);

                List<UserMasterModel> studentList = new List<UserMasterModel>();
                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    DataTable dt = new DataTable();
                    dt = ds.Tables[0];
                    UserMasterModel response = new UserMasterModel();
                    response.EmployeeCode = dt.Rows[i]["Emp_ID"].ToString();
                    response.UserName = dt.Rows[i]["NAME"].ToString();
                    response.Email = dt.Rows[i]["Email"].ToString();
                    response.Dob = dt.Rows[i]["dob"].ToString();
                    //response.Address = dt.Rows[i]["Address"].ToString();
                    response.EmpType = dt.Rows[i]["EmpType"].ToString();
                    response.Mobile = dt.Rows[i]["MbNo"].ToString();
                    response.Department = dt.Rows[i]["Department"].ToString();
                    studentList.Add(response);
                }

                response1._UserMasterModelList = studentList;
                return response1;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterAccess", "FindEmployee_Data");
                return null;
            }
        }
        //--------------26may
        public static string OtpGenerator()
        {
            var chars = "0123456789";
            var stringChars = new char[6];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }
            var finalString = new String(stringChars);
            return finalString;
        }
        public static int SendEmail(String senderName, String emailTo, String subject, String emailBody, bool blnIsHtml = false)
        {
            try
            {

                string smtpFromEmail = ConfigurationManager.AppSettings["smtpFromEmail"].ToString();
                string smtpMailPassword = ConfigurationManager.AppSettings["smtpMailPassword"].ToString();
                string smtpClient = ConfigurationManager.AppSettings["smtpClient"].ToString();

                MailMessage msg = new MailMessage();
                msg.To.Add(emailTo);
                //msg.From = new MailAddress("sukhvirs63@gmail.com", strEmailSubject);
                msg.From = new MailAddress(smtpFromEmail, "OHC Team");

                msg.Subject = subject;
                msg.Body = emailBody;
                msg.IsBodyHtml = blnIsHtml;

                /******** Using Gmail Domain ********/
                //SmtpClient client = new SmtpClient(smtpClient, 587);

                SmtpClient client = new SmtpClient(smtpClient, 2525);
                client.Credentials = new System.Net.NetworkCredential(smtpFromEmail, smtpMailPassword);
                //client.UseDefaultCredentials = false;
                client.EnableSsl = true;


                client.Send(msg);         // Send our email.
                msg = null;


                return 1;
            }
            catch (Exception exc)
            {
                return -1;
            }
        }
        //-------------26may-----
    }
    public class MsgResponse
    {
        public static String Message(Int32 responseType)
        {
            if (responseType == 0)
                return "We hit a snag, please try again after some time.";
            else if (responseType == 1)
                return "Success";
            else if (responseType == 2)
                return "Retrieved successfully";
            else if (responseType == -5)
                return "Authentication failed";
            else if (responseType == -3)
                return "Email already exists!";
            else if (responseType == -4)
                return "Cannot process!";
            else if (responseType == -1)
                return "Technical error";
            else if (responseType == -2)
                return "No record found";
            else if (responseType == -16)
                return "The old password you have entered is incorrect";
            else if (responseType == 11)
                return "Data saved successfully";
            else if (responseType == 12)
                return "Data updated successfully";
            else if (responseType == 13)
                return "Data deleted successfully";
            else if (responseType == 14)
                return "Payment card set as primary successfully";
            else if (responseType == 15)
                return "Payment processed successfully";
            else if (responseType == 16)
                return "Your password has been changed successfully";
            else if (responseType == 17)
                return "Successfully disabled!!";
            else if (responseType == 18)
                return "Your account has been re-activated.";
            else if (responseType == 19)
                return "We have recieved your account delete request. Your account will be deleted with in 7 days. If you want you can re-activate your account with in 7 days";
            else if (responseType == 20)
                return "Data archived successfully";
            else if (responseType == 21)
                return "We have received your message and would like to thank you for writing to us. we will reply by phone / email as soon as possible.";
            else if (responseType == 23)
                return "Record already exist!";
            else if (responseType == 24)
                return "Data not available, please change your search criteria !";
            else if (responseType == 25)
                return "Your transaction is under process!";
            else if (responseType == 26)
                return "Your refund is successfull!";
            else if (responseType == 27)
                return "The credit card has expired";
            else if (responseType == -28)
                return "SubActivity can not be same.";
            else if (responseType == 29)
                return "Forwarded Successfully.";
            else if (responseType == 30)
                return "Closed Successfully.";
            else if (responseType == 31)
                return "Approved Successfully.";
            else
                return "We hit a snag, please try again after some time.";
        }
    }
}
