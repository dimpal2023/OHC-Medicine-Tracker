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
    public class MedicineIssuanceAccess : IMedicineIssuanc
    {
        MedicineIssuanceData PPCdata = new MedicineIssuanceData();
        public MedicineIssuancetootherunitfirstaddModel GetMedicineIssuancData(MedicineIssuancetootherunitfirstaddModel model)
        {
            MedicineIssuancetootherunitfirstaddModel response = new MedicineIssuancetootherunitfirstaddModel();
            List<MedicineIssuancetootherunitfirstaddModel> responseList = new List<MedicineIssuancetootherunitfirstaddModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new MedicineIssuancetootherunitfirstaddModel();
                            response.MedicineIssuanceID = Convert.ToInt32(row["Id"]);
                            response.Unit = Convert.ToString(row["BUILDING_NAME"]);
                            response.DepartmentName = Convert.ToString(row["DepartmentName"]);
                            response.IssueDate = Convert.ToString(row["IssueDate"]);
                            responseList.Add(response);
                        }
                    }
                }
                response._MedicineIssuanceList = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineIssuanceAccess", "GetMedicineIssuancData");
                return null;
            }

        }
        public MedicineIssuancetootherunitfirstaddModel AddOrEdit(MedicineIssuancetootherunitfirstaddModel model)
        {
            DataTable AddNewTableData = new DataTable();
            Int32 returnResult = 0;
            MedicineIssuancetootherunitfirstaddModel response = new MedicineIssuancetootherunitfirstaddModel();
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
                ApplicationLogger.LogError(ex, "MedicineIssuanceAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }
        public static DataTable AddNewTableData1(MedicineIssuancetootherunitfirstaddModel models)
        {

            DataTable dtSetupSeriesRow = new DataTable();

            dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow.Columns.Add("MedicineID", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Quantity", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("BatchNo", typeof(System.String));
            try
            {
                if (models._DetailsofMedicineList != null && models._DetailsofMedicineList.Count > 0)
                {
                    foreach (var item in models._DetailsofMedicineList)
                    {
                        DataRow dtRow = dtSetupSeriesRow.NewRow();
                        dtRow["MedicineID"] = item.Medicinename;
                        dtRow["Quantity"] = item.Qty;
                        dtRow["BatchNo"] = item.BatchNo ?? null;
                        dtSetupSeriesRow.Rows.Add(dtRow);
                    }
                }
                return dtSetupSeriesRow;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineIssuanceAccess", "AddNewTableData1");
                return null;
            }
        }
        public MedicineIssuancetootherunitfirstaddModel GetMedicineIssuancById(MedicineIssuancetootherunitfirstaddModel model)
        {
            Int32 returnResult = 0;
            int unit = 0;
            MedicineIssuancetootherunitfirstaddModel response = new MedicineIssuancetootherunitfirstaddModel();
            DetailsofMedicine detailsresponse = new DetailsofMedicine();
            List<MedicineIssuancetootherunitfirstaddModel> responseList = new List<MedicineIssuancetootherunitfirstaddModel>();
            List<DetailsofMedicine> detailsresponseList = new List<DetailsofMedicine>();
            try
            {
                DataSet ds = PPCdata.GetMedicineIssuancById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.MedicineIssuanceID= Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                        response.Unit = ds.Tables[0].Rows[0]["UnitId"].ToString();
                        unit = Convert.ToInt32(ds.Tables[0].Rows[0]["UnitId"]);
                        response.DepartmentName = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                        if(!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["IssueDate"].ToString()))
                        {
                            DateTime tempdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                            string expirydate = tempdate.ToString("yyyy-MM-dd");
                            response.IssueDate = expirydate;
                        }
                        else
                        {
                            response.IssueDate =(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                        }
                       
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[1].Rows)
                        {
                            detailsresponse = new DetailsofMedicine();
                            detailsresponse.Medicinename = Convert.ToString(row["MedicineName"]);
                            detailsresponse.Qty = Convert.ToInt32(row["Quantity"]);
                            detailsresponse.BatchNo = Convert.ToString(row["BatchNumber"]);
                            detailsresponse.AvailableQty = Convert.ToInt32(row["AvailableQuantity"]);
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
                response._DetailsofMedicineList = detailsresponseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineIssuanceAccess", "GetMedicineIssuancById");
                returnResult = -1;
                return null;
            }
        }
        public MedicineIssuancetootherunitfirstaddModel GetMedicineRequsetDataById(MedicineIssuancetootherunitfirstaddModel model)
        {
            Int32 returnResult = 0;
            int unit = 0;
            MedicineIssuancetootherunitfirstaddModel response = new MedicineIssuancetootherunitfirstaddModel();
            DetailsofMedicine detailsresponse = new DetailsofMedicine();
            List<MedicineIssuancetootherunitfirstaddModel> responseList = new List<MedicineIssuancetootherunitfirstaddModel>();
            List<DetailsofMedicine> detailsresponseList = new List<DetailsofMedicine>();
            try
            {
                DataSet ds = PPCdata.MedicineRequsetData(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.MedicineIssuanceID = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                        response.Unit = ds.Tables[0].Rows[0]["UnitId"].ToString();
                        unit = Convert.ToInt32(ds.Tables[0].Rows[0]["UnitId"]);
                        response.DepartmentName = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                        //if (!string.IsNullOrEmpty(ds.Tables[0].Rows[0]["IssueDate"].ToString()))
                        //{
                        //    DateTime tempdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["IssueDate"].ToString());
                        //    string expirydate = tempdate.ToString("yyyy-MM-dd");
                        //    response.IssueDate = expirydate;
                        //}
                        //else
                        //{
                        //    response.IssueDate = (ds.Tables[0].Rows[0]["IssueDate"].ToString());
                        //}

                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[1].Rows)
                        {
                            detailsresponse = new DetailsofMedicine();
                            detailsresponse.Medicinename = Convert.ToString(row["MedicineName"]);
                            detailsresponse.Qty = Convert.ToInt32(row["Quantity"]);
                            //detailsresponse.BatchNo = Convert.ToString(row["BatchNumber"]);
                            detailsresponse.AvailableQty = Convert.ToInt32(row["AvailableQuantity"]);
                            detailsresponseList.Add(detailsresponse);
                        }
                    }
                }
                DataSet dsdept = PPCdata.GetProjectCommondataWithPara(unit);
                response._MedicineList = UtilityAccess.DropDownList(ds.Tables[2], 1);
                //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[3],1);
                if (dsdept != null && dsdept.Tables[1].Rows.Count >= 0)
                {
                    response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);
                }
                response._UnitList = UtilityAccess.DropDownList(ds.Tables[4], 1);
                response._DetailsofMedicineList = detailsresponseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicineIssuanceAccess", "GetMedicineIssuancById");
                returnResult = -1;
                return null;
            }
        }
        public MedicineIssuancetootherunitfirstaddModel GetProjectCommondata()
        {
            try { 
            MedicineIssuancetootherunitfirstaddModel response = new MedicineIssuancetootherunitfirstaddModel();
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
            catch (Exception ex) {
                ApplicationLogger.LogError(ex, "MedicineIssuanceAccess", "GetProjectCommondata");
                return null;
            }
        }
    }
}

