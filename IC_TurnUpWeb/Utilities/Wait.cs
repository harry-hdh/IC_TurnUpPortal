﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IC_TurnUpWeb.Utilities
{
    public class Wait
    {
        //fluent wait
        private static By GetBy(string locatorType, string locatorValue)
        {
            return locatorType switch
            {
                "Xpath" => By.XPath(locatorValue),
                "Id" => By.Id(locatorValue),
                "CssSelector" => By.CssSelector(locatorValue),
                _ => throw new AggregateException($"{locatorType} Not Supported")
            };
        }

        //Wait for clickable
        public static void WaitToBeClickable(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(GetBy(locatorType,locatorValue)));
        }

        //Wait for visiable
        public static void WaitToBeVisible(IWebDriver driver, string locatorType, string locatorValue, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));

            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(GetBy(locatorType, locatorValue)));

        }

        public static void WaitAlertVisible(IWebDriver driver, int seconds)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(seconds));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.AlertIsPresent());
        }
    }
}
