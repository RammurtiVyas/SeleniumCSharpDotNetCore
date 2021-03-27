using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpDotNetCore.Pages
{
    public class HomePage
    {
        IWebDriver _driver;
        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement lnkLogoff => _driver.FindElement(By.PartialLinkText("Log off"));
        private IWebElement lnkEmployeeDetails => _driver.FindElement(By.LinkText("Employee Details"));

        public IWebElement GetUserLogOffLink()
        {
            Console.WriteLine(lnkLogoff.Text);
            return lnkLogoff;
        }
        public IWebElement GetEmployeeDetailsLinkOnHomePage()
        {
            Console.WriteLine(lnkEmployeeDetails.Text);
            return lnkEmployeeDetails;
        }
    }
}
