namespace basket_example
{
    public class Item
    {
        public Product Product { get; set; }
        public int Count { get; set; }
        public Offer Offer { get; set; }
        public int ApplyOfferCount { get; set; }
    }
}