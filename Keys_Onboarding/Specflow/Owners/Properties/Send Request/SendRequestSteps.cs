using Keys_Onboarding.Global;
using Keys_Onboarding.Pages;
using Keys_Onboarding.Pages.LoginRegister;
using Keys_Onboarding.Pages.OwnerPages.Owners.Properties;
using Keys_Onboarding.Pages.Owners.Properties;
using Keys_Onboarding.Pages.TenantPages.Dashboard;
using System;
using TechTalk.SpecFlow;
using static Keys_Onboarding.Global.CommonMethods;

namespace Keys_Onboarding.Specflow.Owners.Properties.Send_Request
{
    [Binding]
    public class SendRequestSteps:Base
    {
        #region Background
        [Given(@"I'm already under the Send Request Page of a given property")]
        public void GivenIMAlreadyUnderTheSendRequestPageOfAGivenProperty()
        {
            ExcelLib.PopulateInCollection(Base.ExcelPath, "Send Request");
            String propertyName = ExcelLib.ReadData(2, "Property Name");

            //go to my properties page from dashboard
            DashboardPage dashBoard = new DashboardPage();
            dashBoard.GoToMyPropertiesPage();

            //search a property
            MyPropertiesPage myProperty = new MyPropertiesPage();
            myProperty.SearchAPropertySuccessfully(propertyName);

            // go to  send request page
            myProperty.SendRequest();
            
        }
        #endregion

        #region Scenario 1: Send a request to tenant

        [When(@"I enter all the request information")]
        public void WhenIEnterAllTheRequestInformation()
        {
            SendRequestPage sendRequest = new SendRequestPage();
            sendRequest.AddRequstInformation();
        }

        [When(@"I click save button under Send Request page")]
        public void WhenIClickSaveButtonUnderSendRequestPage()
        {
            SendRequestPage sendRequest = new SendRequestPage();
            sendRequest.SaveRequest();
        }

        [Then(@"I'am navigated to My Properties page from Send Request page")]
        public void ThenIAmNavigatedToMyPropertiesPageFromSendRequestPage()
        {
            test = extent.CreateTest("Send Request -- Send a request to tenant");
            test.AssignCategory("Add Tenant Testing");

            MyPropertiesPage propertyOwner = new MyPropertiesPage();

            if (propertyOwner.IsMyPropertiesPageHeaderVisible())
            {
                Base.test.Log(AventStack.ExtentReports.Status.Pass, "Test passed, successfully navigated to My Properties page from Send Request Page");
            }
            else
            {
                Base.test.Log(AventStack.ExtentReports.Status.Fail, "Test falied, fail navigated to My Properties page from Send Request Page");
            }
        }

        #endregion

        #region Scenario 2: Login as tenant and check this new request send by owner

        [Given(@"The owner already sent a request to me")]
        public void GivenTheOwnerAlreadySentARequestToMe()
        {
            SendRequestPage sendRequest = new SendRequestPage();
            sendRequest.AddRequstInformation();
            sendRequest.SaveRequest();
        }

        [When(@"I login as tenant")]
        public void WhenILoginAsTenant()
        {
            DashboardPage dashboard = new DashboardPage();
            dashboard.SignOut();

            LoginPage login = new LoginPage();
            login.LoginSuccessfull(3);
        }

        [When(@"I go to Landlord's Request page")]
        public void WhenIGoToLandlordSRequestPage()
        {
            TenantDashboardPage dashboard = new TenantDashboardPage();
            dashboard.GoToLandlordRequestPage();
        }

        [Then(@"I can see this new request")]
        public void ThenICanSeeThisNewRequest()
        {
            ScenarioContext.Current.Pending();
        }

        #endregion
    }
}
