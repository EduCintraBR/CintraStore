using CintraStore.Shared.Commands;
using FluentValidator;
using System;

namespace CintraStore.Domain.StoreContext.Commands.OrderCommands.Inputs
{
    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}
