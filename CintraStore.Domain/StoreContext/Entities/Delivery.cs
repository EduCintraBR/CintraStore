using CintraStore.Domain.StoreContext.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace CintraStore.Domain.StoreContext.Entities
{
    public class Delivery
    {
        public Delivery(int days)
        {
            this.CreateDate = DateTime.Now;
            this.EstimatedDeliveryDate = DateTime.Now.AddDays(days);
            this.Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; set; }
        public DateTime EstimatedDeliveryDate { get; set; }
        public EDeliveryStatus Status { get; set; }

        public void Ship()
        {
            this.Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            this.Status = EDeliveryStatus.Canceled;
        }
    }
}
