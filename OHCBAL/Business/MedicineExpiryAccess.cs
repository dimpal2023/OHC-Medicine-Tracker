using OHCBAL.Interface;
using OHCDAL.Data;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OHCBAL.Business
{
    public class MedicineExpiryAccess : IMedicineExpiry
    {
        MedicineExpiryData PPCdata = new MedicineExpiryData();
        public MedicineExpiryModel GetAllMedicine()
        {
            MedicineExpiryModel response = new MedicineExpiryModel();
            List<MedicineExpiryModel> responseList = new List<MedicineExpiryModel>();
            DataSet ds = PPCdata.GetAllMedicine();
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                         response._MedicineNameList = UtilityAccess.MedDropDownList(ds.Tables[0], 1);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineExpiryAccess", "GetAllMedicine");
                return null;
            }
        }
        public MedicineExpiryModel GetMedicineExpiryDate(MedicineExpiryModel model)
        {
            MedicineExpiryModel response=new MedicineExpiryModel();
            List<MedicineExpiryModel> responseList = new List<MedicineExpiryModel>();
            DataSet ds = PPCdata.GetMedicineByMedId(model);
            try
            {
               
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[1].Rows)
                        {
                            response = new MedicineExpiryModel();
                            response.MedicineName = Convert.ToString(row["MedicineName"]);
                            response.Quantity = Convert.ToString(row["Quantity"]);
                            response.Status = Convert.ToString(row["Status"]);
                            response.UnitID = Convert.ToInt16(row["UnitID"]);
                            response.MedicineExpiryDate = Convert.ToString(row["ExpiryDate"]);
                            
                            responseList.Add(response);
                        }
                        response.medicineExpiryModels=responseList;
                    }
                }
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response._MedicineNameList = UtilityAccess.MedDropDownList(ds.Tables[0], 1);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineExpiryAccess", "GetAllMedicine");
                return null;
            }
            return response;    
        }

    }
}
