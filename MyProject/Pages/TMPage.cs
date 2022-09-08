using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace coding1.Pages
{
    public class TMPage
    {
        public void CreateTM(IWebDriver driver)
        {
            // Click on CreateNew button
            IWebElement createButton = driver.FindElement(By.XPath("//*[@id=\'container\']/p/a"));
            createButton.Click();

            // Select "Time" option from Typecode dropdown
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[1]/div/span[1]/span/span[2]/span"));
            typeCodeDropdown.Click();
            IWebElement timeOption = driver.FindElement(By.XPath("//*[@id='TypeCode_listbox']/li[2]"));
            timeOption.Click();

            // Input Code
            IWebElement CodeTextbox = driver.FindElement(By.Id("Code"));
            CodeTextbox.SendKeys("Aug2022");

            // Input Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("123");

            // Input Price
            IWebElement priceInputTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span"));
            priceInputTag.Click();

            IWebElement priceTextbox = driver.FindElement(By.Id("Price"));
            priceTextbox.Clear();
            priceTextbox.SendKeys("500");

            // Click on Save Button
            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();
            Thread.Sleep(4000);

            // Clicke if the record created is present in the table
            IWebElement gotolastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            gotolastpageButton.Click();

            IWebElement newCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement newDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement newPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            Assert.That(newCode.Text == "Aug2022", "Actual code and expected code do not match");
            Assert.That(newDescription.Text == "123", "Actual description and expected description do not match");
            Assert.That(newPrice.Text == "$500.00", "Actual price and expected price do not match");

            //if (newCode.Text == "Aug2022")
            //{
            //    Assert.Pass("Time record created successfully!");
            //}
            //else
            //{
            //    Assert.Fail("New time record hasn't been created.");
            //}

        }


        public void EditTM(IWebDriver driver)
        {
            Thread.Sleep(1500);
            // go to last page
            IWebElement goTolastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goTolastpageButton.Click();
            Thread.Sleep(2000);

            IWebElement findRecordCreated = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findRecordCreated.Text == "Aug2022")
            {
                // if found, click on the Edit Button
                IWebElement editButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
                editButton.Click();
                Thread.Sleep(1500);
            }
            else
            {
                Assert.Fail("Record to be edited hasn't been found. Record not edited.");
            }

            // CLick on "Code" from Textbox, clear and update the code
            IWebElement codeTextBox1 = driver.FindElement(By.Id("Code"));
            codeTextBox1.Clear();
            codeTextBox1.SendKeys("Edited");

            // click on "description" Textbox, clear and update the description
            IWebElement descriptionTextBox1 = driver.FindElement(By.Id("Description"));
            descriptionTextBox1.Clear();
            descriptionTextBox1.SendKeys("Edited");

            // click on "Price" textbox, clear and update the price
            IWebElement priceTag = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span"));
            priceTag.Click();

            IWebElement priceTextbox1 = driver.FindElement(By.Id("Price"));
            priceTextbox1.Clear();

            priceTag.Click();
            priceTextbox1.SendKeys("150.00");

            // click on "save" button
            IWebElement saveButton1 = driver.FindElement(By.Id("SaveButton"));
            saveButton1.Click();
            Thread.Sleep(1500);

            // go to last page to check
            IWebElement goTolastpageButton1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goTolastpageButton1.Click();

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement editedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement editedPrice = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(editedCode.Text == "Edited", "Actual Code and expected code do not match.");
            Assert.That(editedDescription.Text == "Edited", "Actual Description and expected description do not match.");
            Assert.That(editedPrice.Text == "$150.00", "Actual Price and expected price do not match.");

        }


        public void DeleteTM(IWebDriver driver)
        {
            Thread.Sleep(2000);
            // go to last page where edited record will be
            IWebElement lastpageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            lastpageButton.Click();

            // find the edited record
            IWebElement findEditedRecord = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));

            if (findEditedRecord.Text == "Edited")
            {
                // click on the delete button
                IWebElement deletButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
                deletButton.Click();
                Thread.Sleep(2000);

                driver.SwitchTo().Alert().Accept();

            }
            else
            {
                Assert.Fail("Record to be deleted hasn't been found. Record not deleted.");
            }

            // Assert that time record has been deleted
            IWebElement goTolastpageButton1 = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goTolastpageButton1.Click();
            Thread.Sleep(1200);

            IWebElement Code = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement Description = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));
            IWebElement Price = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

            // Assertion
            Assert.That(Code.Text != "Edited", "Code record hasn't been deleted.");
            Assert.That(Description.Text != "Edited", "Description record hasn't been deleted.");
            Assert.That(Price.Text != "$150.00", "Price record hasn't been deleted.");

        }
    }
}

