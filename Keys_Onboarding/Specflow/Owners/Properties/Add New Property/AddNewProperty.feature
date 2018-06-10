Feature: Add New Property Action Test


Background: 
	Given I have logged into the application
		And I'm already on the Add New Property Page


Scenario: Add property details and go to Finance Details Section
	When  I enter all the property details
		And  click next button on Property Details Section
	Then  I'm navigated to the Finace Details Section 

Scenario: Cancel add property under Property Details Section
	When  I click cancel button on Property Details Section
	Then  popup an confirmation dialog

Scenario: Add finance details and go to Tenant Details Section
	Given I'm already on the Finance Details Section
	When  I enter all the finance details 
		And  click next button on the Finance Details Section
	Then  I'm navigated to the Tenant Details Section

Scenario: Cancel add property under Finace Details Section
	Given I'm already on the Finance Details Section
	When  I click cancel button on Finance Details Section
	Then  popup an confirmation dialog

Scenario: Go back to Property Details Section
	Given I'm already on the Finance Details Section
	When  I click previous button on the Finace Details Section
	Then  I go back to the Property Details Section

Scenario: Add tenant details and save all information
	Given I'm already on the Tenant Details Section
	When  I enter all the tenant details 
		And  click save button 
	Then  new property is added successfully and I'm navigated to the Property Owner Page

Scenario: Cancel add property under Tenant Details Section
	Given I'm already on the Tenant Details Section
	When  I click cancel button on the Tenant Details Section
	Then  popup an confirmation dialog

Scenario: Go back to Finace Details Section
	Given I'm already on the Tenant Details Section
	When  I click previous button on the Tenant Details Section
	Then  I go back to the Finace Details Section


Scenario: Search the new property user added under Properties Page
	Given I have added a new property
	And I search this property under Properties Page 
	Then the search result for this property is correct


Scenario: Validate property details of search result under Properties Page
	Given I have added a new property
	And I search this property under Properties Page 
	When I click the first searching result 
	Then The property details information is the same as I added