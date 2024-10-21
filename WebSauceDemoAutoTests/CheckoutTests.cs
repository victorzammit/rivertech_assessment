using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SauceDemoTests
{
    [TestFixture]
    public class CheckoutTests
    {
        private IWebDriver _driver;

        [SetUp]
        public void SetUp()
        {
            // Initialize ChromeDriver
            _driver = new ChromeDriver();
            _driver.Manage().Window.Maximize(); // Maximize the browser window
        }

        [Test]
        public void Checkout_Scenario()
        {
            // Open the SauceDemo login page
            _driver.Navigate().GoToUrl("https://www.saucedemo.com/");

            // Login
            var usernameField = _driver.FindElement(By.Id("user-name"));
            var passwordField = _driver.FindElement(By.Id("password"));
            var loginButton = _driver.FindElement(By.ClassName("btn_action"));

            usernameField.SendKeys("standard_user");
            passwordField.SendKeys("secret_sauce");
            loginButton.Click();

            // Wait for the page to load
            Thread.Sleep(500);

            // Add "Sauce Labs Fleece Jacket" to the cart
            var fleeceJacketButton = _driver.FindElement(By.XPath("//*[@id='add-to-cart-sauce-labs-fleece-jacket']"));
            fleeceJacketButton.Click();

            // Go to the cart
            var cartButton = _driver.FindElement(By.ClassName("shopping_cart_link"));
            cartButton.Click();

            // Assert the item is present in the cart
            var itemText = _driver.FindElement(By.XPath("//div[contains(text(),'Sauce Labs Fleece Jacket')]"));
            Assert.IsNotNull(itemText);

            // Click checkout
            var checkoutButton = _driver.FindElement(By.XPath("//button[text()='Checkout']"));
            checkoutButton.Click();

            // Input fake firstname, lastname, and postcode
            var firstNameField = _driver.FindElement(By.Id("first-name"));
            var lastNameField = _driver.FindElement(By.Id("last-name"));
            var postalCodeField = _driver.FindElement(By.Id("postal-code"));
            var continueButton = _driver.FindElement(By.XPath("//input[@value='Continue']"));

            firstNameField.SendKeys("John");
            lastNameField.SendKeys("Doe");
            postalCodeField.SendKeys("12345");
            continueButton.Click();

            // Assert the total values
            var itemTotal = _driver.FindElement(By.XPath("//div[@class='summary_subtotal_label']"));
            var tax = _driver.FindElement(By.XPath("//div[@class='summary_tax_label']"));
            var total = _driver.FindElement(By.XPath("//div[@class='summary_total_label']"));

            Assert.That(itemTotal.Text, Is.EqualTo("Item total: $49.99"));
            Assert.That(tax.Text, Is.EqualTo("Tax: $4.00"));
            Assert.That(total.Text, Is.EqualTo("Total: $53.99"));

            // Click finish
            var finishButton = _driver.FindElement(By.XPath("//button[text()='Finish']"));
            finishButton.Click();

            // Verify that order has been dispatched
            var confirmationMessage = _driver.FindElement(By.XPath("//h2[contains(text(),'Thank you for your order!')]"));
            Assert.IsNotNull(confirmationMessage);
        }

        [TearDown]
        public void TearDown()
        {
            // Close the browser
            _driver.Quit();
            _driver.Dispose();
        }
    }
}
