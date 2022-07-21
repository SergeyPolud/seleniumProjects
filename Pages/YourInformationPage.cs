using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class YourInformationPage : BasePage
{
    private const string END_POINT = "/checkout-step-one.html";

    private static readonly By TitleLocator = By.ClassName("title");
    private static readonly By FirstNameFieldLocator = By.Id("first-name");
    private static readonly By LastNameFieldLocator = By.Id("last-name");
    private static readonly By PostalCodeFieldLocator = By.Id("postal-code");
    private static readonly By ContinueButtonLocator = By.Id("continue");

    public YourInformationPage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
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
    public IWebElement FirstNameField => WaitService.WaitElementIsExists(FirstNameFieldLocator);
    public IWebElement LastNameField => WaitService.WaitElementIsExists(LastNameFieldLocator);
    public IWebElement PostalCodeField => WaitService.WaitElementIsExists(PostalCodeFieldLocator);
    public IWebElement ContinueButton => WaitService.WaitElementIsExists(ContinueButtonLocator);


    public void FillUsersData()
    {
        FirstNameField.SendKeys(Configurator.FirstName);
        LastNameField.SendKeys(Configurator.LastName);
        PostalCodeField.SendKeys(Configurator.PostalCode);
    }
}