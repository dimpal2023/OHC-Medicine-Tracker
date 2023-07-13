using OHCBAL.Interface;
using OHCDAL.Data;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCBAL.Business
{
    public class FirstAidVolunteerAccess : IFirstAidVolunteer
    {
        FirstAidVolunteerData PPCdata = new FirstAidVolunteerData();
        public FAVModel GetFirstAidVolunteerData(FAVModel model)
            {
            FAVModel response = new FAVModel();
            List<FAVModel> responseList = new List<FAVModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new FAVModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.VolunteerName = Convert.ToString(row["VolunteerName"]);
                            response.DepartmentName= Convert.ToString(row["DepartmentId"]);
                            response.EMPCode= Convert.ToString(row["EMPCode"]);
                            response.MobileNo= Convert.ToString(row["MobileNo"]);
                            response.Address= Convert.ToString(row["Address"]);
                            response.Unit= Convert.ToString(row["Unit"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                    }
                }
                response._FAVModelList = responseList;
              
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidVolunteerAccess", "GetFirstAidVolunteerData");
                return null;
            }
        }
        public FAVModel GetCommonData(FAVModel model)
        {
            FAVModel response = new FAVModel();
            List<FAVModel> responseList = new List<FAVModel>();
            DataSet ds = PPCdata.GetCommonData(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new FAVModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.VolunteerName = Convert.ToString(row["VolunteerName"]);
                            response.DepartmentName = Convert.ToString(row["DepartmentId"]);
                            response.EMPCode = Convert.ToString(row["EMPCode"]);
                            response.Address = Convert.ToString(row["Address"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                    }
                }
                response._StatusList = UtilityAccess.StatusListCategory();
                response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1], 1);
                response._FAVModelList = responseList;

                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidVolunteerAccess", "GetCommonData");
                return null;
            }

        }
        public FAVModel AddOrEdit(FAVModel model)
        {
            Int32 returnResult = 0;
            FAVModel response = new FAVModel();
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
                ApplicationLogger.LogError(ex, "FirstAidVolunteerAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public FAVModel GetFirstAidVolunteerDataById(FAVModel model)
        {
            Int32 returnResult = 0;
            int unit = 0;
            FAVModel response = new FAVModel();
            List<FAVModel> responseList = new List<FAVModel>();
            try
            {
                DataSet ds = PPCdata.GetFirstAidVolunteerDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new FAVModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.VolunteerName = Convert.ToString(row["VolunteerName"]);
                            response.DepartmentName = Convert.ToString(row["DepartmentId"]);
                            response.EMPCode = Convert.ToString(row["EMPCode"]);
                            response.Address = Convert.ToString(row["Address"]);
                            response.Status = Convert.ToString(row["Status"]);
                            response.MobileNo = Convert.ToString(row["MobileNo"]);
                            response.Unit = Convert.ToString(row["Unit"]);
                            unit = Convert.ToInt32(row["Unit"]);
                            responseList.Add(response);
                        }
                    }
                }
                DataSet dsdept = PPCdata.GetProjectCommondataWithPara(unit);
                response._StatusList = UtilityAccess.StatusListCategory();
                //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1], 1);
                response._UnitList = UtilityAccess.UnitList(ds.Tables[2], 1);
                if (dsdept != null && dsdept.Tables[1].Rows.Count >= 0)
                {
                    response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidVolunteerAccess", "GetFirstAidVolunteerDataById");
                returnResult = -1;
                return null;
            }
        }
        public FAVModel GetProjectCommondata()
        {
            try { 
            FAVModel response = new FAVModel();
            DataSet ds = PPCdata.GetProjectCommondata();
            DataSet dsdept = PPCdata.GetProjectCommondataWithPara(0);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1],1);
                    response._UnitList = UtilityAccess.UnitList(ds.Tables[0],1);
                }
                if (dsdept.Tables[1].Rows.Count >= 0)
                {
                    response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);
                }
            }
            response._StatusList = UtilityAccess.StatusListCategory();
            return response;
            }
            catch (Exception ex) {
                ApplicationLogger.LogError(ex, "FirstAidVolunteerAccess", "GetProjectCommondata");
                return null;
            }
        }
    }
}

