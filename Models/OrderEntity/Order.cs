using System;
using System.Collections.Generic;
using PublishingHouse.Models.UserEntity;
using PublishingHouse.Models.PrintedEditionEntity;

namespace PublishingHouse.Models.OrderEntity
{
    public class Order
    {
        public int Id { get; set; }

        public int? UserId { get; set; }
        public virtual User? User { get; set; }

        public DateTime OrderDate { get; set; }

        public ICollection<PrintedEdition>? PrintedEditions { get; set; }

        public decimal TotalPrice { get; set; }

        public string Status { get; set; }

        public Order() { }

        public Order(int id, int userId, DateTime orderDate)
        {
            Id = id;
            UserId = userId;
            OrderDate = orderDate;
        }
    }
}
