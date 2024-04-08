/* launch the browser , by keeping the URL in address bar , navigate to username text field enter the value, 
  navigate to password text field , enter the value 
  navigate to login button and select the button
  lands on homepage , check on the top right corner if the username matches 
    
 */

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


IWebDriver webDriver = new ChromeDriver();
webDriver.Navigate().GoToUrl("http://horse.industryconnect.io/Client");
webDriver.Manage().Window.Maximize();

IWebElement username =  webDriver.FindElement(By.Id("UserName"));
username.SendKeys("hari");

IWebElement pwd = webDriver.FindElement(By.Id("Password"));
pwd.SendKeys("123123");

webDriver.FindElement(By.XPath("//body/div[@id='container']/div[1]/div[1]/section[1]/form[1]/div[3]/input[1]")).Click();

String text = webDriver.FindElement(By.XPath("//body/div[3]/div[1]/div[1]/form[1]/ul[1]/li[1]/a[1]")).Text;

if (text.Equals("Hello hari!"))
{
    Console.WriteLine("user logged in successfully");
}
else 
    Console.WriteLine("user not logged in");
