using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Keys_Onboarding.Config;
using Keys_Onboarding.Global;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Keys_Onboarding.Hooks
{
    [Binding]
    class GeneralHook : Base
    {
        [BeforeScenario]
        public void Initialize()
        {
            switch (Browser)
            {

                case 1:
                    Driver.driver = new FirefoxDriver();
                    break;
                case 2:
                    Driver.driver = new ChromeDriver();
                    Driver.driver.Manage().Window.Maximize();
                    Driver.driver.Manage().Cookies.DeleteAllCookies();
                    break;

            }
        }
        [BeforeTestRun]
        public static void StartReport()
        {
            htmlReporter = new ExtentHtmlReporter(ReportPath);
            htmlReporter.LoadConfig(Keys_Resource.ReportXMLPath);
            extent = new ExtentReports();
            extent.AttachReporter(htmlReporter);
        }

        [AfterTestRun]
        public static void EndReport()
        {
            // calling Flush writes everything to the log file (Reports)
            extent.Flush();  
        }

        [AfterScenario]
        public void CloseBrowser()
        {
            Driver.driver.Close();
        }
    }
}
