using OpenQA.Selenium;
using PageObject.Pages;

namespace PageObject.Services;

public static class Tools
{
    public static void Login(IWebDriver webDriver)
    {
        var loginPage = new LoginPage(webDriver, true);
        loginPage.UserNameInput.SendKeys(Configurator.Username);
        loginPage.UserPasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();
    }
}