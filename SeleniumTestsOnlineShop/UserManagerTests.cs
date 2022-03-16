using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace SeleniumTestsOnlineShop
{
    public class UserManagerTests
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
            IWebElement UserManagerBtn = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/ul/li[1]/a"));

            AdminDropdown.Click();
            UserManagerBtn.Click();

        }

        [Test, Order(1)]
        public void DeleteUserPass()
        {
            try
            {
                IWebElement ManagerDeleteBtn = driver.FindElement(By.XPath("" +
                "/html/body/div/main/table/tbody/tr[2]/td[6]/a"));

                if (ManagerDeleteBtn == null)
                {
                    Assert.Pass("Register a new User");
                }

                if (ManagerDeleteBtn != null)
                {
                    ManagerDeleteBtn.Click();
                    try
                    {
                        IWebElement ManagerDeleteBtnFind = driver.FindElement(By.XPath("" +
                        "/html/body/div/main/table/tbody/tr[2]/td[6]/a"));

                    }
                    catch (Exception ex)
                    {
                        Assert.Pass("Deleted User");
                    }

                    Assert.Fail("Failed to Delete User");
                }

            }
            catch (Exception ex)
            {
                Assert.Pass("Register A new User");
            }
        }

        
        

        [OneTimeTearDown]
        public void End()
        {
            driver.Close();
        }
    }
}