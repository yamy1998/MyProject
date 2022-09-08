using coding1.Pages;
using coding1.Utilities;
using NUnit.Framework;

namespace coding1.Tests
{
    [TestFixture]
    [Parallelizable]


    public class Employee_Tests : CommonDriver
    {

        // page objects initialization
        HomePage homePageObj = new HomePage();
        EmployeePage employeePageObj = new EmployeePage();


        [Test, Order(1)]
        public void createEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.CreateEmployee(driver);
        }

        [Test, Order(2)]
        public void EditEmployee()
        {
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.EditEmployee(driver);
        }

        [Test, Order(3)]
        public void deleteEmployee()
        {
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.DeleteEmployee(driver);
        }

        [TearDown]
        public void ClosingSteps()
        {
            driver.Quit();
        }

    }
}

