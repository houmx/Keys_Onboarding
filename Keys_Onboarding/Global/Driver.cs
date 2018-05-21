using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Global
{
    class Driver
    {
        //Initialise the browser
        public static IWebDriver driver { get; set; }


        #region WaitforElement 

        public static void wait(int time)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(time);

        }
        public static void  WaitForElementVisible(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            wait.Until(ExpectedConditions.ElementIsVisible(by));
        }
        public static void WaitForElementClickable(IWebDriver driver, By by, int timeOutinSeconds)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOutinSeconds));
            wait.Until(ExpectedConditions.ElementToBeClickable(by));
        }
        #endregion


    }
}
