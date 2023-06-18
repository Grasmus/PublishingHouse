using PublishingHouse.Models.CategoryEntity;
using System;

namespace PublishingHouse.DTOs
{
    public class CreatePrintedEditionDTO
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public byte[]? Cover { get; set; }
        public string? Description { get; set; }
        public string Language { get; set; }
        public decimal Price { get; set; }
        public DateTime ReleaseDate { get; set; }
        public bool? IsAvailable { get; set; }
        public Category? Category { get; set; }
    }
}
