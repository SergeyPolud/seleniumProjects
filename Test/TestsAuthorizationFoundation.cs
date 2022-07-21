using System;
using NUnit.Framework;
using PageObject.Services;

namespace PageObject.Test;

public class TestsAuthorizationFoundation : BaseTest
{
    [OneTimeSetUp]
    public void OneTimeSetup()
    {
        base.Setup();
        Tools.Login(WebDriver);
    }
    [SetUp]
    public override void Setup()
    {
        //base.Setup();
        //Tools.Login(WebDriver);
        Console.WriteLine("Override setup ...");
    }

    [TearDown]
    public override void TearDown()
    {
        Console.WriteLine("Overrided TearDown");
    }

    [OneTimeTearDown]
    public void OneTimeTearDown()
    {
        WebDriver.Quit();
    }
}