
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
    public class ExceptionAccess : IExceptions
    {
        ExceptionData PPCdata = new ExceptionData();

        public ExceptionModels GetExceptionData()
        {
            ExceptionModels response = new ExceptionModels();
            List<ExceptionModels> ExceptionModelsList = new List<ExceptionModels>();
            DataSet ds = PPCdata.GetExceptionData();
            try
            {
                if (ds != null && ds.Tables.Count > 0)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        foreach (DataRow row in ds.Tables[0].Rows)
                        {
                            response = new ExceptionModels();
                            response.Id = Convert.ToInt32(row["Id"]);
                            response.ExceptionType = Convert.ToString(row["ExceptionType"]);
                            response.BaseType = Convert.ToString(row["BaseType"]);
                            response.Title = Convert.ToString(row["Title"]);
                            response.Message = Convert.ToString(row["Message"]);
                            response.StackTrace = Convert.ToString(row["StackTrace"]);
                            response.HelpLink = Convert.ToString(row["HelpLink"]);
                            response.Class = Convert.ToString(row["Class"]);
                            response.Method = Convert.ToString(row["Method"]);
                            response.LoggedUserId = Convert.ToString(row["LoggedUserId"]);
                            response.CreatedDate = Convert.ToString(row["CreatedDate"]);
                            ExceptionModelsList.Add(response);
                        }
                    }
                }
                response.exceptionModels = ExceptionModelsList;
                return response;
            }
            catch (Exception ex)
            {
                ApplicationLogger.LogError(ex, "InventoryTabularViewAccess", "GetTabularViewData");
                return null;
            }
        }
    }
}
