using IC_TurnUpWeb.Pages;
using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace IC_TurnUpWeb.Tests
{
    [TestFixture]
    class EmployeeTest : ComWebDriver
    {
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();
        EmployeesPage employeesPageObj = new EmployeesPage();

        private readonly By administrationXpath = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a");
        private readonly By employeesXPath = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[2]/a");

        [SetUp]
        public void SetUpSteps()
        {
            //Open Chrome browser
            driver = new ChromeDriver();
            //Login
            loginPageObj.LoginAction(driver);
            //Navigate to TmPage
            homePageObj.NavigateToPage(driver, administrationXpath, employeesXPath);
        }

        [Test]
        public void CreateEmployee_Test()
        {
            employeesPageObj.CreateNewEmploye(driver);
        }

        [Test]
        public void EditEmployee_Test()
        {
            employeesPageObj.EditEmployee(driver);
        }

        [Test]
        public void EditEmployeeContact_Test()
        {
            employeesPageObj.EditEmployeeContact(driver);
        }

        [Test]
        public void DeleteEmployee_Test()
        {
            employeesPageObj.DeleteEmployee(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }

    }
}
