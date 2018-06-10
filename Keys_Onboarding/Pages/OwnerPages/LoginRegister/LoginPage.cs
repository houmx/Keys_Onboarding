using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages.LoginRegister
{
    internal class LoginPage
    {      
        //create constructor
        public LoginPage()
        {
            PageFactory.InitElements(Driver.driver, this);
        }
              

        #region  Initialize Web Elements 
        // Finding the Email Field
        [FindsBy(How = How.XPath, Using = "//*[@id='UserName']")]
        private IWebElement Email { get; set; }

        // Finding the Password Field
        [FindsBy(How = How.XPath, Using = "//*[@id='Password']")]
        private IWebElement PassWord { get; set; }

        // Finding the Login Button
        [FindsBy(How = How.XPath, Using = ".//*[@id='sign_in']/div[1]/div[4]/button")]
        private IWebElement loginButton { get; set; }

        #endregion

        internal void LoginSuccessfull(int rowNum)
        {
           // Driver.WaitForElementVisible(Driver.driver,By.XPath("//*[@id='UserName']"),5);

            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "LoginPage");

            // Navigating to Login page using value from Excel
            Driver.driver.Navigate().GoToUrl(ExcelLib.ReadData(rowNum, "Url"));

            // Sending the username 
            Email.SendKeys(ExcelLib.ReadData(rowNum, "Email"));

            // Sending the password
            PassWord.SendKeys(ExcelLib.ReadData(rowNum, "Password"));

            // Clicking on the login button
            loginButton.Click();
        }
    }
}