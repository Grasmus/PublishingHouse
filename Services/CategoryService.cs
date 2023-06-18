using System.Collections.Generic;
using PublishingHouse.Interfaces;
using PublishingHouse.Models.CategoryEntity;
using PublishingHouse.Repositories;

namespace PublishingHouse.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly UnitOfWork _unitOfWork;

        public CategoryService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Category> GetAll()
        {
            CategoryRepository categoryRepository = _unitOfWork.CategoryRepository;

            return categoryRepository.GetAll();
        }
    }
}
