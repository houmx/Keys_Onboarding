using Keys_Onboarding.Global;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Pages.OwnerPages.Owners.Properties
{
    class SendRequestPage
    {
        public SendRequestPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region Summary Section WebElements Definition 
        
        //Define tenant text      
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[1]/div[2]/div")]
        private IWebElement TenantText { set; get; }

        //Define tenant dropdown     
        [FindsBy(How = How.XPath, Using = "//select[@id='tenant-select']")]
        private IWebElement TenantDropdown { set; get; }

        //Define type dropdown   
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[1]/div[3]/div[1]/select")]
        private IWebElement TypeDropdown { set; get; }

        //Define description text  
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[1]/div[4]/form/div/textarea")]
        private IWebElement DescriptionText { set; get; }

        //Define choose files button  
        [FindsBy(How = How.XPath, Using = ".//*[@id='fileUpload']")]
        private IWebElement ChooseFilesButton { set; get; }

        //Define save button
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[2]/button")]
        private IWebElement SaveButton { set; get; }

        //Define close button
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div/div[2]/a")]
        private IWebElement CloseButton { set; get; }

        #endregion

        internal void AddRequstInformation()
        {
            // Populating the data from Excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Send Request");

            string tenant = ExcelLib.ReadData(2, "Tenant");
            string type = ExcelLib.ReadData(2, "Type");

            //choose tenant from dropdown list
            TenantText.Click();
            Driver.driver.FindElement(By.XPath(String.Format(".//*[@id='main-content']/section/div/div[1]/div[2]/div/div[2]/div[text()='{0}']", tenant))).Click();


            //choose type from dropdown list
            SelectElement select2 = new SelectElement(TypeDropdown);
            select2.SelectByText(type);
            //enter description
            DescriptionText.SendKeys(ExcelLib.ReadData(2,"Description"));
            //upload files
            ChooseFilesButton.SendKeys(ExcelLib.ReadData(2, "Choose Files"));

        }

        internal void SaveRequest()
        {
            SaveButton.Click();
        }

        internal void CloseRequest()
        {
            CloseButton.Click();
        }
    }
}
