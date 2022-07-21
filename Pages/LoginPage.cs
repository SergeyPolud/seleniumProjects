using System;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class LoginPage : BasePage
{
    private const string END_POINT = "/";
    
    // Description of locators
    private static readonly By UsernameInputLocator = By.Id("user-name");
    private static readonly By PasswordInputLocator = By.Id("password");
    private static readonly By LoginButtonLocator = By.Id("login-button");

    // Constructors
    public LoginPage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
    {
    }

    protected override void OpenPage()
    {
        Driver.Navigate().GoToUrl(Configurator.BaseUrl+END_POINT);
    }

    protected override bool IsPageOpened()
    {
        try
        {
            return LoginButton.Displayed;
        }
        catch (Exception e)
        {
            return false;
        }
    }
    
    // Атомарные элементы
    public IWebElement UserNameInput => WaitService.WaitElementIsExists(UsernameInputLocator);
    public IWebElement UserPasswordInput => WaitService.WaitElementIsExists(PasswordInputLocator);
    public IWebElement LoginButton => WaitService.WaitElementIsExists(LoginButtonLocator);

}