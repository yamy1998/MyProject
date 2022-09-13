using MyProject.Pages;
using MyProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;

namespace MyProject.StepDefinitions
{
    [Binding]
    public class TMFeatureStepDefinitions : CommonDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [Given(@"I logged into turn up portal successfully")]
        public void GivenILoggedIntoTurnUpPortalSuccessfully()
        {
            driver = new ChromeDriver();
            
            loginPageObj.loginSteps(driver);
        }

        [When(@"I navigate to time and material page")]
        public void WhenINavigateToTimeAndMaterialPage()
        {
            
            homePageObj.GoToTMPage(driver);
        }

        [When(@"I create a new time and material record")]
        public void WhenICreateANewTimeAndMaterialRecord()
        {
            
            tmPageObj.CreateTM(driver);
        }

        [Then(@"The record should be create successfully")]
        public void ThenTheRecordShouldBeCreateSuccessfully()
        {
            
            string newCode = tmPageObj.GetCode(driver);
            string newDescription = tmPageObj.GetDescription(driver);
            string newPrice = tmPageObj.GetPrice(driver);

            Assert.That(newCode == "Aug2022", "Actual code and expected code do not match");
            Assert.That(newDescription == "123", "Actual description and expected description do not match");
            Assert.That(newPrice == "$500.00", "Actual price and expected price do not match");
        }

        [When(@"I update '([^']*)', '([^']*)' and '([^']*)' on an existing time and material record")]
        public void WhenIUpdateAndOnAnExistingTimeAndMaterialRecord(string description, string code, string price)
        {
            tmPageObj.EditTM(driver, description, code, price);
        }

        [Then(@"The record should have the updated '([^']*)', '([^']*)' and '([^']*)'")]
        public void ThenTheRecordShouldHaveTheUpdatedAnd(string description, string code, string price)
        {
            string editedDescription = tmPageObj.GetEditDescription(driver);
            string editedPrice = tmPageObj.GetEditPrice(driver);
            string editedCode = tmPageObj.GetEditCode(driver);

            // Assertion
            Assert.That(editedDescription == description, "Actual Description and expected description do not match.");
            Assert.That(editedCode == code, "Actual Code and expected code do not match.");
            Assert.That(editedPrice == price, "Actual Price and expected price do not match.");
        }

 
     
    }


}

