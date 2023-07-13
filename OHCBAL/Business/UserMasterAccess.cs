using OHCBAL.Interface;
using OHCDAL.Data;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Business
{
    public class UserMasterAccess : IUserMaster
    {
        UserMasterData PPCdata = new UserMasterData();
        public UserMasterModel GetUserMasterData(UserMasterModel model)
        {
            UserMasterModel response = new UserMasterModel();
            List<UserMasterModel> responseList = new List<UserMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new UserMasterModel();
                            response.UserId = Convert.ToInt32(row["UserId"]);
                            response.UserName = Convert.ToString(row["UserName"]);
                            response.Password = Convert.ToString(row["Password"]);
                            response.Email = Convert.ToString(row["Email"]);
                            response.EmployeeCode = Convert.ToString(row["EmployeeCode"]);
                            response.DepartmentId = Convert.ToInt32(row["DepartmentId"]);
                            response.Department = Convert.ToString(row["Department"]);
                            response.Unit = Convert.ToInt32(row["Unit"]);
                            response.EmpType = Convert.ToString(row["UserType"]);
                            response.IsActive = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }

                    }
                }
                response._EmpTypeList = UtilityAccess.DropDownList(ds.Tables[1], 1);
                response._UserMasterModelList = responseList;

                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterAccess", "GetUserMasterData");
                return null;
            }

        }
        public UserMasterModel AddOrEdit(UserMasterModel model)
        {
            Int32 returnResult = 0;
            UserMasterModel response = new UserMasterModel();
            response.ReturnCode = 0;
            response.ReturnMessage = MsgResponse.Message(0);
            try
            {
                DataSet ds = PPCdata.AddorEdit(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public UserMasterModel GetUserMasterDataById(UserMasterModel model)
        {
            Int32 returnResult = 0;

            UserMasterModel response = new UserMasterModel();
            int unit = 0;
            List<UserMasterModel> responseList = new List<UserMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetUserMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new UserMasterModel();
                            response.UserId = Convert.ToInt32(row["UserId"]);
                            response.UserName = Convert.ToString(row["UserName"]);
                            response.Password = Convert.ToString(row["Password"]);
                            response.Unit = Convert.ToInt32(row["Unit"]);
                            unit = Convert.ToInt32(row["Unit"]);
                            response.Email = Convert.ToString(row["Email"]);
                            response.EmployeeCode = Convert.ToString(row["EmployeeCode"]);
                            response.DepartmentId = Convert.ToInt32(row["DepartmentId"]);
                            response.EmpType = Convert.ToString(row["UserType"]);
                            response.IsActive = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                    }

                    DataSet dsdept = PPCdata.GetProjectCommondataWithPara(unit);
                    DataSet ds1 = PPCdata.GetProjectCommondata();
                    if (ds1 != null && ds1.Tables.Count > 0)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            response._UnitList = UtilityAccess.UnitList(ds1.Tables[0], 1);
                            response._EmpTypeList = UtilityAccess.DropDownList(ds1.Tables[6], 1);
                        }
                        //if (ds1.Tables[1].Rows.Count > 0)
                        //{
                        //    response._DepartmentList = UtilityAccess.DepartmentList(ds1.Tables[1],1);
                        //}
                    }
                    if (dsdept != null && dsdept.Tables[1].Rows.Count >= 0)
                    {
                        response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);
                    }

                }
                response._StatusList = UtilityAccess.StatusListCategory();
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterAccess", "GetUserMasterDataById");
                returnResult = -1;
                return null;
            }
        }
        public UserMasterModel GetProjectCommondata()
        {
            try
            {
                UserMasterModel response = new UserMasterModel();
                DataSet ds = PPCdata.GetProjectCommondata();
                DataSet dsdept = PPCdata.GetProjectCommondataWithPara(0);
                if (ds != null && ds.Tables.Count > 0)
                {
                    //if (ds.Tables[1].Rows.Count > 0)
                    //{
                    //    response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1],1);
                    //}
                    if (dsdept.Tables[1].Rows.Count >= 0)
                    {
                        // response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1],1);
                        response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);

                    }
                    if (ds.Tables[6].Rows.Count >= 0)
                    {
                        response._EmpTypeList = UtilityAccess.DropDownList(ds.Tables[6], 1);
                    }
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response._UnitList = UtilityAccess.UnitList(ds.Tables[0], 1);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterAccess", "GetProjectCommondata");
                return null;
            }
        }
    }
}

