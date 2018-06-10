using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Keys_Onboarding.Pages.Owners.Properties
{
    class PropertyDetailsPage
    {
        public PropertyDetailsPage()
        {
            PageFactory.InitElements(Global.Driver.driver, this);
        }

        #region Summary Section WebElements Definition 
        //Define add tenant button     
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[2]/div/div/div/div[2]/a")]
        private IWebElement AddTenantButton { set; get; }

        //Define tenant number
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[4]/div[1]/div[1]")]
        private IWebElement TenantNumberText { set; get; }

        //Define new request number
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[4]/div[2]/div[1]")]
        private IWebElement NewRequestNumberText { set; get; }

        //Define new maintance number
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[4]/div[3]/div[1]")]
        private IWebElement MaintanceNumberText { set; get; }

        //Define payments this week number
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[4]/div[4]/div[1]")]
        private IWebElement PaymentNumberText { set; get; }
        #endregion

        #region Details Section WebElements Definition 
        //Define Property type
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[1]/div/div[2]")]
        private IWebElement PropertyTypeText { set; get; }

        //Define bedroom number
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[2]/div/div[2]/span[1]")]
        private IWebElement BedroomNumberText { set; get; }

        //Define bathroom number
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[2]/div/div[2]/span[2]")]
        private IWebElement BathroomNumberText { set; get; }

        //Define carpark number
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[2]/div/div[2]/span[3]")]
        private IWebElement CarparkNumberText { set; get; }

        //Define land area
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[3]/div/div[2]/span[1]/span")]
        private IWebElement LandAreaText { set; get; }

        //Define floor area
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[4]/div/div[2]/span[1]/span")]
        private IWebElement FloorAreaText { set; get; }

        //Define target rent
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[5]/div/div[2]/span[1]/span")]
        private IWebElement TargetRentText { set; get; }

        //Define rent Type
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[5]/div/div[2]/span[3]/span")]
        private IWebElement RentTypeText { set; get; }

        //Define year built
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[6]/div/div[2]/span")]
        private IWebElement YearBuiltText { set; get; }

        //Define description
        [FindsBy(How = How.XPath, Using = ".//*[@id='main-content']/section/div[2]/div/div[6]/div[1]/div/div[7]/div/div[2]/span")]
        private IWebElement DescriptionText { set; get; }


        #endregion

        internal int GetTenantNumber()
        {
            return int.Parse(TenantNumberText.Text);
        }

        internal int GetNewRequestNumber()
        {
            return int.Parse(NewRequestNumberText.Text);
        }

        internal int GetMaintanceNumber()
        {
            return int.Parse(MaintanceNumberText.Text);
        }

        internal int GetPaymentNumber()
        {
            return int.Parse(PaymentNumberText.Text);
       
        }
        internal string GetBedroomNumber()
        {
            return BedroomNumberText.Text;
        }

        internal string GetBathroomNumber()
        {
            return BathroomNumberText.Text;
        }

        internal string GetCarparkNumber()
        {
            return CarparkNumberText.Text;
        }

    }
}
