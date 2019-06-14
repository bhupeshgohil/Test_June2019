@Login_Feature
Feature: Login to BBC website feature
@Login_As_Existing_User
Scenario Outline: Login to BBC website using existing user
	Given the user is navigated to the (BBC) home page
	And   the user click on the Sign in link menu of the Home page
	And   the user enters the <EmailAddress> and <Password>		 
	When  the user clicks on the Sign in button
	Then  the user should be logged in and navigated to home page 'BBC - Homepage'

Examples:
		  | EmailAddress        | Password |
		  | bhupesh25@gmail.com | Pass1234 |	