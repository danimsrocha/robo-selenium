using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Threading;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var driver = new ChromeDriver("C:\\ProjetosSelenium");
            driver.Navigate().GoToUrl("https://www.futurefcmma.com/l/pt-BR/");
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            for (int i = 0; i < 5; i++)
            {
                string guid = Guid.NewGuid().ToString();
                Votar(driver, guid);
            }

            driver.Quit();
        }

        private void Votar(ChromeDriver driver, string emailGuid)
        {
            Thread.Sleep(1000);

            driver.FindElement(By.ClassName("fighter")).Click();

            var login = driver.FindElement(By.Id("usernameLogin"));
            login.SendKeys("email_" + emailGuid + "@gmail.com");

            driver.FindElement(By.ClassName("login")).Click();

            var formcontrol = driver.FindElement(By.Name("name"));
            formcontrol.SendKeys("Teste");

            var password = driver.FindElement(By.Name("password"));
            password.SendKeys("password");

            var password2 = driver.FindElement(By.Name("password2"));
            password2.SendKeys("password");

            driver.FindElement(By.Id("input-i_accept_the_terms_of_service")).Click();

            driver.FindElement(By.ClassName("login")).Click();

            Thread.Sleep(1000);

            var linkfight = driver.FindElement(By.CssSelector("a[href='/l/pt-BR/people_fight']"));
            linkfight.Click();

            Thread.Sleep(1000);

            var element = driver.FindElement(By.Id("suggest-4"));

            while (!element.Displayed)
            {
                driver.FindElement(By.Id("next-suggest")).Click();
            };

            var voto = driver.FindElement(By.CssSelector("a[data-athlete='sprat-zjkxv5-jifb-flvp-q27g-n2kivzmq'"));
            voto.Click();

            var sair = driver.FindElement(By.CssSelector("a[onclick='logout();']"));
            sair.Click();
        }
    }
}