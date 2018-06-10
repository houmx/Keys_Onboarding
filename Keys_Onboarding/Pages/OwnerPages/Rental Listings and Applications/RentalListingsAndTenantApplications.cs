using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Pages.Owners.Rental_Listings_and_Applications
{
    class RentalListingsAndTenantApplications
    {
        public RentalListingsAndTenantApplications()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region WebElements Definition 

        //Define header    
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[1]/div[1]/div[1]/h2")]
        private IWebElement header { set; get; }

        #endregion

        internal bool IsHeaderDisplayed()
        {
            if (header.Displayed)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
