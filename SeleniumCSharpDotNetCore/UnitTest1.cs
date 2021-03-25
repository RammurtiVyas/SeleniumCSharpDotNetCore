using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumCSharpDotNetCore
{
    public class Tests : DriverHelper
    {
        
        [SetUp]
        public void Setup()
        {
            var option = new ChromeOptions();
            option.AddArgument("--headless");
            Driver = new ChromeDriver(option);
            Driver.Navigate().GoToUrl("https://demo.aspnetawesome.com/");
            Driver.FindElement(By.Id("Meal")).SendKeys("Tomato");
            Driver.FindElement(By.XPath("//input[@name='ChildMeal1']/following-sibling::div[text()='Celery']")).Click();
            CustomControl custom = new CustomControl(Driver);
            custom.ComboBox("AllMealsCombo", "Mango");
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            Driver.Quit();
        }
    }
}
