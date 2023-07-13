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
    public class MedicineMasterAccess : IMedicineMaster
    {
        MedicineMasterData PPCdata = new MedicineMasterData();
        public MedicineMasterModel GetMedicineMasterData(MedicineMasterModel model)
            {
            MedicineMasterModel response = new MedicineMasterModel();
            List<MedicineMasterModel> responseList = new List<MedicineMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new MedicineMasterModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.MedicineName = Convert.ToString(row["Name"]);
                            response.Type = Convert.ToString(row["Type"]);
                            response.Status = Convert.ToString(row["Status"]);
                            response.Remark = Convert.ToString(row["Remark"]);
                            responseList.Add(response);
                        }

                    }
                }
                response._StatusList = UtilityAccess.StatusListCategory();
                response._MedicineMasterModel = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineMasterAccess", "GetMedicineMasterData");
                return null;
            }

        }
        public MedicineMasterModel AddOrEdit(MedicineMasterModel model)
        {
            Int32 returnResult = 0;
            MedicineMasterModel response = new MedicineMasterModel();
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
                ApplicationLogger.LogError(ex, "MedicineMasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        } 
        public MedicineMasterModel GetMedicineMasterDataById(MedicineMasterModel model)
        {
            Int32 returnResult = 0;

            MedicineMasterModel response = new MedicineMasterModel();
            List<MedicineMasterModel> responseList = new List<MedicineMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetDepartmentMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new MedicineMasterModel(); 
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.Type = Convert.ToString(row["Type"]);
                            response.MedicineName = Convert.ToString(row["Name"]); 
                            response.Status = Convert.ToString(row["Status"]);
                            response.Remark = Convert.ToString(row["Remark"]);
                            responseList.Add(response);
                        }
                    }
                    response._StatusList = UtilityAccess.StatusListCategory();
                    //response._MedicineType = UtilityAccess.DrpPackList(ds.Tables[1],1); 
                    //DataSet ds1 = PPCdata.GetProjectCommondata();
                    //if (ds1 != null && ds1.Tables.Count > 0)
                    //{
                    //    if (ds1.Tables[0].Rows.Count > 0)
                    //    {
                    //        response._UnitList = UtilityAccess.UnitList(ds1.Tables[0], 2);
                    //    }
                    //    //response._StatusList = UtilityAccess.StatusListCategory();
                    //}

                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineMasterAccess", "GetMedicineMasterDataById");
                returnResult = -1;
                return null;
            }
        }
        public MedicineMasterModel GetProjectCommondata()
        {
            try
            {
                MedicineMasterModel response = new MedicineMasterModel();
                DataSet ds = PPCdata.GetProjectCommondata();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response._MedicineType = UtilityAccess.DrpPackList(ds.Tables[7], 1);
                        
                        
                    }
                }

                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineReceivingFormAccess", "GetProjectCommondata");
                return null;
            }
        }
    }
}

