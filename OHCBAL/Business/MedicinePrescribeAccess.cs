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
    public class MedicinePrescribeAccess : IMedicinePrescribe
    {
        MedicinePrescribeData PPCdata = new MedicinePrescribeData();
        public MedicinePrescribeModel GetMedicinePrescribeData(MedicinePrescribeModel model)
        {
            MedicinePrescribeModel response = new MedicinePrescribeModel();
            List<MedicinePrescribeModel>
                responseList = new List<MedicinePrescribeModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new MedicinePrescribeModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.EmployeeId = Convert.ToInt32(row["Id"]);
                            response.EmployeeCode = Convert.ToString(row["EmployeeCode"]);
                            if (!string.IsNullOrEmpty(response.EmployeeCode))
                            {
                                response.EmployeeName = row["EmployeeName"].ToString() + " (" + Convert.ToString(row["EmployeeCode"]) + ")";
                            }
                            else
                            {
                                response.EmployeeName = row["EmployeeName"].ToString();
                            }
                            response.Problem = row["Problem"].ToString();
                            response.Gender = row["Gender"].ToString();
                            response.Unit = row["Unit"].ToString();
                            response.Department = row["Department"].ToString();
                            response.Date = row["Date"].ToString();
                            response.Time = row["Time"].ToString();
                            response.SuggestedBy = row["SuggestedBy"].ToString();
                            response.Treatment = row["Treatment"].ToString();
                            response.CheckUpVital = Convert.ToString(row["VitalCheckUp"]);
                            response.PatientStatusCloseDiscription = Convert.ToString(row["PatientStatusCloseDescription"]);
                            response.PatientFitnessCertificate = Convert.ToString(row["PatinetFitnessCretificate"]);
                            response.IsReffered = Convert.ToBoolean(row["IsReffer"]);
                            responseList.Add(response);
                        }
                    }
                }
                //response._StatusList = UtilityAccess.StatusListCategory();
                response._MedicinePrescribeModelList = responseList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicinePrescribeAccess", "GetMedicinePrescribeData");
                return null;
            }

        }
        public MedicinePrescribeModel AddOrEdit(MedicinePrescribeModel model)
        {
            Int32 returnResult = 0;
            MedicinePrescribeModel response = new MedicinePrescribeModel();
            response.ReturnCode = 0;
            response.ReturnMessage = MsgResponse.Message(0);
            try
            {
                DataTable AddNewTableData = new DataTable();
                AddNewTableData = AddNewTableData1(model);
                returnResult = PPCdata.AddorEdit(model, AddNewTableData, out returnResult);
                response.ReturnCode = returnResult;
                response.ReturnMessage = MsgResponse.Message(returnResult);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicinePrescribeAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }
        public MedicinePrescribeModel GetMedicinePrescribeDataById(MedicinePrescribeModel model)
        {
            Int32 returnResult = 0;
            int unit = 0;
            DetailsofMedicine2 detailsresponse = new DetailsofMedicine2();
            List<DetailsofMedicine2> detailsresponseList = new List<DetailsofMedicine2>();
            MedicinePrescribeModel response = new MedicinePrescribeModel();
            List<MedicinePrescribeModel> responseList = new List<MedicinePrescribeModel>();
            try
            {
                DataSet ds = PPCdata.GetMedicinePrescribeDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new MedicinePrescribeModel();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.EmployeeId = Convert.ToInt32(row["Id"]);
                            response.EmployeeCode = Convert.ToString(row["EmployeeCode"]);
                            response.EmployeeName = row["EmployeeName"].ToString();
                            response.Problem = row["Problem"].ToString();
                            //response.IsActive = Convert.ToString(row["Status"]);
                            response.Gender = row["Gender"].ToString();
                            response.Unit = row["Unit"].ToString();
                            unit = Convert.ToInt32(row["Unit"]);
                            string DepartmentName = row["DepartmentName"].ToString();
                            if(String.IsNullOrEmpty(DepartmentName))
                            {
                                response.Department = row["DepartmentID"].ToString();
                            }
                            else
                            {
                                response.Department = row["Department"].ToString();
                            }
                            response.DepartmentID = row["DepartmentID"].ToString();
                            response.MasterDepartment = row["Department"].ToString();
                            DateTime tempdate = Convert.ToDateTime(row["Date"]);
                            string expirydate = tempdate.ToString("yyyy-MM-dd");
                            response.EmergencyContactNo = Convert.ToString(row["EmergencyContact"]);
                            response.Mobile = Convert.ToString(row["Mobile"]);
                            if (row["DOB"].ToString() == "01-01-1900 00:00:00") 
                            {
                                response.DOB = "";
                            }
                            else
                            {
                                DateTime tempDOB = Convert.ToDateTime(row["DOB"]);
                                string dob = tempDOB.ToString("yyyy-MM-dd");
                                response.DOB = dob;
                            }
                            response.Address = Convert.ToString(row["Address"]);
                            response.CompanyName = Convert.ToString(row["Company"]);
                            response.IsReffered = Convert.ToBoolean(row["IsReffer"]);
                            response.IsOutsideWorker = Convert.ToBoolean(row["IsOutsideEmployee"]);
                            response.VitalCheckUp = Convert.ToBoolean(row["VitalCheckUp"]);
                            response.Date = expirydate;
                            string time = row["Time"].ToString();
                            response.Time = tempdate.ToString("HH:mm");
                            response.SuggestedBy = row["SuggestedBy"].ToString();
                            response.SuggestedDetails = row["SuggestedDetail"].ToString();
                            response.Treatment = row["Treatment"].ToString();
                            response.FirstAidCheckUp = Convert.ToBoolean(row["FirstAidCheckup"]);
                            response.HospitalName = row["HospitalName"].ToString();
                            response.AttendeeName = row["AttendeeName"].ToString();
                            response.AttendeeMobileNumber = row["AttendeeMobileNumber"].ToString();
                            response.RefferbyVehicle = row["RefferbyVehicle"].ToString();
                            response.PatientStatus = row["PatientStatus"].ToString();
                            response.PatientStatusCloseDiscription = Convert.ToString(row["PatientStatusCloseDescription"]);
                            response.PatientFitnessCertificate = Convert.ToString(row["PatinetFitnessCretificate"]);
                            response.ReferbyOtherVehicle = Convert.ToString(row["ReferByVehicleWhenEmpOutside"]);
                            responseList.Add(response);
                        }
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[1].Rows)
                        {
                            detailsresponse = new DetailsofMedicine2();
                            detailsresponse.Medicinename = Convert.ToString(row["Medicine"]);
                            detailsresponse.Qty = Convert.ToInt32(row["Qty"]);
                            detailsresponse.Remark = Convert.ToString(row["Remark"]);
                            detailsresponse.AvailableQty = Convert.ToInt32(row["AvailableQuantity"]);
                            detailsresponseList.Add(detailsresponse);
                        }
                    }
                }
                DataSet dsdept = PPCdata.GetProjectCommondataWithPara(unit);
                DataSet ds1 = PPCdata.GetProjectCommondata();
                if (ds1 != null && ds1.Tables.Count > 0)
                {
                    if (ds1.Tables[0].Rows.Count > 0)
                    {
                        response._EmployeeList = UtilityAccess.DropDownList(ds1.Tables[5], 1);
                    }

                }
                if (dsdept != null && dsdept.Tables[1].Rows.Count >= 0)
                {
                    response._DepartmentList = UtilityAccess.DepartmentList(dsdept.Tables[1], 1);
                }
                response._MedicineList = UtilityAccess.DropDownList(ds.Tables[2], 1);
                response._DetailsofMedicineList2 = detailsresponseList;
                response._UnitList = UtilityAccess.UnitList(ds.Tables[5],1);
                //response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[4], 1);
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicinePrescribeAccess", "GetMedicinePrescribeDataById");
                returnResult = -1;
                return null;
            }
        }


        public static DataTable AddNewTableData1(MedicinePrescribeModel models)
        {
            DataTable dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow = new DataTable();
            dtSetupSeriesRow.Columns.Add("MedicineID", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Quantity", typeof(System.Int32));
            dtSetupSeriesRow.Columns.Add("Remark", typeof(System.String));
            try
            {
                if (models._DetailsofMedicineList2 != null && models._DetailsofMedicineList2.Count > 0)
                {
                    foreach (var item in models._DetailsofMedicineList2)
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
                ApplicationLogger.LogError(ex, "MedicinePrescribeAccess", "AddNewTableData1");
                return null;
            }
        }
        public MedicinePrescribeModel GetProjectCommondata()
        {
            try
            {
                MedicinePrescribeModel response = new MedicinePrescribeModel();
                DataSet ds = PPCdata.GetProjectCommondata();
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        response._EmployeeList = UtilityAccess.DropDownList(ds.Tables[5], 1);
                        response._UnitList = UtilityAccess.UnitList(ds.Tables[0], 1);
                        response._DepartmentList = UtilityAccess.DepartmentList(ds.Tables[1], 1);
                    }
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        response._MedicineList = UtilityAccess.DropDownList(ds.Tables[2], 1);
                    }
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "MedicinePrescribeAccess", "GetProjectCommondata");
                return null;
            }
        }

    }
}



