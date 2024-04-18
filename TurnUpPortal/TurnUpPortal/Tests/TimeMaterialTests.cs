using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpPortal.pages;
using TurnUpPortal.Utilities;

namespace TurnUpPortal.Tests
{
    
    public class TimeMaterialTests:CommonDriver
    {
        TimeMaterialPage tmPageObj = new TimeMaterialPage();
        LoginPage loginPageObj = new LoginPage();
        HomePage homePageObj = new HomePage();

        [SetUp] 
        public void SetUpTimeAndMaterial() {
            webDriver = new ChromeDriver();
            loginPageObj.LoginActions(webDriver);
                                   
            homePageObj.NavigateToTimeMaterialPage(webDriver);
            homePageObj.VerifyLoggedInUser(webDriver);
        }

        [Test, Order(1), Description("creating new Time recoed")]
        public void CreateTMRecordTest()
        {
            
            tmPageObj.CreateNewTMRecord(webDriver);

        }
        [Test, Order(2), Description("Editting the newly created record")]
        public void EditTMRecordTest()
        {
            tmPageObj.UpdateTMRecord(webDriver);
        }
        [Test, Order(3), Description("Deleting the newly created record")]
        public void DelteTMRecordTest()
        {
            tmPageObj.DeleteTMRecord(webDriver);
        }
        [TearDown]
        public void TearDownTimeAndMaterial()
        {
            webDriver.Quit();
        }
    }
}
