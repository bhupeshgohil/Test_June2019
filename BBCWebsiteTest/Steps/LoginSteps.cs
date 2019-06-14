
using BBCWebsiteTest.Pages;

using System;
using System.Data;
using TechTalk.SpecFlow;

namespace BBCWebsiteTest.Steps
{
    [Binding]
    public class LoginSteps : Base
    {
        #region Private Fields

        private LoginPage loginPage;      

        private LoginSteps() 
        {
            loginPage = new LoginPage();
        }

    #endregion Private Fields

        #region Public Methods

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            StartBrowser(Constants.ChromeBrowser);           
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            CloseDriver();
        }

        [Given(@"the user is navigated to the \(BBC\) home page")]
        public void GivenTheUserIsNavigatedToTheBBCHomePage()
        {
            loginPage = new LoginPage();
            loginPage.Navigate();
        }

        [Given(@"the user click on the Sign in menu of the Home page")]
        public void GivenTheUserClickOnTheManuOfThePage()
        {
            loginPage.ClickOnSignInMenu();
        }

        [Given(@"the user enters the (.*) and (.*)")]
        public void GivenTheUserEntersTheBhupeshGmail_ComAndPass(string emailAddress, string password)
        {
            loginPage.Login(emailAddress, password);
        }

        [When(@"the user clicks on the Sign in button")]
        public void WhenTheUserClicksOnTheSignInButton()
        {
            loginPage.ClickSubmitButton();
        }

        [Given(@"the user click on the Sign in link menu of the Home page")]
        public void GivenTheUserClickOnTheSignInLinkMenuOfTheHomePage()
        {
            loginPage.ClickOnSignInMenu();
        }
 
        [Then(@"the user should be logged in and navigated to home page '(.*)'")]
        public void ThenTheUserShouldBeLoggedInAndNavigatedToHomePage(string expectedPageTitle)
        {
            loginPage.VerifyTitlePage(expectedPageTitle); 
        }

        #endregion Public Methods
    }
}
