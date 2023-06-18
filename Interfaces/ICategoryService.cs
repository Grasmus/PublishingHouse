using PublishingHouse.Models.CategoryEntity;
using System.Collections.Generic;

namespace PublishingHouse.Interfaces
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
    }
}