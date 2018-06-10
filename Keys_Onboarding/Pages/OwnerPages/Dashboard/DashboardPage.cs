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

        //Define Properties For Rent page
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/a[2]")]
        private IWebElement PropertyForRentTab { set; get; }

        //Define user account button  
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[2]/i")]
        private IWebElement UserAccountButton { set; get; }

        //Define sign out button
        [FindsBy(How = How.XPath, Using = "html/body/div[1]/div/div[2]/div[2]/div/a[3]")]
        private IWebElement SignOutButton { set; get; }

        #endregion

        //Go to my properties page
        public void GoToMyPropertiesPage()
        {

            InstructionSkipButton.Click();
            Thread.Sleep(2000);

            //Click on the Owners tab
            Driver.WaitForElementVisible(Driver.driver, By.XPath("//a[@href='/Home/Dashboard']"), 25);
            OwnerTab.Click();

            //Select properties page
            Driver.WaitForElementVisible(Driver.driver, By.XPath("html/body/div[1]/div/div[2]/div[1]/div/a[1]"), 15);
            PropertiesPage.Click();

        }

        //Go to property for rent page
        internal void GotoPropertiesForRentPage()
        {
            Thread.Sleep(2000);

            PropertyForRentTab.Click();
        }

        //Sign out
        internal void SignOut()
        {
            UserAccountButton.Click();

            Driver.WaitForElementClickable(Driver.driver,By.XPath("html/body/div[1]/div/div[2]/div[2]/div/a[3]"),5);
            SignOutButton.Click();
        }
    }
}
