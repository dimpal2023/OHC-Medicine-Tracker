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
    public class MasterAccess : IMaster
    {
        MasterData PPCdata = new MasterData();
        public DepartmentMasterModel GetDepartmentMasterData(DepartmentMasterModel model)
        {
            DepartmentMasterModel response = new DepartmentMasterModel();
            List<DepartmentMasterModel> responseList = new List<DepartmentMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new DepartmentMasterModel();
                            response.Unit = Convert.ToString(row["Unit"]);
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.DepartmentName = Convert.ToString(row["Name"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }

                    }
                }
                //response._StatusList = UtilityAccess.StatusListCategory();
                response._DepartmentMasterModelList = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MasterAccess", "GetDepartmentMasterData");
                return null;
            }

        }
        public DepartmentMasterModel AddOrEdit(DepartmentMasterModel model)
        {
            Int32 returnResult = 0;
            DepartmentMasterModel response = new DepartmentMasterModel();
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
                ApplicationLogger.LogError(ex, "MasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }
        public DepartmentMasterModel GetDepartmentMasterDataById(DepartmentMasterModel model)
        {
            Int32 returnResult = 0;

            DepartmentMasterModel response = new DepartmentMasterModel();
            List<DepartmentMasterModel> responseList = new List<DepartmentMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetDepartmentMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new DepartmentMasterModel();
                            response.Unit = Convert.ToString(row["Unit"]);
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.DepartmentName = Convert.ToString(row["Name"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                    }
                    response._StatusList = UtilityAccess.StatusListCategory();
                    DataSet ds1 = PPCdata.GetProjectCommondata();
                    if (ds1 != null && ds1.Tables.Count > 0)
                    {
                        if (ds1.Tables[0].Rows.Count > 0)
                        {
                            response._UnitList = UtilityAccess.UnitList(ds1.Tables[0], 1);
                        }
                        //response._StatusList = UtilityAccess.StatusListCategory();
                    }

                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MasterAccess", "GetDepartmentMasterDataById");
                returnResult = -1;
                return null;
            }
        }
        public DepartmentMasterModel GetProjectCommondata()
        {
            try
            {
                DepartmentMasterModel response = new DepartmentMasterModel();
                DataSet ds = PPCdata.GetProjectCommondata();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response._UnitList = UtilityAccess.UnitList(ds.Tables[0], 1);
                    }
                    //response._StatusList = UtilityAccess.StatusListCategory();
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MasterAccess", "GetProjectCommondata");
                return null;
            }
        }
    }
}

