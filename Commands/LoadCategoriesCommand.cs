using PublishingHouse.Interfaces;
using System.Windows;
using System;
using PublishingHouse.Models.CategoryEntity;
using System.Collections.Generic;

namespace PublishingHouse.Commands
{
    public class LoadCategoriesCommand : CommandBase
    {
        private readonly ICategoryService _categoryService;
        public delegate void UpdateCategoriesDelegate(IEnumerable<Category> categories);
        private readonly UpdateCategoriesDelegate _updateCategoriesDelegate;

        public LoadCategoriesCommand(UpdateCategoriesDelegate updateCategoriesDelegate, ICategoryService categoryService)
        {
            _updateCategoriesDelegate = updateCategoriesDelegate;
            _categoryService = categoryService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                IEnumerable<Category> categories = _categoryService.GetAll();

                if(categories != null)
                {
                    _updateCategoriesDelegate(categories);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
