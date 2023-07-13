using Infotech.ClassLibrary;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OHCDAL.Data
{
    public class UtilityData : ConnectionObjects
    {

        #region Common_Lists
        public DataSet DepartmentByUnit(Int32 UnitId)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                           new SqlParameter("@Mode","Unit"),
                                           new SqlParameter("@Id",UnitId),
                                           new SqlParameter("@UserUnitId",0),
                                           new System.Data.SqlClient.SqlParameter("ReturnValue", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, 0, 0, System.String.Empty, System.Data.DataRowVersion.Default, null),
                                        };
            try
            {

                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetDepartmentByUnit", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UtilityData", "DepartmentByUnit");
                return null;
            }
            finally
            {
            }
        }

        public DataSet LocationByDepartment(Int32 DepartmentId)
        {
            DataSet myDataSet = null;
            SqlParameter[] parameters ={
                                           new SqlParameter("@Mode","Department"),
                                           new SqlParameter("@Id",DepartmentId),
                                              new SqlParameter("@UserUnitId",0),
                                           new System.Data.SqlClient.SqlParameter("ReturnValue", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, 0, 0, System.String.Empty, System.Data.DataRowVersion.Default, null),
                                        };
            try
            {

                myDataSet = SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetDepartmentByUnit", parameters);
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UtilityData", "LocationByDepartment");
                return null;
            }
            finally
            {
            }
        }
        public MedicineIssuancetootherunitfirstaddModel MedicineDetails(Int32 MedicineId,Int32 UserUnitId)
        {
            DataSet myDataSet = null;
            MedicineIssuancetootherunitfirstaddModel model = new MedicineIssuancetootherunitfirstaddModel();
            //string[] myDataSet= null;
            SqlParameter[] parameters ={
                                           new SqlParameter("@Mode","Medicine"),
                                           new SqlParameter("@Id",MedicineId),
                                            new SqlParameter("@UserUnitId",UserUnitId),
                                           new System.Data.SqlClient.SqlParameter("ReturnValue", System.Data.SqlDbType.Int, 4, System.Data.ParameterDirection.ReturnValue, false, 0, 0, System.String.Empty, System.Data.DataRowVersion.Default, null),
                                        };
            try
            {
                myDataSet =(SqlHelper.ExecuteDataset(ConnectionString, CommandType.StoredProcedure, "GetDepartmentByUnit", parameters));
                //int qty=Convert.ToInt32(myDataSet.Tables[0].Rows[0]["Quantity"]);
                //string sql = Convert.ToString(myDataSet.Tables[0].Rows[0]["Quantity"]);
                //if(String.IsNullOrEmpty(sql))
                //{
                //    model.AvailableQty = "0";
                //}
                //else 
                //{
                //    model.AvailableQty = Convert.ToString(myDataSet.Tables[0].Rows[0]["Quantity"]);
                //}
                 model.AvailableQty = Convert.ToString(myDataSet.Tables[0].Rows[0]["Quantity"]);
                model.BatchNo=Convert.ToString(myDataSet.Tables[0].Rows[0]["BatchNumber"]);
                return model;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UtilityData", "MedicineDetails");
                return null;
            }
            finally
            {
            }
        }
        public DataSet FindEmployee_Data(int Type, string query)
        {
            DataSet myDataSet = null;
            try
            {
                //if (Type == 1)
                //{
                //myDataSet = SqlHelper.ExecuteDataset(masterConnectionString, CommandType.Text, "select EMPLOYEE_ID as Emp_ID, NAME, Department, convert(varchar(15),[MOBILE NUMBER]) as MbNo,[DATE OF BIRTH] as dob,[Email ID] as Email, 'OnRoll' as EmpType from[MasterDatabase].dbo.Master_Requestor where Status = 'Active' and  EMPLOYEE_ID='" + query + "'");
                //}
                //else
                //{

                //}
                //myDataSet = SqlHelper.ExecuteDataset(masterConnectionString, CommandType.Text, "select EMPLOYEE_ID as Emp_ID, NAME, Department, cast((convert(bigint,[MOBILE NUMBER])) as varchar(20)) as MbNo,[DATE OF BIRTH] as dob,[Email ID] as Email, 'OnRoll' as EmpType from[MasterDatabase].dbo.Master_Requestor where Status = 'Active' and  EMPLOYEE_ID Like '%" + query + "%'");
                myDataSet = SqlHelper.ExecuteDataset(masterConnectionString, CommandType.Text, "select EMPLOYEE_ID as Emp_ID, NAME, Department, cast((convert(bigint,[MOBILE NUMBER])) as varchar(20)) as MbNo,[DATE OF BIRTH] as dob,[Email ID] as Email, 'OnRoll' as EmpType from[MasterDatabase].dbo.Master_Requestor where Status = 'Active' and  NAME Like '%" + query + "%'");
                if (myDataSet.Tables[0].Rows.Count == 0)
                {
                    myDataSet = SqlHelper.ExecuteDataset(WorkersConnectionString, CommandType.Text, "select wm.EMP_ID as Emp_ID,EMP_NAME as NAME,dm.DEPT_NAME as Department,MOBILE_NO as MbNo,DATE_OF_BIRTH as dob, EMAIL_ID as Email,case when wm.WF_EMP_TYPE=1 then 'OnRoll' else 'Contract' end as EmpType from TAB_WORKFORCE_MASTER as wm inner join TAB_DEPARTMENT_MASTER as dm on dm.DEPT_ID = wm.DEPT_ID inner join TAB_WORFORCE_TYPE as emp on emp.WF_EMP_TYPE = wm.WF_EMP_TYPE inner join TAB_BUILDING_MASTER as bm on bm.BUILDING_ID = wm.BUILDING_ID where wm.STATUS = 'Y'  and  EMP_NAME Like '%" + query + "%'");
                    //myDataSet = SqlHelper.ExecuteDataset(WorkersConnectionString, CommandType.Text, "select wm.EMP_ID as Emp_ID,EMP_NAME as NAME,dm.DEPT_NAME as Department,MOBILE_NO as MbNo,DATE_OF_BIRTH as dob, EMAIL_ID as Email,case when wm.WF_EMP_TYPE=1 then 'OnRoll' else 'Contract' end as EmpType from TAB_WORKFORCE_MASTER as wm inner join TAB_DEPARTMENT_MASTER as dm on dm.DEPT_ID = wm.DEPT_ID inner join TAB_WORFORCE_TYPE as emp on emp.WF_EMP_TYPE = wm.WF_EMP_TYPE inner join TAB_BUILDING_MASTER as bm on bm.BUILDING_ID = wm.BUILDING_ID where EMP_NAME LIKE '%a%'");
                }
                return myDataSet;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "UserMasterData", "GetProjectCommondata");
                return null;
            }
            finally

            {
            }
        }
        #endregion Common_Lists
    }
}
