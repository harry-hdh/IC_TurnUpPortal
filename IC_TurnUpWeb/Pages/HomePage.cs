using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;

namespace IC_TurnUpWeb.Pages
{
    public class HomePage
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            //1.Navigate to Time and Material Page
            //1a. Click Administraton
            driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/a")).Click();

            Wait.WaitToBeClickable(driver, "Xpath", "/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a", 1);

            //1b. Click Time and Material
            try
            {
                driver.FindElement(By.XPath("/html/body/div[3]/div/div/ul/li[5]/ul/li[3]/a")).Click();
            }
            catch (Exception ex)
            {
                Assert.Fail($"Fail to find Time & material Option - {ex.Message}");
            }
        }
    }
}
