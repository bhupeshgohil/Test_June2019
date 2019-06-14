using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBCWebsiteTest
{
    public class Base
    {
        private static IWebDriver driver;
        //SetBrowserCapability method wriiten to remove chrome browser alert on my machine
        public static ChromeOptions SetBrowserCapability()
        {
            var options = new ChromeOptions();
            options.AddAdditionalCapability("useAutomationExtension", false);
            return options;
        }
        public static IWebDriver Driver
        {
            get
            {
                if (driver == null)
                    throw new NullReferenceException("The WebDriver browser instance was not initialized. You should first call the method InitBrowser.");
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static void StartBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (driver == null)
                    {
                        driver = new FirefoxDriver();                        
                    }
                    break;
                case "IE":
                    if (driver == null)
                    {
                        driver = new InternetExplorerDriver();
                    }
                    break;

                case "Chrome":
                    if (driver == null)
                    {
                        driver = new ChromeDriver(SetBrowserCapability());
                    }
                    break;                
            }
            driver.Manage().Window.Maximize();
        }

        public static void CloseDriver()
        {
            Driver.Close();
            Driver.Quit();
        }
    }
}
