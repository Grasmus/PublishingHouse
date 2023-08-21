using PublishingHouse.Models.CategoryEntity;
using PublishingHouse.Models.OrderEntity;
using System;
using System.Collections.Generic;

namespace PublishingHouse.Models.PrintedEditionEntity
{
    public class PrintedEdition
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public byte[]? Cover { get; set; }
        public string? Description { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public DateTime Updated { get; set; }
        public bool IsAvailable { get; set; }
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }

        public ICollection<Order> Orders { get; set; }

        public PrintedEdition() { }

        public PrintedEdition(
            int id,
            string author,
            string genre,
            byte[]? cover,
            string title,
            string? description,
            string language,
            decimal price,
            DateTime releaseDate,
            DateTime updated,
            bool isAvailable,
            int categoryId)
        {
            Id = id;
            Author = author;
            Genre = genre;
            Cover = cover;
            Title = title;
            Description = description;
            Language = language;
            Price = price;
            ReleaseDate = releaseDate;
            Updated = updated;
            IsAvailable = isAvailable;
            CategoryId = categoryId;
        }
    }
}
