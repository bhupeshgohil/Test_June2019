using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;

namespace BBCWebsiteTest.Pages
{
    class WeatherPage : Base
    {
        #region Private Fields

        private readonly string _url = @"https://www.bbc.com";

        [FindsBy(How = How.Id, Using = "ls-c-search__input-label")]
        private IWebElement CitySearchBox;

        [FindsBy(How = How.XPath, Using = "//li[@class='orb-nav-weather']/a[contains(text(),'Weather')]")]
        private IWebElement MenuWeather;

        [FindsBy(How = How.ClassName, Using = "ls-c-search__submit")]
        private IWebElement btnSubmit;

        #endregion Private Fields

        #region Public Constructors
        public WeatherPage()
        {
            PageFactory.InitElements(Driver, this);
        }
        #endregion Public Constructors

       

        public void ClickOnMenuWeather()
        {
            MenuWeather.Click();
        }

        public void EnterTextCity(string SearchCity)
        {
            ClearSearchCity();
            CitySearchBox.SendKeys(SearchCity);
        }

        public void ClickOnSearchCity()
        {
            btnSubmit.Click();
        }
        public void VerifyWeatherPage(string expectedPageTitle)
        {
            Assert.AreEqual(Driver.Title, expectedPageTitle, "Page title is not matching.");
            
        }
        public void VerifyCityWeatherPage(string expectedlocation, string expectedCityPageTitle)
        {
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("wr-forecast")));
            Assert.AreEqual(Driver.Title, expectedCityPageTitle, "Page title is not matching.");
        }

        #region Private Methods

        private void ClearSearchCity(string SearchCity = "")
        {
            CitySearchBox.Clear();
        }

        #endregion Private Methods

        
    }
}
