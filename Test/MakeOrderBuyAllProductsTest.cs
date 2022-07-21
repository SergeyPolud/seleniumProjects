using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;

namespace PageObject.Test;

public class MakeOrderBuyAllProductsTest : TestsAuthorizationFoundation
{
    [Test]
    public void ChooseAllProductsAndMakeOrderTest()
    {
        // Arrange
        var productsPage = new ProductsPage(Driver, false);
        var cartPage = new CartPage(Driver, false);
        var yourInformationPage = new YourInformationPage(Driver, false);
        var overviewPage = new Overview(Driver, false);
        
        // Act
        productsPage.AddAllInventoryItemsToCart();
        productsPage.GotoCartPage();
        cartPage.CheckoutButton.Click();
        yourInformationPage.FillUsersData();
        yourInformationPage.ContinueButton.Click();
        var totalOrderSum = Driver.FindElement(By.CssSelector(".summary_total_label")).Text;
        
        // Assert
        Assert.AreEqual("Total: $140.34", totalOrderSum);
        
        // Act
        overviewPage.FinishOrder.Click();
        var completeIndicator = Driver.FindElement(By.ClassName("title")).Text;
        
        // Assert
        Assert.AreEqual("CHECKOUT: COMPLETE!", completeIndicator);
    }
}