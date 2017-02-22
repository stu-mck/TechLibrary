Feature: ArticleAuthoring
	In order to make content available to subscribers
	As a content editor
	I want to create and configure articles

@mytag
Scenario: Create a new ArticleDefinition
	Given I have created a new ArticleDefinition
	When I press the save article button
	Then the Article should be saved

@finding
Scenario: Retrieve an ArticleDefinition
	Given I have created a new Article
	When I press the save article button
	Then the Article should be saved
	When I enter the entityId of the saved ArticleDefinition
	Then the ArticleDefinition should be returned

