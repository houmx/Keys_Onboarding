using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Keys_Onboarding.Config;
using Keys_Onboarding.Pages.LoginRegister;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Global
{
    public class Base
    {
        #region To access Path from resource file

        public static int Browser = Int32.Parse(Keys_Resource.Browser);
        public static String ExcelPath = Keys_Resource.ExcelPath;
        public static string ScreenshotPath = Keys_Resource.ScreenShotPath;
        public static string ReportPath = Keys_Resource.ReportPath;
        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        #endregion

    }
}
