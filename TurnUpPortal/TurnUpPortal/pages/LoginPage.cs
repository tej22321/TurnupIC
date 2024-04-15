using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal.pages
{
    public class LoginPage
    {

        public void LoginActions(IWebDriver webDriver)
        {
            webDriver.Navigate().GoToUrl("http://horse.industryconnect.io/Client");
            webDriver.Manage().Window.Maximize();

            IWebElement username = webDriver.FindElement(By.Id("UserName"));
            username.SendKeys("hari");

            IWebElement pwd = webDriver.FindElement(By.Id("Password"));
            pwd.SendKeys("123123");

            webDriver.FindElement(By.XPath("//body/div[@id='container']/div[1]/div[1]/section[1]/form[1]/div[3]/input[1]")).Click();

        }
    }
}
