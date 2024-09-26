using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

internal class Program
{
    private static void Main(string[] args)
    {
        //1. Open Chrome
        IWebDriver driver = new ChromeDriver();

        //2. Open Turn Up portal
        driver.Navigate().GoToUrl("http://horse.industryconnect.io/");
        driver.Manage().Window.Maximize();

        //3. Enter Username & Password
        driver.FindElement(By.Name("UserName")).SendKeys("hari");
        //username.SendKeys("hari");

        driver.FindElement(By.Id("Password")).SendKeys("123123");
        //password.SendKeys("123123");

        //4. Click on log in btn
        driver.FindElement(By.CssSelector(".btn")).Click();
        //*[@id="loginForm"]/form/div[3]/input[1]
        //logInBtn.Click();

        //Check if user logged in successfully
        IWebElement hellohari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        if (hellohari.Text.Contains("hari"))
        {
            Console.WriteLine("User logged in successfully. Test Passed!");
        }
        else 
        {     
            Console.WriteLine("User NOT logged in successfully. Test Failed!");
        }

        driver.Close();
    }
}