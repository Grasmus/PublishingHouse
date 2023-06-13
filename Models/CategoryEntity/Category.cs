using PublishingHouse.Models.PrintedEditionEntity;
using System.Collections.Generic;

namespace PublishingHouse.Models.CategoryEntity
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<PrintedEdition> PrintedEditions { get; set; }

        public Category() { }

        public Category(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
