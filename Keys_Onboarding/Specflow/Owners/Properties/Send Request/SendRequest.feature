Feature: SpecFlowFeature1


Background: 
	Given I have logged into the application 
		And I'm already under the Send Request Page of a given property

 
Scenario: Send a request to tenant
	When I enter all the request information 
		And I click save button under Send Request page
	Then I'am navigated to My Properties page from Send Request page

Scenario: Login as tenant and check this new request send by owner
	Given The owner already sent a request to me
	When I login as tenant
		And I go to Landlord's Request page
	Then I can see this new request