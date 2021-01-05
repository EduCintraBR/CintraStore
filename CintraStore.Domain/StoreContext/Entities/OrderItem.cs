using CintraStore.Shared.Entities;

namespace CintraStore.Domain.StoreContext.Entities
{
    public class OrderItem : Entity
    {
        public OrderItem(Product product, decimal quantity)
        {
            this.Product = product;
            this.Quantity = quantity;
            this.Price = product.Price;

            if (product.QuantityOnHands < quantity)
                AddNotification("Quantity", $"Product {product.Title} doesn't have {quantity} items in stock");

            product.DecreaseQuantity(quantity);
        }

        public Product Product { get; set; }
        public decimal Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
