using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Pages.TenantPages.Tenants
{
    class LandlordRequestPage
    {
        public LandlordRequestPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region Property Section WebElements Definition

        //Define property details section header
        [FindsBy(How = How.XPath, Using = ".//*[@id='property-details']/h2")]
        private IWebElement PropertyFormHeader { set; get; }

        #endregion
    }
}
