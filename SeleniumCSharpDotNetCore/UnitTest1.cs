using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumCSharpDotNetCore.Pages;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Threading;

namespace SeleniumCSharpDotNetCore
{
    public class Tests : DriverHelper
    {
        public static IConfigurationRoot _configuration;

        [SetUp]
        public void Setup()
        {
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);
            
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Print connection string to demonstrate configuration object is populated
            Console.WriteLine(_configuration.GetSection("Features"));
            Console.WriteLine(_configuration.GetSection("Features").GetSection("HeadlessFeature").Value);

            if (bool.Parse(_configuration.GetSection("Features").GetSection("HeadlessFeature").Value))
            {
                var option = new ChromeOptions();
                option.AddArgument("--headless");
                Driver = new ChromeDriver(option);
            }
            else
            {
                Driver = new ChromeDriver();
            }
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
        [Test]
        public void LoginTest()
        {
            Driver.Navigate().GoToUrl("http://eaapp.somee.com/");
            var loginPage = new LoginPage(Driver);
            loginPage.Login("Admin", "password");
            var homePage = new HomePage(Driver);
            homePage.GetUserLogOffLink().Enabled.Should().BeTrue();
            homePage.GetEmployeeDetailsLinkOnHomePage().Enabled.Should().BeTrue();
        }

        [TearDown]
        public void TearDown()
        {
            Thread.Sleep(3000);
            Driver.Quit();
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {

            // Build configuration
            _configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetParent(AppContext.BaseDirectory).FullName)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton<IConfigurationRoot>(_configuration);
        }
    }
}
