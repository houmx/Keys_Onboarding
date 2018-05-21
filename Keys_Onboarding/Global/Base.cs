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
        //#endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        public static ExtentHtmlReporter htmlReporter;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            // advisasble to read this documentation before proceeding http://extentreports.relevantcodes.com/net/
            switch (Browser)
            {

                case 1:
                    Driver.driver = new FirefoxDriver();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    break;

            }
            if (Keys_Resource.IsLogin == "true")
            {
                LoginPage loginobj = new LoginPage();
                loginobj.LoginSuccessfull();
            }
            else
            {
                RegisterPage obj = new RegisterPage();
                obj.Navigateregister();
            }

            htmlReporter = new ExtentHtmlReporter(ReportPath);
            htmlReporter.LoadConfig(Keys_Resource.ReportXMLPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(Driver.driver, "Report");//AddScreenCapture(@"E:\Dropbox\VisualStudio\Projects\Beehive\TestReports\ScreenShots\");
            test.Log(Status.Info, "Image example: " + img);
    
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();
            // Close the driver :)            
            Driver.driver.Close();
        }
        #endregion

    }
}
#endregion