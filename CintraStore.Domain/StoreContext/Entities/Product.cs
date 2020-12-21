namespace CintraStore.Domain.StoreContext.Entities
{
    public class Product
    {
        public Product(string title, string description, string image, decimal price, decimal quantityOnHand)
        {
            this.Title = title;
            this.Description = description;
            this.Image = image;
            this.Price = price;
            this.QuantityOnHands = quantityOnHand;
        }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public string Image { get; private set; }
        public decimal Price { get; private set; }
        public decimal QuantityOnHands { get; private set; }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
