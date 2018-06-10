using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Pages.TenantPages.Dashboard
{
    class TenantDashboardPage
    {
        public TenantDashboardPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region WebElements Definition

        //Define instruction skip button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'Skip')]")]
        private IWebElement InstructionSkipButton { set; get; }

        //Define Tenants tab
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]")]
        private IWebElement TenantTab { set; get; }

        //Define landlord's request button
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[1]/div/a[4]")]
        private IWebElement LandlordRequestButton { set; get; }

        //Define user account button  
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[2]/i")]
        private IWebElement UserAccountButton { set; get; }

        //Define sign out button
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[2]/div/a[3]")]
        private IWebElement SignOutButton { set; get; }

        #endregion

        //Go to landlord's request page
        public void GoToLandlordRequestPage()
        {

            // InstructionSkipButton.Click();

            //Click on the Tenants tab
            TenantTab.Click();

            //Select landlord's request page
            Driver.WaitForElementVisible(Driver.driver, By.XPath("html/body/div[1]/div/div[2]/div[1]/div/a[4]"), 15);
            LandlordRequestButton.Click();
        }

    }
}

