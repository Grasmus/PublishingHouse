using PublishingHouse.Models.PrintedEditionEntity;
using PublishingHouse.Models.UserEntity;
using System;
using System.Collections.Generic;

namespace PublishingHouse.DTOs
{
    public class CreateOrderDTO
    {
        public User User {  get; set; }
        public IEnumerable<PrintedEdition> PrintedEditions { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
