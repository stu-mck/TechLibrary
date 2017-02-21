Feature: ContentAuthoring
	In order to create articles that users can read
	As a content editor
	I want to be able to author content 

@mytag
Scenario: Save Content
	Given I have created a new ContentElement
	And I have entered content into the ContentElement
	When I press save
	Then the ContentElement should be saved

Scenario: Retrieve Content
	Given I have created a new ContentElement
	And I have entered content into the ContentElement
	And I press save
	When I enter the entityId of the saved ContentElement
	Then the ContentElement should be returned
