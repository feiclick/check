namespace SeleniumTests
{

using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;



    //[TestFixture]
    public class 11sites
    {
        private IWebDriver driver;
    private StringBuilder verificationErrors;
    private string baseURL;
    private bool acceptNextAlert = true;


    //[SetUp]
    public void SetupTest()
    {
        driver = new FirefoxDriver();
        baseURL = "https://beta.jointservicessupport.org/";
        verificationErrors = new StringBuilder();
    }

    [TearDown]
    public void TeardownTest()
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

    [Test]
    public void The11sitesTest()
    {
        driver.Navigate().GoToUrl(baseURL + "/");
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open YRRP
        driver.FindElement(By.CssSelector("div.title")).Click();
        Assert.AreEqual("National Guard Yellow Ribbon Reintegration Program – Deployment Information, Benefits, and More", driver.Title);
        //back to JSS
        driver.FindElement(By.CssSelector("a.home-icon > span.item-title")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open DIV
        driver.FindElement(By.CssSelector("li.DIV > a > div.title")).Click();
        Assert.AreEqual("Diversity", driver.Title);
        //back to JSS
        driver.FindElement(By.LinkText("JSS")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open ESP
        driver.FindElement(By.CssSelector("li.ESP > a > div.title")).Click();
        Assert.AreEqual("Welcome to the National Guard Employer Support Program!", driver.Title);
        //back to JSS
        driver.FindElement(By.CssSelector("a.home-icon > span.item-title")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open EO
        driver.FindElement(By.CssSelector("li.EO.last-col > a > div.title")).Click();
        Assert.AreEqual("Equal Opportunity", driver.Title);
        //back to JSS
        driver.FindElement(By.LinkText("JSS")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open FP
        driver.FindElement(By.CssSelector("li.FP > a > div.title")).Click();
        Assert.AreEqual("NGB Family Program – Welcome to the National Guard Family Program website!", driver.Title);
        //back to JSS
        driver.FindElement(By.CssSelector("span.item-title")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open FMAP
        driver.FindElement(By.CssSelector("li.FMAP > a > div.title")).Click();
        Assert.AreEqual("Financial Management Awareness Program – Financial Readiness in the National Guard", driver.Title);
        //back to JSS
        driver.FindElement(By.CssSelector("a.home-icon > span.item-title")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open JCF
        driver.FindElement(By.CssSelector("li.JCF > a > div.title")).Click();
        Assert.AreEqual("Joining Community Forces for Our Military in Your Neighborhood", driver.Title);
        //back to JSS
        driver.FindElement(By.CssSelector("div.contentBox > div > div:nth-of-type(3) > a")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open PHP
        driver.FindElement(By.CssSelector("li.PHP.last-col > a > div.title")).Click();
        Assert.AreEqual("National Guard Psychological Health Program – Mental Health, Post Traumatic Stress Disorder, PTSD, TBI, Suicide Prevention", driver.Title);
        //back to JSS
        driver.FindElement(By.CssSelector("a.home-icon > span.item-title")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open SAPR
        driver.FindElement(By.CssSelector("li.SAPR > a > div.title")).Click();
        Assert.AreEqual("National Guard Sexual Assault Prevention & Response (SAPR) Program – sexual violence prevention, bystander intervention, education and support", driver.Title);
        //back to JSS
        driver.FindElement(By.CssSelector("a.home-icon > span.item-title")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open WS
        driver.FindElement(By.CssSelector("li.WS > a > div.title")).Click();
        Assert.AreEqual("National Guard Transition Assistance Program", driver.Title);
        //back to JSS
        driver.FindElement(By.CssSelector("a.home-icon > span.item-title")).Click();
        Assert.AreEqual("Welcome to the Joint Services Support System!", driver.Title);
        //open YCP
        driver.FindElement(By.CssSelector("li.YCP > a > div.title")).Click();
        Assert.AreEqual("NGYCP", driver.Title);
    }
    private bool IsElementPresent(By by)
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

    private bool IsAlertPresent()
    {
        try
        {
            driver.SwitchTo().Alert();
            return true;
        }
        catch (NoAlertPresentException)
        {
            return false;
        }
    }

    private string CloseAlertAndGetItsText()
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

    }
}



