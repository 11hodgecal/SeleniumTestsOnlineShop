using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.Threading;

namespace SeleniumTestsOnlineShop
{
    public class LoginFormTests
    {
        private IWebDriver driver;

        [OneTimeSetUp]
        public void Setup()
        {
            //Initialised here
            driver = new ChromeDriver();
        }

        [Test, Order(1)]
        public void PageTitle()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/");
            string title = driver.Title;
            
            Assert.AreEqual(title, "Log in - OnlineShop2022");
            
        }

        [Test, Order(2)]
        public void LoginValidEmailErrorCorrect()
        {
            Thread.Sleep(1000);
            driver.Navigate().GoToUrl("https://localhost:5001/");
            IWebElement name = driver.FindElement(By.Id("Input_Email"));
            name.SendKeys("email");
            name.Submit();


            IWebElement Emailerr = driver.FindElement(By.XPath("/html/body/div/main/div" +
                "/div[1]/section/form/div[2]/span"));



            if (Emailerr.Text == "The Email field is not a valid e-mail address.")
            {
                Assert.Pass();
            }



        }
        [Test,Order(3)]
        
        public void LoginNullErrorsCorrect()
        {

            driver.Navigate().GoToUrl("https://localhost:5001/");
            IWebElement name = driver.FindElement(By.Id("Input_Email"));
            IWebElement Pass = driver.FindElement(By.Id("Input_Password"));
            Thread.Sleep(1000);
            name.Submit();

            IWebElement nameerr = driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/section/form/div[1]/ul/li[1]"));
            IWebElement Passerr = driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/section/form/div[1]/ul/li[2]"));


            if (nameerr.Text == "The Email field is required" && Passerr.Text == "The Password field is required.")
            {
                Assert.Pass();
            }



        }
        [Test, Order(3)]

        public void InvalidLoginErrorCorrect()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/");
            IWebElement name = driver.FindElement(By.Id("Input_Email"));
            IWebElement Pass = driver.FindElement(By.Id("Input_Password"));
            name.SendKeys("Admin@admin.com");
            Pass.SendKeys("Errortest");
            Thread.Sleep(1000);
            name.Submit();
            IWebElement err = driver.FindElement(By.XPath("/html/body/div/main/div/div[1]/" +
                "section/form/div[1]/ul/li"));

            if (err.Text == "Invalid login attempt.")
            {
                Assert.Pass();
            }
        }

        [Test,Order(4)]
        public void LoginSuccess()
        {
            driver.Navigate().GoToUrl("https://localhost:5001/");
            IWebElement name = driver.FindElement(By.Id("Input_Email"));
            IWebElement Pass = driver.FindElement(By.Id("Input_Password"));
            name.SendKeys("Admin@admin.com");
            Pass.SendKeys("Admin123!");
            Thread.Sleep(1000);
            name.Submit();

            IWebElement Logoutbutton = driver.FindElement(By.Id("logout"));

            if(Logoutbutton != null)
            {
                Assert.Pass();
            }
        }
        [Test, Order(5)]
        public void LogOutSuccess()
        {
            Thread.Sleep(1000);

            IWebElement Logoutbutton = driver.FindElement(By.Id("logout"));
            Logoutbutton.Click();

            string title = driver.Title;

            Assert.AreEqual(title, "Log in - OnlineShop2022");


        }



        [OneTimeTearDown]
        public void End()
        {
            driver.Close();
        }
    }
}