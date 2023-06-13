using PublishingHouse.Models.OrderEntity;
using System;
using System.Collections.Generic;

namespace PublishingHouse.Models.UserEntity
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; } 

        public string Login { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; }

        public DateTime CreatedDate { get; set; }

        public bool IsBlacklisted { get; set; }
        public virtual ICollection<Order>? Orders { get; set; }

        public User()
        {

        }

        public User(int id,
            string firstName,
            string lastName,
            string login,
            string passwordHash,
            string role,
            bool isBlacklisted,
            DateTime createdDate,
            ICollection<Order>? orders)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Login = login;
            PasswordHash = passwordHash;
            Role = role;
            IsBlacklisted = isBlacklisted;
            CreatedDate = createdDate;
            Orders = orders;
        }
    }
}
