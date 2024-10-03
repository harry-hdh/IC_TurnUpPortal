using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_TurnUpWeb.Pages
{
    public class TMPage
    {
        public void CreateNewRecord(IWebDriver driver) 
        {
            //1.Click Create
            try 
            {
                driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Fail to find Create btn - {ex.Message}");
            }
            //Thread.Sleep(2000);

            //2. Select Time from dropdown
            Wait.WaitToBeClickable(driver, "Xpath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span", 1);

            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span")).Click();
            //Thread.Sleep(1000);

            //2a. Select time
            Wait.WaitToBeClickable(driver, "Xpath", "//*[@id=\"TypeCode_listbox\"]/li[2]", 1);

            driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")).Click();

            //4.Enter Code
            driver.FindElement(By.Id("Code")).SendKeys("IC_123");

            //5.Enter Description
            driver.FindElement(By.Id("Description")).SendKeys("myTesting1!");

            //6.Enter Price
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys("199");

            //7.Click Save
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 1);

            driver.FindElement(By.Id("SaveButton")).Click();

            //8.Go to the last page
            Wait.WaitToBeClickable(driver, "Xpath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]", 2);

            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();

            //9. Check if record is created or not
            Wait.WaitToBeVisible(driver, "Xpath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]", 1);

            IWebElement recordDescribtion = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            Assert.That(recordDescribtion.Text.Contains("myTesting1!"), "Record failed to create!");

            //if (recordDescribtion.Text.Contains("myTesting1!"))
            //{
            //    Assert.Pass("Record created successfully!");
            //}
            //else
            //{
            //    Assert.Fail("Record failed to create!");
            //}
        }

        public void EditRecord(IWebDriver driver)
        {
            // Go to last page
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
            //1.Find Edit btn and click
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();

            //2. Select dropdown
            Wait.WaitToBeClickable(driver, "Xpath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]", 2);

            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]")).Click();
            //Thread.Sleep(2000);

            //2a. Select material
            Wait.WaitToBeClickable(driver, "Xpath", "//*[@id=\"TypeCode_listbox\"]/li[1]", 1);

            driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[1]")).Click();

            //3.Enter Code
            driver.FindElement(By.Id("Code")).Clear();
            driver.FindElement(By.Id("Code")).SendKeys("IC_123456");

            //5.Enter Description
            driver.FindElement(By.Id("Description")).Clear();
            driver.FindElement(By.Id("Description")).SendKeys("myTesting1!-edited");

            //6.Enter Price
            IWebElement priceTxtBox =  driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTxtBox.Click();
            priceTxtBox.Clear();
            priceTxtBox.Click();
            priceTxtBox.SendKeys("100");

            //7.Click Save
            driver.FindElement(By.Id("SaveButton")).Click();


            //8.Go to the last page
            Wait.WaitToBeClickable(driver, "Xpath", "//*[@id=\"tmsGrid\"]/div[4]/a[4]", 1);

            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();


            //9. Check edited record
            Wait.WaitToBeVisible(driver, "Xpath", "//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]", 1);

            IWebElement descRecordEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            Assert.That(descRecordEdited.Text.Contains("myTesting1!-edited"), "Record failed to create!");

        }

        public void DeleteRecord(IWebDriver driver)
        {
            //1.Find Delete btn and click
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[3]/td[last()]/a[2]")).Click();
            //Thread.Sleep(1000);
            //2. Confirm delete
            Wait.WaitAlertVisible(driver, 1);

            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}
