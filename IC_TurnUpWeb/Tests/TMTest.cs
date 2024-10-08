﻿using IC_TurnUpWeb.Pages;
using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace IC_TurnUpWeb.Tests
{
    [TestFixture]
    internal class TMTest : ComWebDriver
    {
        TMPage tmPageObj = new TMPage();
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();

        private readonly By tMXPath = By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a");
        private readonly By administrationXpath = By.XPath("/html/body/div[3]/div/div/ul/li[5]/a");

        [SetUp]
        public void SetUpSteps()
        {
            //Open Chrome browser
            driver = new ChromeDriver();
            //Login
            loginPageObj.LoginAction(driver);
            //Navigate to TmPage
            homePageObj.NavigateToPage(driver,  administrationXpath, tMXPath);
        }

        [Test, Order(1)]
        public void CreateTime_Test() 
        {
            tmPageObj.CreateNewRecord(driver);
        }

        [Test, Order(2)]
        public void EditTime_Test() 
        {
            tmPageObj.EditRecord(driver);
        }

        [Test, Order(3)]
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
