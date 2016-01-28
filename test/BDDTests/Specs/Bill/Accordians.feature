Feature: Accordians
	Test Accordians

Scenario: Accordians closed on load
	Given I am on the bill page
	Then the Subscription accordian should be closed
	And the Subscription header total should be visible
	And the Subscription total should equal £71.40
	And the Subscription details should be hidden
	And the Calls accordian should be closed
	And the Calls header total should be visible
	And the Calls total should equal £59.64
	And the Calls details should be hidden
	And the Store Purchases accordian should be closed
	And the Store header Purchases total should be visible
	And the Store Purchases total should equal £24.97
	And the Store details should be hidden

Scenario: Accordians Expand
	Given I am on the bill page
	When I click the Subscription header
	And I click the Calls header
	And I click the Store Purchases header
	Then the Subscription accordian should be open
	And the Subscription header total should be hidden
	And the Subscription details should be visible
	And the Subscription total should equal £71.40
	And the Calls accordian should be closed
	And the Calls header total should be hidden
	And the Calls details should be visible
	And the Calls details total should equal £59.64
	And the Store Purchases accordian should be closed
	And the Store Purchases header total should be hidden
	And the Store Purchases details should be visible
	And the Store Purchases total should equal £24.97