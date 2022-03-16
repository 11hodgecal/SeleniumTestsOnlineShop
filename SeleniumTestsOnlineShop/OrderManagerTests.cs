using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace SeleniumTestsOnlineShop
{
    public class OrderManagerTests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            //Initialised here
            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://localhost:5001/");
            IWebElement name = driver.FindElement(By.Id("Input_Email"));
            IWebElement Pass = driver.FindElement(By.Id("Input_Password"));
            name.SendKeys("Admin@admin.com");
            Pass.SendKeys("Admin123!");
            Thread.Sleep(1000);
            name.Submit();

            IWebElement AdminDropdown = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/a"));
            IWebElement OrderManagerBtn = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/ul/li[1]/a"));

            AdminDropdown.Click();
            OrderManagerBtn.Click();

        }

        [Test, Order(1)]
        public void EditBackRedirectsCorrectly()
        {
            string expected = "https://localhost:5001/Admin/Order";
            IWebElement deletebutton = driver.FindElement(By.XPath("/html" +
                "/body/div/main/table/tbody/tr/td[10]/a[3]"));
            deletebutton.Click();

            IWebElement BackToListbutton = driver.FindElement(By.XPath("/html" +
                "/body/div/main/div/form/a"));
            BackToListbutton.Click();

            Assert.AreEqual(expected, driver.Url);

        }

        
        

        [OneTimeTearDown]
        public void End()
        {
            driver.Close();
        }
    }
}