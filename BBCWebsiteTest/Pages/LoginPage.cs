using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using System;
using System.Configuration;
using System.Threading;


namespace BBCWebsiteTest.Pages
{
    class LoginPage : Base
    {
        #region Private Fields

        private readonly string _url = @"https://www.bbc.com";

        [FindsBy(How = How.Id, Using = "user-identifier-input")]
        private IWebElement txtEmailAddressField;

        [FindsBy(How = How.Id, Using = "password-input")]
        private IWebElement txtPasswordField;

        [FindsBy(How = How.Id, Using = "idcta-link")]
        private IWebElement menuSignIn;

        [FindsBy(How = How.Id, Using = "submit-button")]
        private IWebElement loginSubmitButton;

        
        #endregion Private Fields

        #region Public Constructors
        public LoginPage()
        {
            PageFactory.InitElements(Driver, this);
        }
        #endregion Public Constructors

        #region Public Properties

        public string Url
        {
            get { return ConfigurationManager.AppSettings["LoginPageUrl"]; }
        }

        #endregion Public Properties

        public void Navigate()
        {
            Driver.Navigate().GoToUrl(Url);
        }

        public void ClickOnSignInMenu()
        {            
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));            
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.Id("idcta-link")));  
            menuSignIn.Click();
        }

        public void EnterEmailAddress(string emailAddress)
        {
            txtEmailAddressField.SendKeys(emailAddress);
        }

        public void EnterPassword(string password)
        {
            txtPasswordField.SendKeys(password);
        }

        public void ClickSubmitButton()
        {
            loginSubmitButton.Click();
        }

        public void Login(string emailAddress , string password)
        {
            txtEmailAddressField.Clear();
            EnterEmailAddress(emailAddress);
            txtPasswordField.Clear();
            EnterPassword(password);            
        }

        public void VerifyTitlePage(string ExpectedPageTitle)
        {         
            var wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.XPath("//span[contains(text(),'Welcome to BBC.com')]")));
            Assert.AreEqual(Driver.Title, ExpectedPageTitle, "Page title is not matching.");            
        }

    }
}
