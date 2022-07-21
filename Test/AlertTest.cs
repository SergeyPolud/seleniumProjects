using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace PageObject.Test;

public class AlertTest : BaseTest
{
    [Test]
    public void Test_JS_Alert()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");
        Driver.FindElement(By.CssSelector("button[onclick='jsAlert()']")).Click();

        IAlert alert = Driver.SwitchTo().Alert();
        string alertText = alert.Text;
        Console.Out.Write(alertText);
        alert.Accept();
        
        Assert.AreEqual("You successfully clicked an alert", Driver.FindElement(By.Id("result")).Text);
    }

    [Test]
    public void Test_JS_ConfirmationOk()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");
        Driver.FindElement(By.CssSelector("button[onclick='jsConfirm()']")).Click();

        IAlert confirmationAlert = Driver.SwitchTo().Alert();
        string alertText = confirmationAlert.Text;
        Console.Out.Write(alertText);
        confirmationAlert.Accept();
        
        var resultFieldText = Driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual("You clicked: Ok", resultFieldText);
    }
    
    [Test]
    public void Test_JS_ConfirmationCancel()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");
        Driver.FindElement(By.CssSelector("button[onclick='jsConfirm()']")).Click();

        IAlert confirmationAlert = Driver.SwitchTo().Alert();
        string alertText = confirmationAlert.Text;
        Console.Out.Write(alertText);
        confirmationAlert.Dismiss();

        var resultFieldText = Driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual("You clicked: Cancel", resultFieldText);
    }

    [Test]
    public void Test_PromptAlertOk()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");
        //Driver.FindElement(By.CssSelector("button[onclick='Click for JS Prompt']")).Click();
        Driver.FindElement(By.XPath("//button[contains(.,'Click for JS Prompt')]")).Click();

        IAlert promptAlert = Driver.SwitchTo().Alert();
        string alertText = promptAlert.Text;
        Console.Out.Write(alertText);
        var sendingMessage = "QWERTY";
        promptAlert.SendKeys("QWERTY");
        promptAlert.Accept();
        
        var resultFieldText = Driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual("You entered: QWERTY", resultFieldText);
    }
    
    [Test]
    public void Test_PromptAlertCancel()
    {
        Driver.Navigate().GoToUrl("http://the-internet.herokuapp.com/javascript_alerts");
        //Driver.FindElement(By.CssSelector("button[onclick='Click for JS Prompt']")).Click();
        Driver.FindElement(By.XPath("//button[contains(.,'Click for JS Prompt')]")).Click();

        IAlert promptAlert = Driver.SwitchTo().Alert();
        string alertText = promptAlert.Text;
        Console.Out.Write(alertText);
        var sendingMessage = "QWERTY";
        promptAlert.SendKeys("QWERTY");
        promptAlert.Dismiss();
        
        var resultFieldText = Driver.FindElement(By.Id("result")).Text;
        Assert.AreEqual("You entered: null", resultFieldText);
    }
}