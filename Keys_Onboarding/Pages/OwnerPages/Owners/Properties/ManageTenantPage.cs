using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Pages.Owners.Properties
{
    class ManageTenantPage
    {
        public ManageTenantPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }


        #region WebElements Definition

        //Define go back to properties button
        [FindsBy(How = How.XPath, Using = "//i[@class='chevron left icon']")]
        private IWebElement GoBackToPropertiesButton { set; get; }

        //Define remove confirm button
        [FindsBy(How = How.XPath, Using = ".//*[@id='removeTenantModal']/div[2]/div[2]/div[2]/button[1]")]
        private IWebElement RemoveConfirmButton { set; get; }

        //Define remove cancel button
        [FindsBy(How = How.XPath, Using = ".//*[@id='removeTenantModal']/div[2]/div[2]/div[2]/button[2]")]
        private IWebElement RemoveCancelButton { set; get; }

        //Define go to next page button
        [FindsBy(How = How.XPath, Using = "//a[contains(.,'»')]")]
        private IWebElement GoToNextPageButton { set; get; }

        #endregion

        internal bool FindATenant(String email)
        {
            try
            {
                while (true)
                {
                    //find the tenant in this page
                    List<IWebElement> list = new List<IWebElement>(Driver.driver.FindElements(By.XPath(".//*[@id='property-grid']/div[1]/div/div/div[2]/div/div[3]/div/span")));
                    for (int i = 0; i < list.Count; i++)
                    {
                        if (list.ElementAt(i).Text.Equals(email))
                        {
                            return true;
                        }
                    }

                    GoToNextPageButton.Click();
                }
            }
            catch (Exception e)
            {
                Console.Write("find tenant exception" + e.Message);
                return false;
            }
        }

        internal void RemoveTenant(string email)
        {
            try
            {
                bool keepGoing = true;
                while(keepGoing)
                {
                    //find the tenant in this page
                    List<IWebElement> list = new List<IWebElement>(Driver.driver.FindElements(By.XPath(".//*[@id='property-grid']/div[1]/div/div/div[2]/div/div[3]/div/span")));
                    for (int i = 1; i <= list.Count&keepGoing; i++)
                    {
                        if (list.ElementAt(i-1).Text.Equals(email))
                        {
                            //delete the tenant
                            IWebElement remove = Driver.driver.FindElement(By.XPath(".//*[@id='property-grid']/div[1]/div[" + i + "]/div/div[2]/div/div[6]/div/div/button"));
                            remove.Click();
                            RemoveConfirmButton.Click();

                            keepGoing = false;
                        }
                    }
                  if(GoToNextPageButton.Displayed & keepGoing)
                  {
                        GoToNextPageButton.Click();
                  }
                  else
                  {
                        keepGoing = false;
                  }
                }

            }
            catch(Exception e)
            {
                Console.Write("find tenant exception" + e.Message);
            }
           
            
        }

        internal void GoBackToProperties()
        {
            GoBackToPropertiesButton.Click();
        }

    }
}
