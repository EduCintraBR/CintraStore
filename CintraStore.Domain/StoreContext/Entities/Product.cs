using CintraStore.Shared.Entities;
using FluentValidator.Validation;

namespace CintraStore.Domain.StoreContext.Entities
{
    public class Product : Entity
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

        public void DecreaseQuantity(decimal quantity)
        {
            this.QuantityOnHands -= quantity;
        }

        public void Validate()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasMinLen(this.Title, 3, "Title", "The Title must have at least 3 characters")
                .HasMaxLen(this.Title, 80, "Title", "The Title must have the maximum of 80 characters")
                .HasMinLen(this.Description, 3, "Title", "The Description must have at least 3 characters")
                .HasMaxLen(this.Description, 250, "Title", "The Description must have the maximum of 250 characters")
                .IsGreaterThan(this.Price, 0, "Price", "Price must be greater than zero"));

        }

        public override string ToString()
        {
            return this.Title;
        }
    }
}
