using Keys_Onboarding.Global;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Threading;
using static Keys_Onboarding.Global.CommonMethods;


namespace Keys_Onboarding.Pages.Owners.Properties
{ 
    public class MyPropertiesPage
    {
        public MyPropertiesPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }


        #region WebElements Definition
        //Define search bar        
        [FindsBy(How = How.XPath, Using = "//input[@name='SearchString']")]
        private IWebElement SearchBar { set; get; }

        //Define search button
        [FindsBy(How = How.XPath, Using = ".//*[@id='icon-submitt']")]
        private IWebElement SearchButton { set; get; }

        //Define add new property button
        [FindsBy(How = How.XPath, Using = "//a[@href='/PropertyOwners/Property/AddNewProperty']")]
        private IWebElement AddNewPropertyButton { set; get; }

        #endregion


        //Click add new property button
        internal void AddNewProperty()
        {
                AddNewPropertyButton.Click();
        }
        
        //Check if add new property button display
        internal bool IsAddNewPropertyButtonDisplayed()
        {
            if (AddNewPropertyButton.Displayed)
                return true;
            else
                return false;
        }

        //Search the property
        internal bool SearchdAPropertySuccessfully(String searchPropertyName)
        {
            try
            {

                Driver.WaitForElementVisible(Driver.driver, By.XPath("//input[@name='SearchString']"),15);
                //Enter the value in the search bar
                SearchBar.SendKeys(searchPropertyName);

                //Click on the search button
                SearchButton.Click();

                string ExpectValue = searchPropertyName;
                string ActualValue = Driver.driver.FindElement(By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[1]/a/h3")).Text;

                if (ActualValue.Equals(ExpectValue))

                    return true;
                else
                    return false;
            }
            catch
            {
                return false;
            }

         }
    }
}