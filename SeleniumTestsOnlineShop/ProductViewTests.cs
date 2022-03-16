using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace SeleniumTestsOnlineShop
{
    public class ProductViewTests
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
        }

        [Test, Order(1)]
        public void BrowseDirectsToRightPage()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/");
            IWebElement BrowseBtn = driver.FindElement(By.XPath("/html/body/header/nav/" +
                "div/div/ul/li[1]/a"));
            BrowseBtn.Click();

            var Expected = "https://localhost:5001/";

            Assert.AreEqual(Expected, driver.Url);


        }

        [Test, Order(2)]
        public void CardValuesNotRealVariables()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/");
            IWebElement Desc = driver.FindElement(By.XPath("/html/body/div/main/div/" +
                "div[1]/div/div/p[1]"));
            IWebElement Price = driver.FindElement(By.XPath("/html/body/div/main/div/" +
                "div[1]/div/div/p[2]"));

            if (Desc.Text == "product.Description" || Price.Text == "product.Price")
            {
                Assert.Fail();
            }

        }

        [Test, Order(3)]
        public void ItemAddedToBasket()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/");
            IWebElement Addbasket = driver.FindElement(By.XPath("" +
                "/html/body/div/main/div/div[1]/div/div/a"));
            string selected = driver.FindElement(By.XPath("/html" +
                "/body/div/main/div/div[1]/div/div/p[1]")).Text;

            Addbasket.Click();

            string basketTitle = driver.FindElement(By.XPath("/html/" +
                "body/div/main/table/tbody/tr/td[2]")).Text;

            var itemadded = false;

            if (selected == basketTitle)
            {
                itemadded = true;
            }

            Assert.IsTrue(itemadded);
        }
        

        [OneTimeTearDown]
        public void End()
        {
            driver.Close();
        }
    }
}