using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;
using PageObject.Services;

namespace PageObject.Test;

public class ChooseItemsInProductsPageTest : TestsAuthorizationFoundation
{
    [Test]
    public void ChooseBackPackTest()
    {
        ProductsPage productsPage = new ProductsPage(Driver, false);
        productsPage.Item_BackPack.Click();
        var result = WebDriver.FindElement(By.Id("remove-sauce-labs-backpack")).Text;
        Assert.AreEqual("REMOVE", result);
    }
    
    [Test]
    public void ChosenBikeLightTest()
    {
        ProductsPage productsPage = new ProductsPage(Driver, false);
        productsPage.Item_BikeLight.Click();
        var result = WebDriver.FindElement(By.Id("remove-sauce-labs-bike-light")).Text;
        Assert.AreEqual("REMOVE", result);
    }
    [Test]
    public void ChooseBoltT_ShirtTest()
    {
        ProductsPage productsPage = new ProductsPage(Driver, false);
        productsPage.Item_BoltT_Shirt.Click();
        var result = WebDriver.FindElement(By.Id("remove-sauce-labs-bolt-t-shirt")).Text;
        Assert.AreEqual("REMOVE", result);
    }
    [Test]
    public void ChooseFleeceJacketTest()
    {
        ProductsPage productsPage = new ProductsPage(Driver, false);
        productsPage.Item_FleeceJacket.Click();
        var result = WebDriver.FindElement(By.Id("remove-sauce-labs-fleece-jacket")).Text;
        Assert.AreEqual("REMOVE", result);
    }
    [Test]
    public void ChooseOnesieTest()
    {
        ProductsPage productsPage = new ProductsPage(Driver, false);
        productsPage.Item_Onesie.Click();
        var result = WebDriver.FindElement(By.Id("remove-sauce-labs-onesie")).Text;
        Assert.AreEqual("REMOVE", result);
    }
    [Test]
    public void ChooseTest_allTheThingsTest()
    {
        ProductsPage productsPage = new ProductsPage(Driver, false);
        productsPage.Item_Test_allTheThings.Click();
        var result = WebDriver.FindElement(By.Id("remove-test.allthethings()-t-shirt-(red)")).Text;
        Assert.AreEqual("REMOVE", result);
    }
}