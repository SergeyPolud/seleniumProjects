using NUnit.Framework;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Test;

public class LoginTest : BaseTest
{
    [Test]
    public void LoginSuccessTest()
    {
        LoginPage loginPage = new LoginPage(WebDriver, true);
        loginPage.UserNameInput.SendKeys(Configurator.Username);
        loginPage.UserPasswordInput.SendKeys(Configurator.Password);
        loginPage.LoginButton.Submit();
        
        ProductsPage productsPage = new ProductsPage(Driver, false);
        
        Assert.AreEqual("products", productsPage.Title.Text.ToLower());
    }
}
