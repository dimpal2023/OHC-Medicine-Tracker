//using FPDAL.Data;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using OHC_Medicine.Models;
using OHCBAL.Business;
using OHCBAL.Interface;
using OHCModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Mvc;



namespace OHC_Medicine.Controllers
{
    public class YearlyInventoryController : BaseController
    {
        // GET: Account
        IInventoryTabularView PPC = new InventoryTabularViewAccess();
        [HttpGet]
        public ActionResult List()
        {
            return View();
        }
        [HttpGet]
        public string GetOHCMonthlyReport(Int64 year)
        {
            MonthlyInventoryReportModel model = new MonthlyInventoryReportModel();
            List<MonthlyInventoryReportModel> modelList = new List<MonthlyInventoryReportModel>();
            string PPCm = "", number = "", month = "", AvlmedCount = "", issuemedCount = "", CurrFinancialYear = "", NxtFinancialYear;
            CurrFinancialYear = Convert.ToString(DateTime.Today.Month >= 4 ? DateTime.Today.Year : DateTime.Today.Year);
            NxtFinancialYear = Convert.ToString(DateTime.Today.Month >= 4 ? DateTime.Today.Year + 1 : DateTime.Today.Year);
            PPCm = PPC.GetMonthlyInventoryReport(year);
            JArray CompanyList = JArray.Parse(PPCm);
            JObject CompanyDetail = (JObject)CompanyList[0];
            JArray OrderList = (JArray)CompanyDetail["MonthWiseReport"];
            string html = "<div>";
            html = "<table class='table table-bordered scrolldown'>";
            html += "<thead>";
            html += "<tr>";
            html += "<th colspan='3' style='background:#e1acc9;border:1px solid black;'><img src='http://localhost:63850/assets/images/karamlogo.png'/></th>";
            html += "<th colspan='26' style='background:#e1acc9;border:1px solid black;'><h3 style='text-align:center'><span><b>Medical Treatment Slip</b></span> <br/> <span><b>PN International Pvt Ltd.</b></span> <br/> <span><b>(F.Y April-" + CurrFinancialYear+" - March-"+NxtFinancialYear+ ")</b></span></h3> </th>";
            html += "</tr>";
            
            html += "<tr>";
            html += "<th style='border:1px solid black' colspan='2'></th>";
            html += "<th colspan='12' style='background:#7ecfa1;border:1px solid black;'>Material Available in Month(Master Store)</th>";
            html += "<th colspan='12' style='background:#96d5f3;border:1px solid black;'>Issue in Month</th>";
            html += "<th style='border:1px solid black' colspan='3'>Grand</th>";
            html += "</tr>";
            html += "<tr>";
            html += "<th style='border:1px solid black'>SR.No</th>";
            html += "<th style='border:1px solid black'>Name of Item</th>";
            html += "<th style='background:#a8acaf;border:1px solid black;'>Jan</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Feb</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Mar</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Apr</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>May</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Jun</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Jul</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Aug</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Sep</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Oct</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Nov</th>";
            html += "<th style='background:#a8acaf ;border:1px solid black;'>Dec</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Jan</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Feb</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Mar</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Apr</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>May</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Jun</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Jul</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Aug</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Sep</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Oct</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Nov</th>";
            html += "<th style='background:#96d5f3 ;border:1px solid black;'>Dec</th>";
            html += "<th style='border:1px solid black' >Total Purchase</th>";
            html += "<th style='border:1px solid black'>Total Issue</th>";
            html += "<th style='border:1px solid black'>Balance</th>";
            html += "</tr>";
            html += "</thead>";
            html += "<tbody>";
            for (var i = 0; i < OrderList.Count; i++)
            {
                JObject OrderDetail = (JObject)OrderList[i];
                string MedicineName = OrderDetail["Medicine"].ToString();
                int TotalPurchase = 0, TotalIssue = 0;
                html += "<tr style='border:1px solid black'>";
                html += "<td style='border:1px solid black'>" + Convert.ToInt32(i+1)+ "</td>";
                html += "<td style='border:1px solid black'>" + MedicineName + "</td>";
                JArray MonthList = (JArray)OrderDetail["MonthNames"];
                for (var j = 0; j < MonthList.Count; j++)
                {
                    JObject MonthDetail = (JObject)MonthList[j];
                    //string number = MonthDetail["number"].ToString();
                    JArray AvailabiltyList = (JArray)OrderDetail["AvailableInMonth"];
                    if (AvailabiltyList.Count == 0)
                    {
                        html += "<td style='border:1px solid black'></td>";
                    }
                    for (var k = 0; k < AvailabiltyList.Count; k++)
                    {
                        JObject AvailabiltyDetail = (JObject)AvailabiltyList[k];
                        number = MonthDetail["number"].ToString();
                        month = AvailabiltyDetail["MONTH"].ToString();
                        AvlmedCount = AvailabiltyDetail["MEDICINECOUNT"].ToString();
                        //html += "<td>" + month + "</td>";
                        if (month == number)
                        {
                            html += "<td style='border:1px solid black'>" + AvlmedCount + "</td>";
                            TotalPurchase += Convert.ToInt32(AvlmedCount);
                        }
                        else
                        {
                            html += "<td style='border:1px solid black'></td>";
                        }
                    }
                }
                for (var j = 0; j < MonthList.Count; j++)
                {
                    JObject MonthDetail = (JObject)MonthList[j];
                    //string number = MonthDetail["number"].ToString();
                    JArray IssueList = (JArray)OrderDetail["IssueInMonth"];
                    if (IssueList.Count == 0)
                    {
                        html += "<td style='border:1px solid black'></td>";
                    }
                    for (var L = 0; L < IssueList.Count; L++)
                    {
                        JObject IssueDetail = (JObject)IssueList[L];
                        number = MonthDetail["number"].ToString();
                        month = IssueDetail["MONTH"].ToString();
                        issuemedCount = IssueDetail["Quantity"].ToString();
                        if (month == number)
                        {
                            html += "<td style='border:1px solid black'>" + issuemedCount + "</td>";
                            TotalIssue += Convert.ToInt32(issuemedCount);
                        }
                        else
                        {
                            html += "<td style='border:1px solid black'></td>";
                        }
                    }
                }
                html += "<td style='border:1px solid black'>" + TotalPurchase + "</td>";
                html += "<td style='border:1px solid black'>" + TotalIssue + "</td>";
                html += "<td style='border:1px solid black'>" + Convert.ToInt32(Convert.ToInt32(TotalPurchase) - Convert.ToInt32(TotalIssue)) + "</td>";
                html += "</tr>";
            }
            html += "</tbody>";
            html += "</table>";
            html += "</div>";
            return html;
        }
        
    }
}