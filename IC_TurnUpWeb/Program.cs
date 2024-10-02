using IC_TurnUpWeb.Pages;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

internal class Program
{
    private static void Main(string[] args)
    {
        IWebDriver driver = new ChromeDriver();

        //Implicit wait
        WebDriverWait wait = new WebDriverWait(driver,TimeSpan.FromSeconds(3)); 
        
        //Login
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginAction(driver);
        //Navigate to TmPage
        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTMPage(driver);

        //Check if user logged in successfully
        //IWebElement hellohari = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

        //if (hellohari.Text.Contains("hari"))
        //{
        //    Console.WriteLine("User logged in successfully. Test Passed!");
        //}
        //else
        //{
        //    Console.WriteLine("User NOT logged in successfully. Test Failed!");
        //}

        //A. Creating Time record
        TMPage tmPageObj = new TMPage();
        tmPageObj.CreateNewRecord(driver);

        //Check if Time record is created
        //1. Go back to list
        //driver.FindElement(By.XPath("//*[@id=\"container\"]/div/a")).Click();
        //2. Go to the last page
        //driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
        //Thread.Sleep(2000);

        //3.Check the record
        IWebElement recordDescribtion = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

        if (recordDescribtion.Text.Contains("myTesting1!"))
        {
            Console.WriteLine("Record created successfully!");
        }
        else
        {
            Console.WriteLine("Record failed to create!");
        }

        //B. Edit new record in the Time and Material module
        tmPageObj.EditRecord(driver);

        //Check if record edited successfully
        //1. Go to the last page
        //driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
        //Thread.Sleep(2000);
        //2. Check the description
        IWebElement descRecordEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

        if (descRecordEdited.Text.Contains("myTesting1!-edited"))
        {
            Console.WriteLine("Record modified successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("Record NOT modified. Test Failed!");
        }

        //3. Check the description
        IWebElement priceRecordEdited = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[4]"));

        if (priceRecordEdited.Text.Contains("101"))
        {
            Console.WriteLine("Record modified successfully. Test Passed!");
        }
        else
        {
            Console.WriteLine("Record NOT modified. Test Failed!");
        }

        //B. Delete new record in Time and Material module
        tmPageObj.DeleteRecord(driver);


        driver.Quit();
    }
}