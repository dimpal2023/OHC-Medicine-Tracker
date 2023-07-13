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
    public class Emp_PatientAccess : IEmp_Patient
    {
        Emp_PatientData PPCdata = new Emp_PatientData();
        public Emp_PatientModel GetEmp_PatientData(Emp_PatientModel model)
        {
            Emp_PatientModel response = new Emp_PatientModel();
            List<Emp_PatientModel> responseList = new List<Emp_PatientModel>();
            DataSet ds = PPCdata.SelectAll(model);
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new Emp_PatientModel();

                            response.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
                            response.EmployeeName = row["EmployeeName"].ToString();
                            response.EmployeeCode = row["EmployeeCode"].ToString();
                            //  response.Dob = Convert.ToDateTime(row["Dob"].ToString());
                            DateTime tempdate = Convert.ToDateTime(row["Dob"]);
                            string Dob = tempdate.ToString("yyyy-MM-dd");
                            response.Dob = Dob;
                            // response.Dob = Convert.ToString(row["Dob"].ToString());
                            response.Address = row["Address"].ToString();
                            response.EmployeeType = row["EmployeeType"].ToString();
                            response.IsActive = Convert.ToString(row["Status"]);

                            responseList.Add(response);
                        }

                    }
                }
                //response._StatusList = UtilityAccess.StatusListCategory();
                response._Emp_PatientList = responseList;

                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "Emp_PatientAccess", "GetEmp_PatientData");
                return null;
            }

        }
        public Emp_PatientModel AddOrEdit(Emp_PatientModel model)
        {
            Int32 returnResult = 0;
            Emp_PatientModel response = new Emp_PatientModel();
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
                ApplicationLogger.LogError(ex, "Emp_PatientAccess", "AddOrEdit");
                returnResult = -1;
                return null;
            }
        }

        public Emp_PatientModel GetEmp_PatientDataById(Emp_PatientModel model)
        {
            Int32 returnResult = 0;

            Emp_PatientModel response = new Emp_PatientModel();
            List<Emp_PatientModel> responseList = new List<Emp_PatientModel>();
            try
            {
                DataSet ds = PPCdata.GetEmp_PatientDataById(model, out returnResult);
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new Emp_PatientModel();
                            response.EmployeeId = Convert.ToInt32(row["EmployeeId"]);
                            response.EmployeeName = row["EmployeeName"].ToString();
                            response.EmployeeCode = row["EmployeeCode"].ToString();
                            DateTime tempdate = Convert.ToDateTime(row["Dob"]);
                            string Dob = tempdate.ToString("yyyy-MM-dd");
                            response.Dob = Dob;
                            response.Address = row["Address"].ToString();
                            response.EmployeeType = row["EmployeeType"].ToString();
                            response.IsActive = Convert.ToString(row["Status"]);
                            response.IsOutsideWorker = Convert.ToBoolean(row["IsOutSideWorker"]);
                            responseList.Add(response);
                        }
                    }
                    response._StatusList = UtilityAccess.StatusListCategory(); ;
                }
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "Emp_PatientAccess", "GetEmp_PatientDataById");
                returnResult = -1;
                return null;
            }
        }
    }
}





