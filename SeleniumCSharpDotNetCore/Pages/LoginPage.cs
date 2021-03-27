using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumCSharpDotNetCore.Pages
{
    public class LoginPage
    {
        IWebDriver _driver;
        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
            _driver.Navigate().GoToUrl("http://eaapp.somee.com/Account/Login");
        }

        private IWebElement _userName => _driver.FindElement(By.Id("UserName"));
        private IWebElement _password => _driver.FindElement(By.Id("Password"));
        private IWebElement logInButton => _driver.FindElement(By.XPath("/html/body/div[2]/div/div[2]/section/form/div[4]/div/input"));
        //private IWebElement logInButton => _driver.FindElement(By.CssSelector(".btn-default"));

        public void Login(string userName, string password)
        {
            _userName.SendKeys(userName);
            _password.SendKeys(password);
            logInButton.Click();
            _driver.Navigate().GoToUrl("http://eaapp.somee.com");
        }
    }
}
