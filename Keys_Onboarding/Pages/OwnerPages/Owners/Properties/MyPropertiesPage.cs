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
        

        //Define my properties page header       
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div[1]/div[1]/h2[1]")]
        private IWebElement MyPropertiesPageHeader { set; get; }

        //Define search bar        
        [FindsBy(How = How.XPath, Using = "//input[@name='SearchString']")]
        private IWebElement SearchBar { set; get; }

        //Define search button
        [FindsBy(How = How.XPath, Using = ".//*[@id='icon-submitt']")]
        private IWebElement SearchButton { set; get; }

        //Define add new property button
        [FindsBy(How = How.XPath, Using = "//html//div[@data-bind='visible : MainView']/div/div[@class='ui grid']//a[2]")]
        private IWebElement AddNewPropertyButton { set; get; }

        //Define list a rental button
        [FindsBy(How = How.XPath, Using = "//a[@href='/PropertyOwners/Property/ListRental?propId=-1']")]
        private IWebElement ListARentalButton { set; get; }

        //Define name of the first property in the list
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div[2]/div[1]/div[1]/a/h3")]
        private IWebElement FirstPropertyNameButton { set; get; }

        //Define add tenant button
        [FindsBy(How = How.XPath, Using = "//a[@class='ui basic mini teal button'][contains(text(),'Add Tenant')]")]
        private IWebElement AddTenantButton { set; get; }

        //Define send request button
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div[3]/div/div/div/div/div[2]/div[2]/div/a[3]")]
        private IWebElement SendRequestButton { set; get; }

        //Define total button
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div/div/div[2]/div[1]/div[3]/div/i")]
        private IWebElement TotalButton { set; get; }

        //Define manage tenant
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div/div/div[2]/div[1]/div[3]/div/div/div[3]/a")]
        private IWebElement ManageTenantButton { set; get; }


        #endregion
        //check is header visible
        internal bool IsMyPropertiesPageHeaderVisible()
        {
            Driver.WaitForElementVisible(Driver.driver,By.XPath(".//*[@id='main-content']/section/div[1]/div/div[1]/div[1]/h2[1]"),10);
            try
            {
                if (MyPropertiesPageHeader.Displayed)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
 
        }

        //Click add new property button
        internal void AddNewProperty()
        {
                AddNewPropertyButton.Click();
        }
        
        //Click list a rental button
        internal void ListARental()
        {
            ListARentalButton.Click();
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
        internal bool SearchAPropertySuccessfully(String searchPropertyName)
        {
            try
            {

                Driver.WaitForElementVisible(Driver.driver, By.XPath("//input[@name='SearchString']"),15);
                //Enter the value in the search bar
                SearchBar.SendKeys(searchPropertyName);

                //Click on the search button
                SearchButton.Click();

                string ExpectValue = searchPropertyName;
                string ActualValue = FirstPropertyNameButton.Text;

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

        //Click the first property name in the property list
        internal void ClickFirstPorpertyNameInList()
        {
            FirstPropertyNameButton.Click();
        }

        //Click add tenant button and go to add tenant page
        internal void AddTenant()
        {
            //Driver.WaitForElementClickable(Driver.driver,By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div/div[2]/div[2]/div/a[1]"),10);
            AddTenantButton.Click();
        }

        //Click send request button and go to send request page
        internal void SendRequest()
        {
            SendRequestButton.Click();
        }

        //Click manage tenant button and to to manage tenant page
        internal void GoToManageTenantPage()
        {
            Driver.WaitForElementClickable(Driver.driver, By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div/div/div[2]/div[1]/div[3]/div/i"), 10);
            TotalButton.Click();
            Driver.WaitForElementClickable(Driver.driver, By.XPath(".//*[@id='main-content']/section/div[1]/div/div[3]/div/div[1]/div/div/div[2]/div[1]/div[3]/div/div/div[3]/a"), 10);
            ManageTenantButton.Click();
        }

    }
}