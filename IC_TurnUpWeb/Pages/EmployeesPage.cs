using IC_TurnUpWeb.Utilities;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V127.Browser;


namespace IC_TurnUpWeb.Pages
{
    public class EmployeesPage
    {
        //locators
        private readonly By createBtnXpath = By.XPath("//*[@id=\"container\"]/p/a");
        private readonly By vehicalTxtBoxXpath = By.XPath("//*[@id=\"UserEditForm\"]/div/div[7]/div/span[1]/span/input");
        private readonly By grpDropDownXpath = By.XPath("//*[@id=\"UserEditForm\"]/div/div[8]/div/div/div[1]");
        private readonly By backLinkXpath = By.XPath("//*[@id=\"container\"]/div/a");
        private readonly By lastPageBtnXpath = By.XPath("//*[@id=\"usersGrid\"]/div[4]/a[4]");
        private readonly By resultXpath = By.XPath("//*[@id=\"usersGrid\"]/div[3]/div[2]/table/tbody/tr[last()]/td[2]");

        private readonly By deleteBtnXpath = By.XPath("//*[@id=\"usersGrid\"]/div[3]/div[2]/table/tbody/tr[last()]/td[3]/a[2]");


        private readonly By nameTxtBoxId = By.Id("Name");
        private readonly By uNameTxtBoxId = By.Id("Username");
        private readonly By pwTxtBoxId = By.Id("Password");
        private readonly By rePWTxtBoxId = By.Id("RetypePassword");
        private readonly By isAdminCheckBoxId = By.Id("IsAdmin");
        private readonly By grpListId = By.Id("groupList_listbox");
        private readonly By saveBtnId = By.Id("SaveButton");

        private readonly By grpIdxCS= By.CssSelector("tr[data-index='10']");


        //Values
        private readonly string nameVal = "harry";
        private readonly string uNameVal = "mytest101";
        private readonly string pwVal = "123QWEasd$";
        private readonly string vehicalVal = "car";





        public void CreateNewEmploye(IWebDriver driver)
        {
            //1.Click Create
            try
            {
                CustomMethods.Click(driver,createBtnXpath);
            }
            catch (Exception ex)
            {
                Assert.Fail($"Fail to find Create btn - {ex.Message}");

            }

            //2.Fill name
            Wait.WaitToBeVisible(driver, nameTxtBoxId, 5);
            CustomMethods.OnlyEnterText(driver, nameTxtBoxId, nameVal);

            //3.Fill username
            CustomMethods.OnlyEnterText(driver, uNameTxtBoxId, uNameVal);

            //4.Fill password
            CustomMethods.OnlyEnterText(driver, pwTxtBoxId, pwVal);

            //5.Fill retype password
            CustomMethods.OnlyEnterText(driver, rePWTxtBoxId, pwVal);

            //6.Tick isadmin box
            CustomMethods.Click(driver, isAdminCheckBoxId);

            //7. Fill Vehical
            CustomMethods.OnlyEnterText(driver, vehicalTxtBoxXpath, vehicalVal);

            //8. Select Group
            CustomMethods.Click(driver, grpDropDownXpath);
            Wait.WaitToBeVisible(driver, grpListId, 5);
            CustomMethods.Click(driver, grpIdxCS);

            //9. Save create
            CustomMethods.Submit(driver, saveBtnId);

            //10. Check if record is created or not
            Thread.Sleep(1000);
            CustomMethods.Click(driver, backLinkXpath);
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 5);
            CustomMethods.Click(driver, lastPageBtnXpath);

            //target Username value
            Wait.WaitToBeVisible(driver, resultXpath, 5);
            IWebElement uNameRecord= driver.FindElement(resultXpath);
            Assert.That(uNameRecord.Text.Contains(uNameVal), "Record failed to create!");

        }

        public void EditEmployee() 
        { 
        
        }

        public void EditEmployeeContact()
        {

        }

        public void DeleteEmployee(IWebDriver driver) 
        {
            // Go to last page
            Wait.WaitToBeClickable(driver, lastPageBtnXpath, 5);
            CustomMethods.Click(driver, lastPageBtnXpath);
            
            //1.Find Delete btn and click
            Wait.WaitToBeClickable(driver, deleteBtnXpath, 5);
            CustomMethods.Click(driver, deleteBtnXpath);

            //2. Confirm delete
            Wait.WaitAlertVisible(driver, 1);
            CustomMethods.AcceptAlert(driver);
        }
    }
}
