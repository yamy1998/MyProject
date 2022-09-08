using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MyProject.Pages
{
    public class EmployeePage
    {
        public void CreateEmployee(IWebDriver driver)
        {
            // click on CREATE button
            IWebElement createButton1 = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createButton1.Click();

            // input Name
            IWebElement nameTextbox = driver.FindElement(By.XPath("//*[@id=\"Name\"]"));
            nameTextbox.SendKeys("JamesBond");

            // input Username
            IWebElement usernameTextbox = driver.FindElement(By.Id("Username"));
            usernameTextbox.SendKeys("JamesBond007");

            // input Contact details
            IWebElement contactTextbox = driver.FindElement(By.XPath("//*[@id=\"ContactDisplay\"]"));
            contactTextbox.SendKeys("0211111111");

            // input Password
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys("Abc123123");

            // input RetypePassword
            IWebElement retypepasswordTextbox = driver.FindElement(By.Id("RetypePassword"));
            retypepasswordTextbox.SendKeys("Abc123123");

            // click on Save button
            IWebElement saveButton1 = driver.FindElement(By.Id("SaveButton"));
            saveButton1.Click();

            // check if the new employee is created and present in the table
            IWebElement gotolastpageButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]/span"));
            gotolastpageButton.Click();

            IWebElement newName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newUsername = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));

            Assert.That(newName.Text == "JamesBond", "Actual name and expected name do not match.");
            Assert.That(newUsername.Text == "JamesBond007", "Actual username and expected username do not match.");
        }


        public void EditEmployee(IWebDriver driver)
        {
            Thread.Sleep(1000);
            // go to last page
            IWebElement goTolastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goTolastpageButton.Click();
            Thread.Sleep(2000);

            IWebElement findEmployeeCreated = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEmployeeCreated.Text == "JamesBond")
            {
                // if found, click on the edit button
                IWebElement editButton1 = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[1]"));
                editButton1.Click();
                Thread.Sleep(1000);
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record not edited.");
            }

            // click on name textbox, clear and update the name
            IWebElement nameTextbox1 = driver.FindElement(By.Id("Name"));
            nameTextbox1.Clear();
            nameTextbox1.SendKeys("TomCruise");

            // click on username textbox, clear and update the username
            IWebElement usernameTextbox1 = driver.FindElement(By.Id("Username"));
            usernameTextbox1.Clear();
            usernameTextbox1.SendKeys("TomCruise");

            // click on save button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(1500);

            // go to last page
            IWebElement goTolastpageButton1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goTolastpageButton1.Click();
            Thread.Sleep(2000);

            IWebElement editedName = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedUsername = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));

            Assert.That(editedName.Text == "Tom Cruise", "Actual name and expected name do not match.");
            Assert.That(editedUsername.Text == "TomCruise", "Actual username and expected username do not match.");
        }


        public void DeleteEmployee(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // go to last page where edited record will be
            IWebElement lastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastpageButton.Click();

            // find the edited name
            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEditedRecord.Text == "Tom Cruise")
            {
                // click on the deleted button
                IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[3]/a[2]"));
                deleteButton.Click();
                Thread.Sleep(1500);

                driver.SwitchTo().Alert().Accept();
            }
            else
            {
                Assert.Fail("Edited employee to be deleted hasn't been found. Employee not deleted.");

            }

            // Assert that edited employee has been deleted
            IWebElement Name = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement Username = driver.FindElement(By.XPath("//*[@id=\"usersGrid\"]/div[3]/table/tbody/tr[last()]/td[2]"));

            // assertion
            Assert.That(Name.Text != "Tom Cruise", "Name record hasn't been deleted.");
            Assert.That(Username.Text != "TomCruise", "Username record hasn't been deleted.");

        }
    }
}

