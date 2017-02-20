Feature: FindingArticles
	In order to edit an article
	As a content editor
	I want to find an existing article by entering search terms

@mytag
Scenario: Find articles about Ford Falcon XBs
	Given I have entered "Ford" into the Manufacturer field
	And I have entered "Falcon" into the ModelFamily field
	And I have entered "XB" into the Series field
	When I press search
	Then the result should be a list of Articles displayed on the screen
