Feature: Mobile Navigation
	Check the navigation menu opens/closes

Scenario: Mobile Navigation Hidden on Load
	Given I am on the mobile bill page
	Then the navigation bar should be hidden
	
Scenario: Mobile Navigation Opens
	Given I am on the mobile bill page
	When I click the navigation trigger
	Then the navigation bar should show
	
Scenario: Mobile Navigation Closes on Burger Click
	Given I am on the mobile bill page
	And I have clicked the navigation trigger
	When I click the navigation trigger
	Then the navigation bar should hide

Scenario: Mobile Navigation Closes on Header Click
	Given I am on the mobile bill page
	And I have clicked the navigation trigger
	When I click the header bar
	Then the navigation bar should hide

Scenario: Mobile Navigation Closes on Main Click
	Given I am on the mobile bill page
	When I click in the main
	Then the navigation bar should hide