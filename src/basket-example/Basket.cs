using System.Collections.Generic;
using System.Linq;

namespace basket_example
{
    public class Basket
    {
        public List<Item> Items { get; }
        public decimal Total
        {
            get { return Items.Sum(x => CalculateProductPriceIncludingOffers(x)); }
        }

        private decimal CalculateProductPriceIncludingOffers(Item item)
        {
            if (item.Offer == null)
                return item.Product.Price * item.Count;

            var itemsFullPrice = item.Count - item.ApplyOfferCount;

            return item.Product.Price * itemsFullPrice + item.ApplyOfferCount * item.Product.Price * item.Offer.Percent;
        }

        public Basket()
        {
            Items = new List<Item>();
        }

        public void AddItem(Product product, int count)
        {
            if (count < 1)
                return;

            var existingProduct =
                Items.FirstOrDefault(x => x.Product.Name == product.Name & x.Product.Price == product.Price);
            if (existingProduct != null)
            {
                existingProduct.Count += count;
            }
            else
            {
                Items.Add(new Item()
                {
                    Product = product,
                    Count = count
                });
            }
        }
    }
}
