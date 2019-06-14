using BBCWebsiteTest.Pages;
using System;
using TechTalk.SpecFlow;

namespace BBCWebsiteTest.Steps
{
    [Binding]
    public class WeatherPageSteps : Base
    {
        #region Private Fields

        private WeatherPage weatherPage;

        private WeatherPageSteps()
        {
            weatherPage = new WeatherPage();
        }

        #endregion Private Fields

        #region Public Methods

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            //StartBrowser(Constants.ChromeBrowser);
            //StartBrowser(Constants.IEBrowser);
            StartBrowser(Constants.FFBrowser);
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            CloseDriver();
        }

        [Given(@"the user click on the Weather link from menu of the Home page")]
        public void GivenTheUserClickOnTheWeatherLinkFromMenuOfTheHomePage()
        {
            weatherPage.ClickOnMenuWeather();
        }

        [Given(@"the user is navigated to the Weather page with page title (.*)")]
        public void GivenTheUserIsNavigatedToTheWeatherPageWithPageTitleBBCWeather(string expectedPageTitle)
        {
            weatherPage.VerifyWeatherPage(expectedPageTitle);
        }

        [Given(@"the user enters a city (.*) in search location")]
        public void GivenTheUserEntersACityBristolBristolInSearchLocation(string SearchCity)
        {            
            weatherPage.EnterTextCity(SearchCity);
        }

        [When(@"the user click on the search button")]
        public void WhenTheUserClickOnTheSearchButton()
        {
            weatherPage.ClickOnSearchCity();
        }

        [Then(@"the weather details for (.*) should be displayed along with page title (.*)")]
        public void ThenTheWeatherDetailsForBristolBristolShouldBeDisplayedAlongWithPageTitleBBCWeather(string expectedlocation, string expectedCityPageTitle)
        {
            weatherPage.VerifyCityWeatherPage(expectedlocation, expectedCityPageTitle);
        }

        #endregion Public Methods
    }
}
