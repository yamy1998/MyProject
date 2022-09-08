using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyProject.Pages
{
    public class LoginPage
    {
        public void loginSteps(IWebDriver driver)
        {
            driver.Manage().Window.Maximize();

            // Launch TurnUp portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/Account/Login?ReturnUrl=%2f");
            Thread.Sleep(1000);

            // identify username textbox and enter valid username
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys("hari");

            // identify password textbox and enter valid password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("123123");

            // identify login button and click on it
            IWebElement loginButton = driver.FindElement(By.XPath("//*[@id=\'loginForm\']/form/div[3]/input[1]"));
            loginButton.Click();
        }
    }
}

