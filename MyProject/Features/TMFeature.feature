Feature: TMFeature

A short summary of the feature

@tag1
Scenario: Create time and material record with valid details
	Given I logged into turn up portal successfully
	When I navigate to time and material page
	And I create a new time and material record
	Then The record should be create successfully
