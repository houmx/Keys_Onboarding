using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Keys_Onboarding.Pages
{
    class DashboardPage
    {
        public DashboardPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region WebElements Definition

        //Define instruction skip button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Skip')]")]
        private IWebElement InstructionSkipButton { set; get; }

        //Define Owners tab
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]")]
        private IWebElement OwnerTab { set; get; }

        //Define Properties page
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]/div/a[1]")]
        private IWebElement PropertiesPage { set; get; }

        #endregion

        //Go to my properties page
        public void GoToMyPropertiesPage()
        {

            InstructionSkipButton.Click();
            Thread.Sleep(3000);

            //Click on the Owners tab
            Driver.WaitForElementVisible(Driver.driver, By.XPath("//a[@href='/Home/Dashboard']"), 25);
            OwnerTab.Click();

            //Select properties page
            Driver.WaitForElementVisible(Driver.driver, By.XPath("html/body/div[1]/div/div[2]/div[1]/div/a[1]"), 15);
            PropertiesPage.Click();
        }

    }
}
