using System;
using System.Collections.ObjectModel;
using OpenQA.Selenium;
using PageObject.Services;

namespace PageObject.Pages;

public class ProductsPage : BasePage
{
    private const string END_POINT = "/inventory.html";

    private static readonly By TitleLocator = By.ClassName("title");

    private static readonly By BackPack_AddLocator = By.Id("add-to-cart-sauce-labs-backpack");
    private static readonly By BikeLight_AddLocator = By.Id("add-to-cart-sauce-labs-bike-light");
    private static readonly By BoltT_Shirt_AddLocator = By.Id("add-to-cart-sauce-labs-bolt-t-shirt");
    private static readonly By FleeceJacket_AddLocator = By.Id("add-to-cart-sauce-labs-fleece-jacket");
    private static readonly By Onesie_AddLocator = By.Id("add-to-cart-sauce-labs-onesie");
    private static readonly By Test_allTheThings_AddLocator = By.Id("add-to-cart-test.allthethings()-t-shirt-(red)");

    public ProductsPage(IWebDriver driver, bool openPageByUrl) : base(driver, openPageByUrl)
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

    public ReadOnlyCollection<IWebElement> GetInventoryItems() =>
        Driver.FindElements(By.ClassName("inventory_item"));

    public ReadOnlyCollection<IWebElement> GetAddToCartButtons() =>
        Driver.FindElements(By.ClassName("btn_inventory"));

    public void AddAllInventoryItemsToCart()
    {
        foreach (var addToCartButton in GetAddToCartButtons())
            addToCartButton.Click();
    }

    public void GotoCartPage()
    {
        Driver.FindElement(By.ClassName("shopping_cart_link")).Click();
    }

    public IWebElement Title => WaitService.WaitElementIsExists(TitleLocator);
    public IWebElement Item_BackPack => WaitService.WaitElementIsExists(BackPack_AddLocator);
    public IWebElement Item_BikeLight => WaitService.WaitElementIsExists(BikeLight_AddLocator);
    public IWebElement Item_BoltT_Shirt => WaitService.WaitElementIsExists(BoltT_Shirt_AddLocator);
    public IWebElement Item_FleeceJacket => WaitService.WaitElementIsExists(FleeceJacket_AddLocator);
    public IWebElement Item_Onesie => WaitService.WaitElementIsExists(Onesie_AddLocator);
    public IWebElement Item_Test_allTheThings => WaitService.WaitElementIsExists(Test_allTheThings_AddLocator);
}