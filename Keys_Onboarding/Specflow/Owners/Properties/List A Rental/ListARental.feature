Feature: ListARental

Background: 
	Given I have logged into the application
		And I'm already on the My Properties Page
		And I'm already on the list rental property page

Scenario: Search the rental property after listing
	Given I already listed a rental property
	And I already under the properties for rent page
	Then I can search this rental property successfully under properties for rent page

Scenario: Add rental proeprty information and save, pop up a confirmation dialog 
	When I enter all the rental property information
		And I click save button
	Then pop up a save confirmation dialog

Scenario: Deal with confirmation dialog and confirm to list
	Given I already entered all the rental proerty information
		And I already click save 
	When I click ok button in the confirmation dialog
	Then  I'm navigated to the rental listings&applications page

Scenario: Deal with confirmation dialog and cancel to list
	Given I already entered all the rental proerty information
		And I already click save 
	When I click cancel button in the confirmation dialog
	Then  I stay at list rental property page

Scenario: Cancel list rental property and pop up a confirmation dialog
	When I click cancel button
	Then pop up a cancel confirmation dialog

Scenario: Deal with confirmation dialog and confirm to cancel
	Given I already clicked the cancel button
	When I click the yes button
	Then I'm navigated to my properties page

Scenario: Deal with confirmation dialog and quit to cancel
	Given I already clicked the cancel button
	When I click the no button
	Then I stay at list rental property page

