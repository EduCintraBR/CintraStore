namespace CintraStore.Domain.StoreContext.Entities
{
    public class OrderItem
    {
        public OrderItem(Product product, decimal quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = product.Price;
        }

        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
