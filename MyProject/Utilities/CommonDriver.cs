using System;
using MyProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyProject.Utilities
{
    public class CommonDriver
    {
        public IWebDriver driver;

        LoginPage loginPageObj = new LoginPage();

        [SetUp]

        public void LoginActions()
        {
            // Open Chrome Broswer
            driver = new ChromeDriver();

            // Login page object initialization and definition
            loginPageObj.loginSteps(driver);
        }

        [OneTimeSetUp]

        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}
