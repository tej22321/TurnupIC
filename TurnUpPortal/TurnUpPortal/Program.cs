/* launch the browser , by keeping the URL in address bar , navigate to username text field enter the value, 
  navigate to password text field , enter the value 
  navigate to login button and select the button
  lands on homepage , check on the top right corner if the username matches 
    
 */

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using TurnUpPortal.pages;



public class Program
{
    private static void Main(string[] args)
    {
        IWebDriver webDriver = new ChromeDriver();

        // initaiate and assign HomePage class
        LoginPage loginPageObj = new LoginPage();
        loginPageObj.LoginActions(webDriver);

        // initiate HomePage and assign the value 

        HomePage homePageObj = new HomePage();
        homePageObj.NavigateToTimeMaterialPage(webDriver);
        homePageObj.VerifyLoggedInUser(webDriver);

        //intitate TimeMaterialPage and assign the value

        TimeMaterialPage tmPageObj = new TimeMaterialPage();
        tmPageObj.CreateNewTMRecord(webDriver);
        tmPageObj.UpdateTMRecord(webDriver);
        tmPageObj.DeleteTMRecord(webDriver);





    }
}