using Xunit;

namespace basket_example.tests
{
    public class BasketTests
    {
        private const string ProductName = "Butter";
        private const decimal ProductPrice = 0.80m;

        [Fact]
        public void should_be_able_to_create_an_empty_basket_with_no_products()
        {
            var basket = new Basket();

            Assert.Empty(basket.Items);
        }

        [Fact]
        public void should_be_able_add_product_to_basket()
        {
            var basket = new Basket();

            basket.AddItem(new Product { Name = ProductName, Price = ProductPrice }, 1);
            Assert.Single(basket.Items);
        }

        [Fact]
        public void should_be_able_calculate_basket_total()
        {
            var basket = new Basket();

            basket.AddItem(new Product { Name = ProductName, Price = ProductPrice }, 1);
            Assert.Equal(ProductPrice, basket.Total);
        }

        [Fact]
        public void should_be_able_calculate_basket_total_when_we_we_have_multiple_products()
        {
            var basket = new Basket();

            basket.AddItem(new Product { Name = ProductName, Price = ProductPrice }, 1);
            basket.AddItem(new Product { Name = ProductName, Price = ProductPrice }, 1);
            Assert.Equal(ProductPrice * 2, basket.Total);
        }

        [Fact]
        public void should_be_able_to_add_same_item_more_than_once()
        {
            var basket = new Basket();

            basket.AddItem(new Product { Name = ProductName, Price = ProductPrice }, 2);
            Assert.Equal(ProductPrice * 2, basket.Total);
        }
    }
}
