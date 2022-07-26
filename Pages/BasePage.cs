using System;
using System.Threading;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public abstract class BasePage
{
    [ThreadStatic] private static IWebDriver _webDriver;
    private const int WAIT_FOR_PAGE_LOADING_TIME = 60;
    private static WaitService _waitService;

    protected abstract void OpenPage();

    protected abstract bool IsPageOpened();

    protected BasePage(IWebDriver webDriver, bool openPageByUrl)
    {
        Driver = webDriver;
        _waitService = new WaitService(Driver);

        if (openPageByUrl)
        {
            OpenPage();
        }

        WaitForOpen();
    }

    private void WaitForOpen()
    {
        var secondsCount = 0;
        var isPageOpenedIndicator = IsPageOpened();

        while (!isPageOpenedIndicator && secondsCount < WAIT_FOR_PAGE_LOADING_TIME / Configurator.WaitTimeout)
        {
            //Thread.Sleep(1000);
            secondsCount++;
            isPageOpenedIndicator = IsPageOpened();

            if (!isPageOpenedIndicator)
            {
                throw new AssertionException("Page was not opened...");
            }
        }
    }

    public static IWebDriver Driver
    {
        get => _webDriver;
        set => _webDriver = value ?? throw new ArgumentNullException(nameof(value));
    }
    
    public static WaitService WaitService
    {
        get => _waitService;
    }
}