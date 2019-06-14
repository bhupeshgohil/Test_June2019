@Weather_Feature
Feature: WeatherPage
@Search_Current_Weather
Scenario Outline:  Search current weather of Bristol
	Given the user is navigated to the (BBC) home page
	And   the user click on the Weather link from menu of the Home page
	And   the user is navigated to the Weather page with page title <expectedpagetitle>
	And   the user enters a city <searchlocation> in search location
	When  the user click on the search button
	Then  the weather details for <expectedlocation> should be displayed along with page title <expectedCityPageTitle>
	
Examples:
| searchlocation   | expectedlocation | expectedpagetitle | expectedCityPageTitle |
| Bristol, Bristol | BRISTOL          | BBC Weather       | Bristol - BBC Weather |
