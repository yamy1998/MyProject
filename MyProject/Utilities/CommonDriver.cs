using System;
using coding1.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace coding1.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;

        [SetUp]

        public void LoginActions()
        {
            // Open Chrome Broswer
            driver = new ChromeDriver();

            // Login page object initialization and definition
            LoginPage loginPageObj = new LoginPage();
            loginPageObj.LoginSteps(driver);
        }
    }
}
