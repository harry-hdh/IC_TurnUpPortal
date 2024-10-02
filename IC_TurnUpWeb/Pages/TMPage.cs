using IC_TurnUpWeb.Utilities;
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
            driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a")).Click();
            Thread.Sleep(2000);

            //2. Select Time from dropdown
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span")).Click();
            Thread.Sleep(1000);

            //Select time
            driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]")).Click();

            //4.Enter Code
            driver.FindElement(By.Id("Code")).SendKeys("IC_123");

            //5.Enter Description
            driver.FindElement(By.Id("Description")).SendKeys("myTesting1!");

            //6.Enter Price
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys("199");

            //7.Click Save
            Wait.WaitToBeClickable(driver, "Id", "SaveButton", 5);

            driver.FindElement(By.Id("SaveButton")).Click();
            Thread.Sleep(2000);

            //8.Go to the last page
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
            Thread.Sleep(2000);
        }

        public void EditRecord(IWebDriver driver)
        {
            
            //1.Find Edit btn and click
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]")).Click();
            Thread.Sleep(2000);

            //2. Select dropdown
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span/span[2]")).Click();
            Thread.Sleep(2000);

            //Select material
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
            Thread.Sleep(2000);

            //8.Go to the last page
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
            Thread.Sleep(2000);
        }

        public void DeleteRecord(IWebDriver driver)
        {
            //1.Find Delete btn and click
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[3]/td[last()]/a[2]")).Click();
            Thread.Sleep(1000);
            //2. Confirm delete
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }
    }
}
