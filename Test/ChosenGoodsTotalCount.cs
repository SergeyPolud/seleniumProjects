using NUnit.Framework;
using OpenQA.Selenium;
using PageObject.Pages;

namespace PageObject.Test;

[TestFixture]
public class ChosenGoodsTotalCount : TestsAuthorizationFoundation
{
    [Test]
    public void ChooseAllGoodItem()
    {
        var productsPage = new ProductsPage(Driver, false);
        Assert.AreEqual(6, productsPage.GetInventoryItems().Count);
    }
    
    [Test]
    public void WhenAllItemsAddedToCart_ThenCartItemsNumberShouldBe6()
    {
        // Arrange
        var productsPage = new ProductsPage(Driver, false);
        
        // Act
        productsPage.AddAllInventoryItemsToCart();
        var shoppingCartBadge = Driver.FindElement(By.ClassName("shopping_cart_badge"));
        var displayedItemsCount = shoppingCartBadge.Text;
        
        // Assert
        Assert.AreEqual("6", displayedItemsCount);
    }
}