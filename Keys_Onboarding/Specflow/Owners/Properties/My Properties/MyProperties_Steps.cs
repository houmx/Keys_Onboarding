using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using Keys_Onboarding.Config;
using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using Keys_Onboarding.Pages.LoginRegister;
using Keys_Onboarding.Pages.Owners.Properties;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using TechTalk.SpecFlow;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Specflow.Owners.Properties.My_Properties
{
    [Binding]
    public class MyProperties_Steps : Global.Base
    {
        #region Background
        [Given(@"I have logged into the application")]
        public void GivenIHaveLoggedIntoTheApplication()
        {

            if (Keys_Resource.IsLogin == "true")
            {
                LoginPage loginobj = new LoginPage();
                loginobj.LoginSuccessfull();
            }
            else
            {
                RegisterPage obj = new RegisterPage();
                obj.Navigateregister();
            }

        }

        [Given(@"I'm already on the My Properties Page")]
        public void GivenIMAlreadyOnTheMyPropertiesPage()
        {
            DashboardPage dashboard = new DashboardPage();
            dashboard.GoToMyPropertiesPage();
        }
        #endregion 

        [Then(@"the search result for this property is right")]
        public void ThenTheSearchResultForThisPropertyIsRight()
        {
            // Got the search data from excel
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Property Details");
            String searchPropertyName = ExcelLib.ReadData(2, "Property Name");

            // Creates a toggle for the given test, adds all log events under it    
            test = extent.CreateTest("Search for a Property");

            MyPropertiesPage propertyOwner = new MyPropertiesPage();

            //Assert.AreEqual(ExpectedValue, ActualValue);
            if (propertyOwner.SearchdAPropertySuccessfully(searchPropertyName))

                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test Passed, Search successfull");

            else
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test Failed, Search Unsuccessfull");

        }


    }
}
