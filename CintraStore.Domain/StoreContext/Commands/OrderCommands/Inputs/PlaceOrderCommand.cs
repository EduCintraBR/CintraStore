using CintraStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;
using System;
using System.Collections.Generic;

namespace CintraStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            this.OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract().Requires()
                .HasLen(this.Customer.ToString(), 36, "CustomerId", "Customer identification is invalid!")
                .IsGreaterThan(this.OrderItems.Count, 0, "Items", "The order doesn't contain any products!")
            );
            return IsValid;
        }
    }
}
