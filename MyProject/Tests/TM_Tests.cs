using MyProject.Pages;
using MyProject.Utilities;
using NUnit.Framework;
using System.ComponentModel;

namespace MyProject.Tests
{
    [TestFixture]
    [Parallelizable]

    public class TM_Tests : CommonDriver
    {

        HomePage homePageObj = new HomePage();
        TMPage tmPageObj = new TMPage();

        [Test, Order(1)]
        public void CreateTMTest()
        {

            homePageObj.GoToTMPage(driver);

            tmPageObj.CreateTM(driver);

        }

        [Test, Order(2)]
        public void EditTMTest()
        {

            homePageObj.GoToTMPage(driver);

            tmPageObj.EditTM(driver);

        }

        [Test, Order(3)]
        public void DeleteTMTest()
        {

            homePageObj.GoToTMPage(driver);

            tmPageObj.DeleteTM(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();

        }










    }
}

