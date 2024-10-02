using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_TurnUpWeb.Pages
{
    public class LoginPage
    {
        public void LoginAction(IWebDriver driver)
        {
            //2. Open Turn Up portal
            driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
            driver.Manage().Window.Maximize();
            Thread.Sleep(1000);

            //3. Enter Username & Password
            driver.FindElement(By.Name("UserName")).SendKeys("hari");
            //username.SendKeys("hari");

            driver.FindElement(By.Id("Password")).SendKeys("123123");
            //password.SendKeys("123123");

            //4. Click on log in btn
            driver.FindElement(By.CssSelector(".btn")).Click();
            //*[@id="loginForm"]/form/div[3]/input[1]
            //logInBtn.Click();
            Thread.Sleep(2000);
        }
    }
}
