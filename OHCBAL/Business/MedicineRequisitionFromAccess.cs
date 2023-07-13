//using FPDAL.Data;

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
    public class MedicineRequisitionFromAccess : IMedicineRequisitionFrom
    {
        MedicineRequisitionFromData PPCdata = new MedicineRequisitionFromData();
        public MedicineRequisitionFromModel GetMedicineRequisitionData(MedicineRequisitionFromModel model)
        {
            MedicineRequisitionFromModel response = new MedicineRequisitionFromModel();
            List<MedicineRequisitionFromModel> responseList = new List<MedicineRequisitionFromModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new MedicineRequisitionFromModel();
                            response.MedicineRequisitionID = Convert.ToInt32(row["Id"]);
                            response.Unit = Convert.ToString(row["BUILDING_NAME"]).Trim();
                            response.DepartmentName = Convert.ToString(row["DepartmentName"]);
                            response.Status = Convert.ToString(row["Status"]);
                            responseList.Add(response);
                        }
                    }
                }
                response.UserUnitID = model.UserUnitID;
                response._MedicineRequisitionFromList = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromAccess", "GetMedicineRequisitionData");
                return null;
            }
        }
        public MedicineRequisitionFromModel AddOrEdit(MedicineRequisitionFromModel model)
        {
            DataTable AddNewTableData = new DataTable();
            Int32 returnResult = 0;
            MedicineRequisitionFromModel response = new MedicineRequisitionFromModel();
            response.ReturnCode = 0;
            response.ReturnMessage = MsgResponse.Message(0);
            try
            {
                AddNewTableData = AddNewTableData1(model);
                returnResult = PPCdata.AddorEdit(model, AddNewTableData, out returnResult);
                //DataSet ds = PPCdata.AddorEdit(model, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }
        public static DataTable AddNewTableData1(MedicineRequisitionFromModel models)
        {
            DataTable dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow.Columns.Add("MedicineID", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Quantity", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Remark", typeof(System.String));
            try
            {
                if (models._DetailsofMedicineRequisitionList != null && models._DetailsofMedicineRequisitionList.Count > 0)
                {
                    foreach (var item in models._DetailsofMedicineRequisitionList)
                    {
                        DataRow dtRow = dtSetupSeriesRow.NewRow();
                        dtRow["MedicineID"] = item.Medicinename;
                        dtRow["Quantity"] = item.Qty;
                        dtRow["Remark"] = item.Remark ?? null;
                        dtSetupSeriesRow.Rows.Add(dtRow);
                    }
                }
                return dtSetupSeriesRow;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromAccess", "AddNewTableData1");
                return null;
            }
        }
        public MedicineRequisitionFromModel GetMedicineRequisitionById(MedicineRequisitionFromModel model)
        {
            Int32 returnResult = 0;
            int unit = 0;
            MedicineRequisitionFromModel response = new MedicineRequisitionFromModel();
            DetailsofMedicineRequisition detailsresponse = new DetailsofMedicineRequisition();
            List<MedicineRequisitionFromModel> responseList = new List<MedicineRequisitionFromModel>();
            List<DetailsofMedicineRequisition> detailsresponseList = new List<DetailsofMedicineRequisition>();
            try
            {
                DataSet ds = PPCdata.GetMedicineReceivingFormById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.MedicineRequisitionID = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                        response.Unit = ds.Tables[0].Rows[0]["UnitId"].ToString();
                        unit = Convert.ToInt32(ds.Tables[0].Rows[0]["UnitId"]);
                        response.DepartmentName = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[1].Rows)
                        {
                            detailsresponse = new DetailsofMedicineRequisition();
                            detailsresponse.Medicinename = Convert.ToString(row["MedicineName"]);
                            detailsresponse.Qty = Convert.ToInt32(row["Quantity"]);
                            detailsresponse.Remark = Convert.ToString(row["Remark"]);
                            detailsresponseList.Add(detailsresponse);
                        }
                    }
                }
                DataSet dsdept = PPCdata.GetProjectCommondataWithPara(unit);
                response._MedicineList = UtilityAccess.DropDownList(ds.Tables[2],1);
                //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[3],1);
                if (dsdept != null && dsdept.Tables[1].Rows.Count >= 0)
                {
                    response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);
                }
                response._UnitList = UtilityAccess.DropDownList(ds.Tables[4],1);
                response._DetailsofMedicineRequisitionList = detailsresponseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromAccess", "GetMedicineRequisitionById");
                returnResult = -1;
                return null;
            }
        }
        public MedicineRequisitionFromModel GetProjectCommondata()
        {
            try {
            MedicineRequisitionFromModel response = new MedicineRequisitionFromModel();
            DataSet ds = PPCdata.GetProjectCommondata();
            DataSet dsdept = PPCdata.GetProjectCommondataWithPara(0);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    response._MedicineList = UtilityAccess.DropDownList(ds.Tables[2],1);
                    response._UnitList = UtilityAccess.UnitList(ds.Tables[0],1);
                    //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1],1);
                }
                if (dsdept.Tables[1].Rows.Count >= 0)
                {
                    response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);
                }
            }
            return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromAccess", "GetProjectCommondata");
                return null;
            }
        }
        public MedicineRequisitionFromModel GetDepartmentByUnit(int Unit)
        {
            try
            {
            MedicineRequisitionFromModel response = new MedicineRequisitionFromModel();
            DataSet ds = PPCdata.GetDeapartmentDataByUnit(Unit);
            if (ds != null && ds.Tables.Count > 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    //response._MedicineList = UtilityAccess.DropDownList(ds.Tables[2], 2);
                    //response._UnitList = UtilityAccess.UnitList(ds.Tables[0], 2);
                    response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[0],1);
                }
            }
            return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineRequisitionFromAccess", "GetDepartmentByUnit");
                return null;
            }
        }
    }
}

