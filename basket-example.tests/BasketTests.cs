using Xunit;

namespace basket_example.tests
{
    
    public class BasketTests
    {
        [Fact]
        public void should_be_able_to_create_a_basket()
        {
            var basket = new Basket();
        }
    }
}
