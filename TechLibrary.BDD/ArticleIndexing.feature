Feature: ArticleIndexing
	In order to for users to find Articles 
	As a Content Editor
	I want to be able to assign indexes to Article Definitions

@mytag
Scenario: Add index to exiting Article Definition
	Given I have created an Article Definition
	And I have added an Index to the Article Definition
	Then the Article Definition should have the Index
