using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.pages
{
    public class TimeMaterialPage : Program
    {

        public void CreateNewTMRecord(IWebDriver webDriver)
        {


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




            webDriver.FindElement(By.XPath("//a[contains(text(),'Create New')]")).Click();


            webDriver.FindElement(By.XPath("//body/div[@id='container']/form[@id='TimeMaterialEditForm']/div[1]/div[1]/div[1]/span[1]/span[1]")).Click();



            webDriver.FindElement(By.XPath("//ul[@id='TypeCode_listbox']//li[2]")).Click();
            


            webDriver.FindElement(By.Id("Code")).SendKeys("ICMARCH");


            webDriver.FindElement(By.Id("Description")).SendKeys("ICMARCH TEST");


            webDriver.FindElement(By.XPath("//body/div[@id='container']/form[@id='TimeMaterialEditForm']/div[1]/div[4]/div[1]/span[1]/span[1]/input[1]")).SendKeys("ICMARCH TEST");


            webDriver.FindElement(By.Id("Price")).SendKeys("25");

            string baseDirectory = AppContext.BaseDirectory;
            string relativePath = "../../../images/istqb_logo_nobackground.png";
            string uploadFile = Path.GetFullPath(Path.Combine(baseDirectory, relativePath));
            webDriver.FindElement(By.Id("files")).SendKeys(uploadFile);



            webDriver.FindElement(By.Id("SaveButton")).Click();
            
            WebUtilities.waitToBeVisible(webDriver, "//*[@id=\"tmsGrid\"]/div[4]/a[4]", 5);
            webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();

            VerifyRecordCreated(webDriver);
        }

        public void UpdateTMRecord(IWebDriver webDriver)
        {
            /* Edit new record :

       Navigate to the edit button of the newly created row 
       navigate to code textbox , and edit the value 
       navingate to save button and clik on save
       navigate to last row an compare the value of the editting value to check if successfully inserted the editted row 

       */

            webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[last()]/a[1]")).Click();

            String CodeValue = webDriver.FindElement(By.Id("Code")).GetAttribute("value");

            webDriver.FindElement(By.Id("Code")).Clear();
            
            
            webDriver.FindElement(By.Id("Code")).SendKeys(CodeValue + "edit2");


            webDriver.FindElement(By.Id("SaveButton")).Click();
            WebUtilities.waitToBeVisible(webDriver, "//*[@id=\"tmsGrid\"]/div[4]/a[4]",5);


            webDriver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
            VerifyRecordUpdated(webDriver, CodeValue);

        }

        public void DeleteTMRecord(IWebDriver webDriver)
        {

            /* Delete the new record created:

            Navigate to the delete button of the newly created row , and click on delete button
            Navigate to the pop up window and cick ok
            compare to make sure successfully deleted 
            */

            webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[last()]/a[2]")).Click();
            webDriver.SwitchTo().Alert().Accept();

            //Thread.Sleep(3000);
                        
            WebUtilities.waitToBeVisible(webDriver, "//tbody/tr[last()]/td[1]",10);
            VerifyRecordDeleted(webDriver);
        }


        public void VerifyRecordCreated(IWebDriver webDriver)
        {
            string CodeValue = webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text;

            if (CodeValue == "ICMARCH")
            {
                Console.WriteLine("successfully inserted");
            }
            else
                Console.WriteLine("not successfully inserted");


        }

        public void VerifyRecordUpdated(IWebDriver webDriver, String CodeValue)
        {

            string EditCodeValue = webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text;

            if (EditCodeValue == CodeValue + "edit2")
            {
                Console.WriteLine("successfully inserted Editted value");
            }
            else
                Console.WriteLine("not successfully inserted the editted value ");
        }

        public void VerifyRecordDeleted(IWebDriver webDriver)
        {
            string EditCodeValue = webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text;
            string CodeValue = webDriver.FindElement(By.XPath("//tbody/tr[last()]/td[1]")).Text;


            if (EditCodeValue == CodeValue + "edit2")
            {
                Console.WriteLine("Not successfully Deleted");
            }
            else
                Console.WriteLine("successfully Deleted");
        }
    }
}
