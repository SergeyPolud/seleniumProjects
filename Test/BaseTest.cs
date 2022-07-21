using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using PageObject.Services;

namespace PageObject.Test;

public class BaseTest
{
    protected static IWebDriver WebDriver;

    [SetUp]
    public virtual void Setup()
    {
        WebDriver = new BrowserService().WebDriver;
    }

    [TearDown]
    public virtual void TearDown()
    {
        WebDriver.Quit();
    }
    
    public static IWebDriver Driver
    {
        get => WebDriver;
        set => WebDriver = value ?? throw new ArgumentNullException(nameof(value));
    }
}