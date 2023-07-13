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
    public class VendorMasterAccess : IVendorMaster
    {
        VendorMasterData PPCdata = new VendorMasterData();
        public VendorMasterModel GetVendorMasterData(VendorMasterModel model)
        {
            VendorMasterModel response = new VendorMasterModel();
            List<VendorMasterModel> responseList = new List<VendorMasterModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new VendorMasterModel();
                            response.VendorId = Convert.ToInt32(row["VendorId"]);
                            response.VendorName = row["VendorName"].ToString();
                            response.Address = row["Address"].ToString();
                            response.LicenseNo = row["LicenseNo"].ToString();
                            response.IsActive = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                    }
                }
                //response._StatusList = UtilityAccess.StatusListCategory();
                response._VendorMasterList = responseList;

                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "VendorMasterAccess", "GetVendorMasterData");
                return null;
            }

        }
        public VendorMasterModel AddOrEdit(VendorMasterModel model)
        {
            Int32 returnResult = 0;
            VendorMasterModel response = new VendorMasterModel();
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
                ApplicationLogger.LogError(ex, "VendorMasterAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public VendorMasterModel GetVendorMasterDataById(VendorMasterModel model)
        {
            Int32 returnResult = 0;

            VendorMasterModel response = new VendorMasterModel();
            List<VendorMasterModel> responseList = new List<VendorMasterModel>();
            try
            {
                DataSet ds = PPCdata.GetVendorMasterDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new VendorMasterModel();
                            response.VendorId = Convert.ToInt32(row["VendorId"]);
                            response.VendorName = row["VendorName"].ToString();
                            response.Address = row["Address"].ToString();
                            response.LicenseNo = row["LicenseNo"].ToString();
                            response.IsActive = Convert.ToString(row["IsActive"]);
                            responseList.Add(response);
                            responseList.Add(response);
                        }
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "VendorMasterAccess", "GetVendorMasterDataById");
                returnResult = -1;
                return null;
            }
        }
    }
}


