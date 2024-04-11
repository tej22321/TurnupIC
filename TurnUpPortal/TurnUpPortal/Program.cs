/* launch the browser , by keeping the URL in address bar , navigate to username text field enter the value, 
  navigate to password text field , enter the value 
  navigate to login button and select the button
  lands on homepage , check on the top right corner if the username matches 
    
 */

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;


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
{

    Console.WriteLine("user not logged in");
}


/* Go to menu option Adminstration , select the drop down option Time and Material
   Navigate to Create New button,click it
   Navigate to Typecode dropdown, select the appropraite Time 
   Navigate to code textbox , enter the value "ICTEST"
   Navigate to Description textbox, enter the value " This is for test"
   Navigate to price textbox , enter the value "25"
   Navigate to Selct Files button , upload the file
   Navigate to Save button,click it 
   Navigate to the table last row, compare the values of each column with the data inserted 
   
*/


IWebElement Adminmenu = webDriver.FindElement(By.XPath("//body/div[3]/div[1]/div[1]/ul[1]/li[5]/a[1]"));
Adminmenu.Click();

webDriver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]")).Click();


webDriver.FindElement(By.XPath("//a[contains(text(),'Create New')]")).Click();


webDriver.FindElement(By.XPath("//body/div[@id='container']/form[@id='TimeMaterialEditForm']/div[1]/div[1]/div[1]/span[1]/span[1]")).Click();






webDriver.FindElement(By.XPath("//ul[@id='TypeCode_listbox']//li[2]")).Click();
//input[@id='Code']


webDriver.FindElement(By.Id("Code")).SendKeys("ICMARCH");


webDriver.FindElement(By.Id("Description")).SendKeys("ICMARCH TEST");


webDriver.FindElement(By.XPath("//body/div[@id='container']/form[@id='TimeMaterialEditForm']/div[1]/div[4]/div[1]/span[1]/span[1]/input[1]")).SendKeys("ICMARCH TEST");


webDriver.FindElement(By.Id("Price")).SendKeys("25");


webDriver.FindElement(By.Id("SaveButton")).Click();

Thread.Sleep(3000);

webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();

String CodeValue = webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text;

if (CodeValue == "ICMARCH") 
{
    Console.WriteLine("successfully inserted");
}
else
    Console.WriteLine("not successfully inserted");


/* Edit new record :
 
Navigate to the edit button of the newly created row 
navigate to code textbox , and edit the value 
navingate to save button and clik on save
navigate to last row an compare the value of the editting value to check if successfully inserted the editted row 

*/

webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[last()]/a[1]")).Click();

webDriver.FindElement(By.Id("Code")).Clear();

webDriver.FindElement(By.Id("Code")).SendKeys(CodeValue + "edit2");


webDriver.FindElement(By.Id("SaveButton")).Click();

Thread.Sleep(3000);

webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();

String EditCodeValue = webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text;

if (EditCodeValue == CodeValue+ "edit2") 
{
    Console.WriteLine("successfully inserted Editted value");
}
else
    Console.WriteLine("not successfully inserted the editted value ");

/* Delete the new record created:
 
Navigate to the delete button of the newly created row , and click on delete button
Navigate to the pop up window and cick ok
compare to make sure successfully deleted 
*/

webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[last()]/a[2]")).Click();
webDriver.SwitchTo().Alert().Accept();

Thread.Sleep(3000);
EditCodeValue = webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text;


if (EditCodeValue == CodeValue + "edit2")
{
    Console.WriteLine("Not successfully Deleted");
}
else
    Console.WriteLine("successfully Deleted");
