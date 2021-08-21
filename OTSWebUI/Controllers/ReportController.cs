using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OTSWebUI.Controllers
{
    public class ReportController : Controller
    {
        public ActionResult UserReport()
        {
            string ssrsUrl = ConfigurationManager.AppSettings["SSRSReportsUrl"].ToString();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Remote;
            reportViewer.SizeToReportContent = true;
            reportViewer.AsyncRendering = true;
            reportViewer.ServerReport.ReportServerUrl = new Uri(ssrsUrl);
            reportViewer.ServerReport.ReportPath = "/CustomerReports";
            ViewBag.ReportViewer = reportViewer;
            return View();
        }
        public ActionResult ReservationReport()
        {
            string ssrsUrl = ConfigurationManager.AppSettings["SSRSReportsUrl"].ToString();
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.ProcessingMode = ProcessingMode.Remote;
            reportViewer.SizeToReportContent = true;
            reportViewer.AsyncRendering = true;
            reportViewer.ServerReport.ReportServerUrl = new Uri(ssrsUrl);
            reportViewer.ServerReport.ReportPath = "/ReservationReports";
            ViewBag.ReportViewer = reportViewer;
            return View();
        }
    }
}