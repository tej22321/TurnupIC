using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpPortal.pages
{
    public class HomePage
    {

        public void NavigateToTimeMaterialPage(IWebDriver webDriver)
        {

            IWebElement Adminmenu = webDriver.FindElement(By.XPath("//body/div[3]/div[1]/div[1]/ul[1]/li[5]/a[1]"));
            Adminmenu.Click();

            webDriver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]")).Click();
        }

        public void VerifyLoggedInUser(IWebDriver webDriver)
        {

            string text = webDriver.FindElement(By.XPath("//body/div[3]/div[1]/div[1]/form[1]/ul[1]/li[1]/a[1]")).Text;

            if (text.Equals("Hello hari!"))
            {
                Console.WriteLine("user logged in successfully");
            }
            else
            {

                Console.WriteLine("user not logged in");
            }

        }
    }
}
