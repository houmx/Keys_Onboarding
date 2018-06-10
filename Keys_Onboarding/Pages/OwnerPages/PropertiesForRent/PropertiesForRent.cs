using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Keys_Onboarding.Pages.OwnerPages.PropertiesForRent
{
    class PropertiesForRent
    {
        public PropertiesForRent()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region Property Section WebElements Definition

        //Define search box
        [FindsBy(How = How.XPath, Using = ".//*[@id='SearchBox']")]
        private IWebElement SearchBox { set; get; }

        //Define search button
        [FindsBy(How = How.XPath, Using = ".//*[@id='icon-submitt']")]
        private IWebElement SearchButton { set; get; }

        //Define property title 
        [FindsBy(How = How.XPath, Using = "xxxxxxxxxxxxxxxxxxx")]
        private IWebElement PropertyTitle { set; get; }

        #endregion

        //Search the rental property
        internal bool SearchRentalPropertySuccessfully(String searchPropertyName)
        {
            Thread.Sleep(4000);
            //Enter the value in the search bar
            SearchBox.SendKeys(searchPropertyName);
            //Click on the search button
            SearchButton.Click();

            int searchResultNum = Driver.driver.FindElements(By.XPath("//html//div[@class='ui three stackable cards']/div")).Count;
            if (searchResultNum != 0)
            {

                string ExpectValue = searchPropertyName;
                for (int i = 1; i <= searchResultNum; i++)
                {
                    string ActualValue = Driver.driver.FindElement(By.XPath(String.Format(".//*[@id='mainPage']/div[4]/div['{0}']/div[2]/a", i))).Text;
                    if (ActualValue.Equals(ExpectValue))
                    {
                        return true;
                    }
                }

                return false;
            }
            else
            {
                return false;
            }

        }
    }       
}
