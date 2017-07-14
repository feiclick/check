using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using Assert = NUnit.Framework.Assert;


namespace CreatEvent_Dev1
{

    [TestClass]

    public class OpenYRRP
    {
        
        public IWebDriver driver;
        public StringBuilder verificationErrors;
        public string baseURL;

        private bool acceptNextAlert = true;
        protected string Get2FA(string path)
        {
            String authcode = File.ReadLines(path).First().Trim();
            return authcode;
        }

        [TestInitialize]

        public void TestInitialize()
        {

            driver = new FirefoxDriver();
            baseURL = "https://beta.yellowribbonevents.org/";
            verificationErrors = new StringBuilder();

            String currentPath = System.IO.Directory.GetParent(System.IO.Directory.GetParent(Environment.CurrentDirectory).ToString()).ToString();
            string str2FAFile = System.IO.Directory.GetParent(currentPath) + "\\2FA\\WinAuth.txt";
            string authcode = Get2FA(str2FAFile);


        }


        [TestMethod]

        public void Login()
        {


            driver.Navigate().GoToUrl(baseURL + "/");
            Assert.AreEqual("EventPLUS", driver.Title);
            driver.FindElement(By.LinkText("Staff Login")).Click();
            Assert.AreEqual("EventPLUS", driver.Title);
            driver.FindElement(By.Id("ctl00_cphCenterColumn_ucLoginBox_txtEmail")).Clear();
            driver.FindElement(By.Id("ctl00_cphCenterColumn_ucLoginBox_txtEmail")).SendKeys("fxu@affinityempowering.com");
            driver.FindElement(By.Id("ctl00_cphCenterColumn_ucLoginBox_txtPassword")).Clear();
            driver.FindElement(By.Id("ctl00_cphCenterColumn_ucLoginBox_txtPassword")).SendKeys("");
            driver.FindElement(By.Id("ctl00_cphCenterColumn_ucLoginBox_btnAgree")).Click();
            driver.FindElement(By.Id("btnLogin")).Click();
            Assert.AreEqual("EventPLUS", driver.Title);

            //launch WinAuth.exe

            System.Diagnostics.Process.Start("C:\\Program Files\\WinAuth-3.5.1\\WinAuth.exe");
            SendKeys.Send("");
            Thread.Sleep(5000);


            driver.FindElement(By.Id("txtVerificationCode")).Clear();
            driver.FindElement(By.Id("txtVerificationCode")).SendKeys($"{authcode}");
            driver.FindElement(By.Id("btnLogin")).Click();
            Assert.AreEqual("Event Listing", driver.Title);


            bool IsElementPresent(By by)
            {
                try
                {
                    driver.FindElement(by);
                    return true;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            }

            string CloseAlertAndGetItsText()
            {
                try
                {
                    IAlert alert = driver.SwitchTo().Alert();
                    string alertText = alert.Text;
                    if (acceptNextAlert)
                    {
                        alert.Accept();
                    }
                    else
                    {
                        alert.Dismiss();
                    }
                    return alertText;
                }
                finally
                {
                    acceptNextAlert = true;
                }
            }


            void CloseBrowser()
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
                Assert.AreEqual("", verificationErrors.ToString());
            }

        }


    }


}
