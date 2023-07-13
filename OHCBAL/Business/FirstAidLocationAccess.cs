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
    public class FirstAidLocationAccess : IFirstAidLocation
    {
        FirstAidLocationData PPCdata = new FirstAidLocationData();
        public FALModel GetFirstAidLocationData(FALModel model)
        {
            FALModel response = new FALModel();
            List<FALModel> responseList = new List<FALModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new FALModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.LocationName = Convert.ToString(row["LocationName"]);
                            response.DepartmentName = Convert.ToString(row["DepartmentId"]);
                            response.Status = Convert.ToString(row["Status"]);
                            response.Unit = Convert.ToString(row["Unit"]);
                            response.HdnEmployeeCode = Convert.ToString(row["StationManager"]);
                            response.StationNumber = Convert.ToString(row["StationName"]); ;

                            responseList.Add(response);
                        }
                    }
                }
                //response._StatusList = UtilityAccess.StatusListCategory();
                //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1], 1);
                response._FALModelList = responseList;

                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidLocationAccess", "GetFirstAidLocationData");
                return null;
            }

        }
        public FALModel AddOrEdit(FALModel model)
        {
            Int32 returnResult = 0;
            FALModel response = new FALModel();
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
                ApplicationLogger.LogError(ex, "FirstAidLocationAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public FALModel GetFirstAidLocationDataById(FALModel model)
        {
            Int32 returnResult = 0;
            int unit = 0;
            FALModel response = new FALModel();
            List<FALModel> responseList = new List<FALModel>();
            try
            {
                DataSet ds = PPCdata.GetFirstAidLocationDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new FALModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.LocationName = Convert.ToString(row["LocationName"]);
                            response.DepartmentName = Convert.ToString(row["DepartmentId"]);
                            response.Status = Convert.ToString(row["Status"]);
                            response.Unit = Convert.ToString(row["Unit"]);
                            unit = Convert.ToInt32(row["Unit"]);
                            response.HdnEmployeeCode = Convert.ToString(row["StationManager"]);
                            response.StationNumber = Convert.ToString(row["StationName"]);
                            responseList.Add(response);
                        }
                    }
                }
                DataSet dsdept = PPCdata.GetProjectCommondataWithPara(unit);
                response._StatusList = UtilityAccess.StatusListCategory();
                //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1],1);
                response._UnitList = UtilityAccess.UnitList(ds.Tables[2], 1);
                if (dsdept != null && dsdept.Tables[1].Rows.Count >= 0)
                {
                    response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidLocationAccess", "GetFirstAidLocationDataById");
                returnResult = -1;
                return null;
            }
        }
        public FALModel GetProjectCommondata()
        {
            try
            {
                FALModel response = new FALModel();
                DataSet ds = PPCdata.GetProjectCommondata();
                DataSet dsdept = PPCdata.GetProjectCommondataWithPara(0);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1],1);
                        response._UnitList = UtilityAccess.UnitList(ds.Tables[0], 1);
                    }
                    if (dsdept.Tables[1].Rows.Count >= 0)
                    {

                        response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);

                    }
                }
                response._StatusList = UtilityAccess.StatusListCategory();
                return response;
            }
            catch 
            (Exception ex) 
            {
                ApplicationLogger.LogError(ex, "FirstAidLocationAccess", "GetProjectCommondata");
                return null;
            }
        }
    }
}

