using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace SeleniumTestsOnlineShop
{
    public class ProductManagementTests
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
            IWebElement ProductManagerBtn = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[4]/ul/li[2]/a"));

            AdminDropdown.Click();
            ProductManagerBtn.Click();
        }

        [Test, Order(1)]
        public void EditButtonDisplaysProperly()
        {
            string expected = "Update Product";
            IWebElement EditBtn = driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[2]/td[4]/a[1]"));
            EditBtn.Click();

            string Backbtn = driver.FindElement(By.XPath("/html/body/div/main/div/form/div/div[5]/button")).Text;
            Assert.AreEqual(expected, Backbtn);
        }
        [Test, Order(2)]
        public void UpdateCreateButtonDisplaysProperly()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/Admin/Product");
            string expected = "https://localhost:5001/Admin/Product";
            IWebElement DeleteBtn = driver.FindElement(By.XPath("/html/body/div/main/table/tbody/tr[2]/td[4]/a[2]"));
            DeleteBtn.Click();

            IWebElement BackBtn = driver.FindElement(By.XPath("/html/body/div/main/form/div/div/a"));
            BackBtn.Click();

            Assert.AreEqual(expected, driver.Url);
        }




        [OneTimeTearDown]
        public void End()
        {
            //driver.Close();
        }
    }
}