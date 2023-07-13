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
    public class FirstAidInspectionAccess : IFirstAidInspection
    {
        FirstAidInspectionData PPCdata = new FirstAidInspectionData();
        public FirstAidInspectionModel GetFirstAidInspectionData(FirstAidInspectionModel model)
        {
            FirstAidInspectionModel response = new FirstAidInspectionModel();
            List<FirstAidInspectionModel> responseList = new List<FirstAidInspectionModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new FirstAidInspectionModel();
                            response.FirstAidInspectionID = Convert.ToInt32(row["Id"]);
                            response.Unit = Convert.ToString(row["BUILDING_NAME"]);
                            response.DepartmentName = Convert.ToString(row["DepartmentName"]);
                            response.Location = Convert.ToString(row["LocationName"]);
                            response.Shift = Convert.ToString(row["Shift"]);
                            response.Frequency = Convert.ToString(row["Frequency"]);
                            response.DateOfInspection = Convert.ToString(row["DateOfInspection"]);
                            response.NextDueOn = Convert.ToString(row["NextDueOn"]);
                            responseList.Add(response);
                        }
                    }
                }
                response._FirstAidInspectionModelList = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidInspectionAccess", "GetFirstAidInspectionData");
                return null;
            }
        }
        public FirstAidInspectionModel AddOrEdit(FirstAidInspectionModel model)
        {
            DataTable AddNewTableData = new DataTable();
            Int32 returnResult = 0;
            FirstAidInspectionModel response = new FirstAidInspectionModel();
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
                ApplicationLogger.LogError(ex, "FirstAidInspectionAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }
        public static DataTable AddNewTableData1(FirstAidInspectionModel models)
        {
            DataTable dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow.Columns.Add("MedicineID", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("FreezeQty", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("AvailableQty", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("DateofExp", typeof(System.String));
            dtSetupSeriesRow.Columns.Add("Remark", typeof(System.String));
            try
            {
                if (models._DetailsFirstAidInspectionList != null && models._DetailsFirstAidInspectionList.Count > 0)
                {
                    foreach (var item in models._DetailsFirstAidInspectionList)
                    {
                        DataRow dtRow = dtSetupSeriesRow.NewRow();
                        dtRow["MedicineID"] = item.Medicinename;
                        dtRow["FreezeQty"] = item.FreezeQty;
                        dtRow["AvailableQty"] = item.AvailableQty;
                        dtRow["DateofExp"] = item.DateofExp;
                        dtRow["Remark"] = item.Remark ?? null;
                        dtSetupSeriesRow.Rows.Add(dtRow);
                    }
                }
                return dtSetupSeriesRow;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "DevelopmentPlanAccess", "AddNewTableData1");
                return null;
            }
        }
        public FirstAidInspectionModel GetFirstAidInspectionById(FirstAidInspectionModel model)
        {
            Int32 returnResult = 0;
            int unit = 0;
            FirstAidInspectionModel response = new FirstAidInspectionModel();
            DetailsFirstAidInspection detailsresponse = new DetailsFirstAidInspection();
            List<FirstAidInspectionModel> responseList = new List<FirstAidInspectionModel>();
            List<DetailsFirstAidInspection> detailsresponseList = new List<DetailsFirstAidInspection>();
            try
            {
                DataSet ds = PPCdata.GetMedicineReceivingFormById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response.FirstAidInspectionID = Convert.ToInt32(ds.Tables[0].Rows[0]["Id"]);
                        response.Unit = ds.Tables[0].Rows[0]["UnitId"].ToString();
                        response.DepartmentName = ds.Tables[0].Rows[0]["DepartmentName"].ToString();
                        response.Location = ds.Tables[0].Rows[0]["LocationID"].ToString();
                        response.Shift = ds.Tables[0].Rows[0]["Shift"].ToString();
                        DateTime tempdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["NextDueOn"].ToString());
                        string nextdueon = tempdate.ToString("yyyy-MM-dd");
                        response.NextDueOn = nextdueon;
                        DateTime tempdate1 = Convert.ToDateTime(ds.Tables[0].Rows[0]["DateOfInspection"].ToString());
                        string dateofinspection = tempdate1.ToString("yyyy-MM-dd");
                        response.DateOfInspection = dateofinspection;
                        response.Unit = ds.Tables[0].Rows[0]["UnitID"].ToString();
                        unit = Convert.ToInt32(ds.Tables[0].Rows[0]["UnitID"]);
                        response.Frequency = ds.Tables[0].Rows[0]["Frequency"].ToString();
                        response.InspectionType = ds.Tables[0].Rows[0]["InspectionType"].ToString();
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[1].Rows)
                        {
                            detailsresponse = new DetailsFirstAidInspection();
                            detailsresponse.Medicinename = Convert.ToString(row["MedicineName"]);
                            detailsresponse.FreezeQty = Convert.ToInt32(row["FreezeQuantity"]);
                            detailsresponse.AvailableQty = Convert.ToInt32(row["AvailableQuantity"]);
                            DateTime tempdate2 = Convert.ToDateTime(row["DateofExpiration"]);
                            string dateofexp = tempdate2.ToString("yyyy-MM-dd");
                            detailsresponse.DateofExp = dateofexp;
                            detailsresponse.Remark = Convert.ToString(row["Remarks"]);
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
                response._InspectionTypeList = UtilityAccess.DrpInspectionTypeList();
                response._LocationList = UtilityAccess.DropDownList(ds.Tables[5],1);
                response._DetailsFirstAidInspectionList = detailsresponseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidInspectionAccess", "GetFirstAidInspectionById");
                returnResult = -1;
                return null;
            }
        }
        public FirstAidInspectionModel GetProjectCommondata()
        {
            try
            {
                FirstAidInspectionModel response = new FirstAidInspectionModel();
                DataSet ds = PPCdata.GetProjectCommondata();
                DataSet dsdept = PPCdata.GetProjectCommondataWithPara(0);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        response._MedicineList = UtilityAccess.DropDownList(ds.Tables[2], 1);
                        response._UnitList = UtilityAccess.UnitList(ds.Tables[0], 1);
                        //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1],1);
                        response._LocationList = UtilityAccess.DropDownList(ds.Tables[4], 1);
                        response._InspectionTypeList = UtilityAccess.DrpInspectionTypeList();
                    }
                    if (dsdept.Tables[1].Rows.Count >= 0)
                    {
                        response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);
                    }
                }
                return response;
            }
            catch(Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidInspectionAccess", "GetProjectCommondata");
                return null;
            }
            
        }
        public FirstAidInspectionModel GetDepartmentByUnit(int Unit)
        {
            try
            {
                FirstAidInspectionModel response = new FirstAidInspectionModel();
                DataSet ds = PPCdata.GetDeapartmentDataByUnit(Unit);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        //response._MedicineList = UtilityAccess.DropDownList(ds.Tables[2], 2);
                        //response._UnitList = UtilityAccess.UnitList(ds.Tables[0], 2);
                        response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[0], 1);
                    }
                }
                return response;
            }
            catch(Exception ex)
            {
                ApplicationLogger.LogError(ex, "FirstAidInspectionAccess", "GetDepartmentByUnit");
                return null;
            }
            
        }
    }
}

