Feature: CreateUser
	In order to create new users
	As a customer care specialist
	I want to create a new user profile

@SmokeTest
Scenario Outline: Create new user
	Given I populate the API call with the first name 'Ionut', last name 'Popa' and the job 'Tester'
	When I make the API call to create a new user
	Then the call is successful, status code is '201'
	And the user profile is created
