using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class CartPage : BasePage
{
    private const string END_POINT = "/cart.html";
    private static readonly By TitleLocator = By.ClassName("title");
    private static readonly By CheckoutButtonLocator = By.Id("checkout");


    public CartPage(IWebDriver webDriver, bool openPageByUrl) : base(webDriver, openPageByUrl)
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
    
    public ReadOnlyCollection<IWebElement> GetCartItems() =>
        Driver.FindElements(By.ClassName("cart_item"));

    public ReadOnlyCollection<IWebElement> ChooseRemoveButtons() =>
        Driver.FindElements(By.ClassName("cart_button"));

    public void RemoveAllInventoryItemsFromCart()
    {
        foreach (var RemoveFromCartButton in ChooseRemoveButtons())
            RemoveFromCartButton.Click();
    }
    
    public IWebElement Title => WaitService.WaitElementIsExists(TitleLocator);
    public IWebElement CheckoutButton => WaitService.WaitElementIsExists(CheckoutButtonLocator);

}