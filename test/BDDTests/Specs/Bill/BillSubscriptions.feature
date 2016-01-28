Feature: Bill Subscriptions
	Make sure that the total, count and items are correct for the subscriptions

Scenario: Verify Bill Subscriptions and Values
	Given that I visit the bill page
	When I click the subscription header
	Then the subscription details should be shown
	And the subscription total in the header should be hidden
	And there should be 3 subscription items
	And a total value in the subscription details of £71.40
		
Scenario: Verify Bill Subscriptions and Values on mobile device
	Given I am on the mobile bill page
	When I click the subscription header
	Then the subscription details should be shown
	And the subscription total in the header should be hidden
	And there should be 3 subscription items
	And a total value in the subscription details of £71.40