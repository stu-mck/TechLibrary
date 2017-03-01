Feature: FindingArticles
	In order to edit an article
	As a content editor
	I want to find an existing article by entering search terms

@mytag
Scenario: Find articles about Ford Falcon XBs
	Given I have created an ArticleDefinition with an index for a Manufacturer
	And I have added an ArticleIndex for XB
	When I search by the 2 indexes
	Then the ArticleDefinition should be retrieved
