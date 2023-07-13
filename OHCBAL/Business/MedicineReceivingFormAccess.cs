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
    public class MedicineReceivingFormAccess : IMedicineRecivingForm
    {
        MedicineReceivingFormData PPCdata = new MedicineReceivingFormData();
        public MedicineReceivingFormModel GetMedicineReceivingFormData(MedicineReceivingFormModel model)
            {
            MedicineReceivingFormModel response = new MedicineReceivingFormModel();
            List<MedicineReceivingFormModel> responseList = new List<MedicineReceivingFormModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new MedicineReceivingFormModel();
                            response.id = Convert.ToInt32(row["Id"]);
                            response.Medicinename = Convert.ToString(row["MedicineName"]);
                            response.HSNNumber= Convert.ToString(row["HSNNumber"]);
                            response.Pack = Convert.ToString(row["Pack"]);
                            response.Quantity = Convert.ToInt32(row["Quantity"]);
                            response.BatchNumber = Convert.ToString(row["BatchNumber"]);
                            response.Rate = Convert.ToDecimal(row["Rate"]);
                            response.ExpiryDate = Convert.ToString(row["ExpiryDate"]);
                            response.VenderName = Convert.ToString(row["VendorName"]);
                            responseList.Add(response);
                        }
                    }
                }
                response._MedicineReceivingFormModelList = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineReceivingFormAccess", "GetMedicineReceivingFormData");
                return null;
            }

        }
        public MedicineReceivingFormModel AddOrEdit(MedicineReceivingFormModel model)
        {
            Int32 returnResult = 0;
            MedicineReceivingFormModel response = new MedicineReceivingFormModel();
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
                ApplicationLogger.LogError(ex, "MedicineReceivingFormAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public MedicineReceivingFormModel GetMedicineReceivingFormById(MedicineReceivingFormModel model)
        {
            Int32 returnResult = 0;
            MedicineReceivingFormModel response = new MedicineReceivingFormModel();
            List<MedicineReceivingFormModel> responseList = new List<MedicineReceivingFormModel>();
            try
            {
                DataSet ds = PPCdata.GetMedicineReceivingFormById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new MedicineReceivingFormModel();
                            response.id = Convert.ToInt32(row["Id"]);
                            response.Medicinename = Convert.ToString(row["MedicineId"]);
                            response.HSNNumber = Convert.ToString(row["HSNNumber"]);
                            response.Pack = Convert.ToString(row["Pack"]);
                            response.Quantity = Convert.ToInt32(row["Quantity"]);
                            response.BatchNumber = Convert.ToString(row["BatchNumber"]);
                            response.Rate = Convert.ToDecimal(row["Rate"]);
                            DateTime tempdate= Convert.ToDateTime(row["ExpiryDate"]);
                            string expirydate = tempdate.ToString("yyyy-MM-dd");
                            response.ExpiryDate = expirydate;
                            response.VenderName = Convert.ToString(row["VenderId"]);
                            responseList.Add(response);
                        }
                    }
                }
                response._MedicineNameList = UtilityAccess.DropDownList(ds.Tables[1],1);
                response._VenderNameList = UtilityAccess.DropDownList(ds.Tables[2],1);
                response._PackList = UtilityAccess.DrpPackList(ds.Tables[3], 1);
                //response._PackList = UtilityAccess.DrpPackList(1);

                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineReceivingFormAccess", "GetMedicineReceivingFormById");
                returnResult = -1;
                return null;
            }
        }
        public MedicineReceivingFormModel GetProjectCommondata()
        {
            try { 
            MedicineReceivingFormModel response = new MedicineReceivingFormModel();
            DataSet ds = PPCdata.GetProjectCommondata();
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    response._MedicineNameList = UtilityAccess.DropDownList(ds.Tables[2],1);
                    response._VenderNameList = UtilityAccess.DropDownList(ds.Tables[3],1);
                        response._PackList = UtilityAccess.DrpPackList(ds.Tables[7], 1);
                        //response._PackList = UtilityAccess.DrpPackList(1);
                    }
            }
           
                return response;
            }
            catch (Exception ex) {
                ApplicationLogger.LogError(ex, "MedicineReceivingFormAccess", "GetProjectCommondata");
                return null;
            }
        }
    }
}

