using OpenQA.Selenium;
using System;
using System.Threading;

namespace SeleniumCSharpDotNetCore
{
    public class CustomControl : DriverHelper
    {
        IWebDriver _driver;
        public CustomControl(IWebDriver driver)
        {
            _driver = driver;
        }
        public void ComboBox(string name, string value)
        {
            
            var combo = _driver.FindElement(By.XPath($"//*[@id='{name}-awed']"));
            combo.Clear();
            combo.SendKeys(value);
            combo.Click();
            combo.SendKeys(Keys.Enter);
            Thread.Sleep(5000);
        }
    }
}