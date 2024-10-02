using IC_TurnUpWeb.Utilities;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_TurnUpWeb.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            //1.Navigate to Time and Material Page
            //1a. Click Administraton
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            Wait.WaitToBeClickable(driver,"Xpath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 10)

            //1b. Click Time and Material
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
        }
    }
}
