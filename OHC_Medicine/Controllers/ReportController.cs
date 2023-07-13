//using FPDAL.Data;
using OHC_Medicine.Models;
using OHCBAL.Business;
using OHCBAL.Interface;
using OHCModel.Model;
using System;

using System.Web.Mvc;

using System.Data;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Reflection;
using System.Text;

using System.Web.UI;
using System.Web.UI.WebControls;


using System.Net;
//using System.Net.Mail;
using System.Configuration;

using System.Web;
using System.Data.SqlClient;
//using ClosedXML.Excel;
namespace OHC_Medicine.Controllers
{
   
    public class ReportController : BaseController
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["OHC"].ConnectionString);
        // GET: Account
        public ActionResult MonthelyDatewiseMedicineReport()
        {
            Session.LCID = 1033;
                ViewBag.Fromdate = Convert.ToString(DateTime.Now.AddMonths(-1).ToString("dd/MMM/yyyy"));
                ViewBag.Todate = Convert.ToString(DateTime.Now.ToString("dd/MMM/yyyy"));
                //ViewBag.Fromdate = Convert.ToString(DateTime.Now.AddMonths(-1).ToString("dd/MM/yyyy"));
                return View();
        }
        //public ActionResult P_MonthelyDatewiseMedicineReport(string visitype, string company, string visitor, string FDate, string TDate, string Req, string status)
        public ActionResult P_MonthelyDatewiseMedicineReport(string finacialYr, string FYearVal, string visitor, string FDate, string TDate, string Req, string status)
        {
            Session.LCID = 1033;
            string mon = status;
            int month = Convert.ToInt32(status);
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                ViewBag.Status = 31;
            }
            else
            {
                ViewBag.Status = 30;
            }
            ViewBag.month = finacialYr;
            var pp = ReportCourierPDF(finacialYr, FYearVal, visitor, FDate, TDate, Req, status, status);
            return PartialView(pp);
        }
        public static DataTable ToDataTable<T>(List<T> items)
        {
            DataTable dataTable = new DataTable(typeof(T).Name);
            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | System.Reflection.BindingFlags.Instance);
            foreach (PropertyInfo prop in Props)
            {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            //---------------------
            DataRow dr = dataTable.NewRow();
            int rr = 0;
            foreach (PropertyInfo prop in Props)
            {
                ////Setting column names as Property names
                //dataTable.Columns.Add(prop.Name);
                //dr[rr] = prop.Name;
                
                 dr[rr] = prop.Name.Replace("IssueDay", "").Replace("Day","");
               
                rr = rr + 1;
            }
            //dr[0] = "coldata1";
            dataTable.Rows.Add(dr);
            foreach (T item in items)
            {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++)
                {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                    //values[i] = Convert.ChangeType(i[""], "dd/MMM/yyyy");
                }
                dataTable.Rows.Add(values);
            }
            return dataTable;
        }
        public List<DataFieldDatewiseReport> ReportCourierPDF(params string[] paramtr)
        {
            List<DataFieldDatewiseReport> Report = new List<DataFieldDatewiseReport>();
            try
            {
               int FYearVal = Convert.ToInt32(paramtr[1]);
                int month = Convert.ToInt32(paramtr[7]);
                int monthday = 0;
                if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
                {
                    monthday = 31;
                }
                else
                {
                    monthday = 30;
                }
                if (con.State == ConnectionState.Closed) { con.Open(); }
                string query = "";
                query = "exec[dbo].[Proc_MonthelyDatewiseReport] "+month+ "," + FYearVal + "";
                SqlCommand cmd = new SqlCommand(query, con);
                using (SqlDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read())
                    {
                        DataFieldDatewiseReport dataField = new DataFieldDatewiseReport();
                        dataField.ID = Convert.ToInt32(rdr["ID"].ToString());
                        dataField.MedicineName = rdr["MedicineName"].ToString();
                        //taField.Day25 = Convert.ToInt32(rdr["Day25"].ToString());
                        dataField.Day1 = Convert.ToInt32(rdr["Day1"].ToString());
                        dataField.Day2 = Convert.ToInt32(rdr["Day2"].ToString());
                        dataField.Day3 = Convert.ToInt32(rdr["Day3"].ToString());
                        dataField.Day4 = Convert.ToInt32(rdr["Day4"].ToString());
                        dataField.Day5 = Convert.ToInt32(rdr["Day5"].ToString());
                        dataField.Day6 = Convert.ToInt32(rdr["Day6"].ToString());
                        dataField.Day7 = Convert.ToInt32(rdr["Day7"].ToString());
                        dataField.Day8 = Convert.ToInt32(rdr["Day8"].ToString());
                        dataField.Day9 = Convert.ToInt32(rdr["Day9"].ToString());
                        dataField.Day10 = Convert.ToInt32(rdr["Day10"].ToString());
                        dataField.Day11 = Convert.ToInt32(rdr["Day11"].ToString());
                        dataField.Day12 = Convert.ToInt32(rdr["Day12"].ToString());
                        dataField.Day13 = Convert.ToInt32(rdr["Day13"].ToString());
                        dataField.Day14 = Convert.ToInt32(rdr["Day14"].ToString());
                        dataField.Day15 = Convert.ToInt32(rdr["Day15"].ToString());
                        dataField.Day16 = Convert.ToInt32(rdr["Day16"].ToString());
                        dataField.Day17 = Convert.ToInt32(rdr["Day17"].ToString());
                        dataField.Day18 = Convert.ToInt32(rdr["Day18"].ToString());
                        dataField.Day19 = Convert.ToInt32(rdr["Day19"].ToString());
                        dataField.Day20 = Convert.ToInt32(rdr["Day20"].ToString());
                        dataField.Day21 = Convert.ToInt32(rdr["Day21"].ToString());
                        dataField.Day22 = Convert.ToInt32(rdr["Day22"].ToString());
                        dataField.Day23 = Convert.ToInt32(rdr["Day23"].ToString());
                        dataField.Day24 = Convert.ToInt32(rdr["Day24"].ToString());
                        dataField.Day25 = Convert.ToInt32(rdr["Day25"].ToString());
                        dataField.Day26 = Convert.ToInt32(rdr["Day26"].ToString());
                        dataField.Day27 = Convert.ToInt32(rdr["Day27"].ToString());
                        dataField.Day28 = Convert.ToInt32(rdr["Day28"].ToString());
                        dataField.Day29 = Convert.ToInt32(rdr["Day29"].ToString());
                        dataField.Day30 = Convert.ToInt32(rdr["Day30"].ToString());
                        if (monthday == 31)
                        {
                            dataField.Day31 = Convert.ToInt32(rdr["Day31"].ToString());
                        }
                        dataField.IssueDay1 = Convert.ToInt32(rdr["IssueDay1"].ToString());
                        dataField.IssueDay2 = Convert.ToInt32(rdr["IssueDay2"].ToString());
                        dataField.IssueDay3 = Convert.ToInt32(rdr["IssueDay3"].ToString());
                        dataField.IssueDay4 = Convert.ToInt32(rdr["IssueDay4"].ToString());
                        dataField.IssueDay5 = Convert.ToInt32(rdr["IssueDay5"].ToString());
                        dataField.IssueDay6 = Convert.ToInt32(rdr["IssueDay6"].ToString());
                        dataField.IssueDay7 = Convert.ToInt32(rdr["IssueDay7"].ToString());
                        dataField.IssueDay8 = Convert.ToInt32(rdr["IssueDay8"].ToString());
                        dataField.IssueDay9 = Convert.ToInt32(rdr["IssueDay9"].ToString());
                        dataField.IssueDay10 = Convert.ToInt32(rdr["IssueDay10"].ToString());
                        dataField.IssueDay11 = Convert.ToInt32(rdr["IssueDay11"].ToString());
                        dataField.IssueDay12 = Convert.ToInt32(rdr["IssueDay12"].ToString());
                        dataField.IssueDay13 = Convert.ToInt32(rdr["IssueDay13"].ToString());
                        dataField.IssueDay14 = Convert.ToInt32(rdr["IssueDay14"].ToString());
                        dataField.IssueDay15 = Convert.ToInt32(rdr["IssueDay15"].ToString());
                        dataField.IssueDay16 = Convert.ToInt32(rdr["IssueDay16"].ToString());
                        dataField.IssueDay17 = Convert.ToInt32(rdr["IssueDay17"].ToString());
                        dataField.IssueDay18 = Convert.ToInt32(rdr["IssueDay18"].ToString());
                        dataField.IssueDay19 = Convert.ToInt32(rdr["IssueDay19"].ToString());
                        dataField.IssueDay20 = Convert.ToInt32(rdr["IssueDay20"].ToString());
                        dataField.IssueDay21 = Convert.ToInt32(rdr["IssueDay21"].ToString());
                        dataField.IssueDay22 = Convert.ToInt32(rdr["IssueDay22"].ToString());
                        dataField.IssueDay23 = Convert.ToInt32(rdr["IssueDay23"].ToString());
                        dataField.IssueDay24 = Convert.ToInt32(rdr["IssueDay24"].ToString());
                        dataField.IssueDay25 = Convert.ToInt32(rdr["IssueDay25"].ToString());
                        dataField.IssueDay26 = Convert.ToInt32(rdr["IssueDay26"].ToString());
                        dataField.IssueDay27 = Convert.ToInt32(rdr["IssueDay27"].ToString());
                        dataField.IssueDay28 = Convert.ToInt32(rdr["IssueDay28"].ToString());
                        dataField.IssueDay29 = Convert.ToInt32(rdr["IssueDay29"].ToString());
                        dataField.IssueDay30 = Convert.ToInt32(rdr["IssueDay30"].ToString());
                        if (monthday == 31)
                        {
                            dataField.IssueDay31 = Convert.ToInt32(rdr["IssueDay31"].ToString());
                        }
                        dataField.Purchasetotal = Convert.ToInt32(rdr["Purchasetotal"].ToString());
                        dataField.Medicineissue= rdr["Medicineissue"].ToString();
                        dataField.Issuetotal=Convert.ToInt32(rdr["Issuetotal"].ToString());
                        dataField.PreviousMonthtotal = Convert.ToInt32(rdr["PreviousMonthtotal"].ToString());
                        dataField.Balance = Convert.ToInt32(rdr["Balance"].ToString());
                        Report.Add(dataField);
                    }
                }
            }
            catch (Exception ex)
            {
                //SendExcepToDB(ex);
            }
            finally
            {
                if (con.State == ConnectionState.Open) { con.Close(); }
            }
            return Report;
        }
        
    }
}
