using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace SeleniumTestsOnlineShop
{
    public class CatagoryTests
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

            IWebElement AdminDropdown = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/a"));
            IWebElement CataManagerBtn = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/ul/li[3]/a"));

            AdminDropdown.Click();
            CataManagerBtn.Click();

        }

        [Test, Order(1)]
        public void DeleteBackButtonTxtEqualsBack()
        {

            string expected = "Back";
            IWebElement DeleteBtn = driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[1]/td[2]/a[2]"));
            DeleteBtn.Click();

            IWebElement BackBtn = driver.FindElement(By.XPath("/html/body/div/main/div/form/a"));

            Assert.AreEqual(expected, BackBtn.Text);
        }

        
        

        [OneTimeTearDown]
        public void End()
        {
            driver.Close();
        }
    }
}