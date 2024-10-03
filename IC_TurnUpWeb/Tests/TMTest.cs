using IC_TurnUpWeb.Pages;
using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;

namespace IC_TurnUpWeb.Tests
{
    [TestFixture]
    internal class TMTest : ComWebDriver
    {
        TMPage tmPageObj = new TMPage();
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();

        [SetUp]
        public void SetUpSteps()
        {
            //Open Chrome browser
            driver = new ChromeDriver();
            //Login
            loginPageObj.LoginAction(driver);
            //Navigate to TmPage
            homePageObj.NavigateToTMPage(driver);
        }

        [Test]
        public void CreateTime_Test() 
        {
            tmPageObj.CreateNewRecord(driver);
        }

        [Test]
        public void EditTime_Test() 
        {
            tmPageObj.EditRecord(driver);
        }

        [Test]
        public void DeleteTime_Test()
        {
            tmPageObj.DeleteRecord(driver);
        }

        [TearDown]
        public void CloseTestRun()
        {
            driver.Quit();
        }
    }
}
