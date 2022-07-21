using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class Overview : BasePage
{
    private const string END_POINT = "/checkout-step-two.html";
    
    // Description of locators
    private static readonly By TitleLocator = By.ClassName("title");
    private static readonly By FinishButtonLocator = By.Id("finish");

    public Overview(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl + END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return Title.Displayed;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }
    
    public IWebElement Title => WaitService.WaitElementIsExists(TitleLocator);
    public IWebElement FinishOrder => WaitService.WaitElementIsExists(FinishButtonLocator);

}