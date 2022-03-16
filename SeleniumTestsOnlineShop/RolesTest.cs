using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace SeleniumTestsOnlineShop
{
    public class RolesTest
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
            IWebElement RoleManagerBtn = driver.FindElement(By.XPath("/html/body/header/nav/div/div/ul/li[3]/ul/li[2]/a"));

            AdminDropdown.Click();
            RoleManagerBtn.Click();

        }

        [Test, Order(1)]
        public void RoleDeleted()
        {
                
            try
            {
                //if the item exists click it
                IWebElement RoleDeleteBtn = driver.FindElement(By.XPath("" +
                    "/html/body/div/main/table/tbody/tr[4]/td[3]/a"));
                RoleDeleteBtn.Click();
            }
            catch (Exception)
            {
                //if the item does not exist create a new one and delete it
                IWebElement create = driver.FindElement(By.XPath("" +
                    "/html/body/div/main/form/div/input"));
                create.SendKeys("Test");
                create.Submit();
                IWebElement RoleDeleteBtn = driver.FindElement(By.XPath("" +
                    "/html/body/div/main/table/tbody/tr[4]/td[3]/a"));
                RoleDeleteBtn.Click();
            }

            var RoleExists = false;
            try
            {
                //if the delete button is found the role exists
                IWebElement RoleDeleteBtnFind = driver.FindElement(By.XPath("" +
                    "/html/body/div/main/table/tbody/tr[4]/td[3]/a"));
                RoleExists = true;
            }
            catch (Exception)
            {
                    
                    
                   
            }
            //if the role does not exist the test passes
            if(RoleExists == false)
            {
                Assert.Pass("Role deleted");
            }
            //otherwise it fails
            if (RoleExists == true)
            {
                Assert.Fail("Role not deleted");
            }
            



        }

        
        

        [OneTimeTearDown]
        public void End()
        {
            driver.Close();
        }
    }
}