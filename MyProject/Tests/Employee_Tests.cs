using MyProject.Pages;
using MyProject.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace MyProject.Tests
{
    


    public class Employee_Tests : CommonDriver
    {

        // page objects initialization
        HomePage homePageObj = new HomePage();
        EmployeePage employeePageObj = new EmployeePage();


        public void createEmployee()
        {
            homePageObj.GoToEmployeePage(driver);
            employeePageObj.CreateEmployee(driver);
        }

        
        public void EditEmployee()
        {
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.EditEmployee(driver);
        }

        
        public void deleteEmployee()
        {
            EmployeePage employeePageObj = new EmployeePage();
            employeePageObj.DeleteEmployee(driver);
        }

        
        public void ClosingSteps()
        {
            driver.Quit();
        }

    }
}

