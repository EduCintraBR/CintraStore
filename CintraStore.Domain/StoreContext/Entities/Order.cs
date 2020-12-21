using CintraStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CintraStore.Domain.StoreContext.Entities
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;

        public Order(Customer customer)
        {
            this.Customer = customer;
            
            this.CreateDate = DateTime.Now;
            this.Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        // To Add An Item In Order
        public void AddItem(OrderItem item)
        {
            // Valid Item
            // Add Item
            _items.Add(item);
        }

        // To place An Order
        public void Place()
        {
            // Generate the Order Number
            this.Number = Guid.NewGuid().ToString().Replace("-", "").Substring(0, 6).ToUpper();
        }

        // To pay An Order
        public void PayOrder() 
        {
            this.Status = EOrderStatus.Paid;
            
        }

        // To send An Order
        public void ShipOrder() 
        {
            var deliveries = new List<Delivery>();
            deliveries.Add(new Delivery(7));
            var count = 1;

            foreach (var item in _items)
            {
                if (count == 5)
                {
                    deliveries.Add(new Delivery(7));
                }
                count++;
            }
            //Ship all the orders
            deliveries.ForEach(x => x.Ship());
            // Add all deliveries of the order
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        // To Cancel An Order
        public void CancelOrder() 
        {
            this.Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }

    }
}
