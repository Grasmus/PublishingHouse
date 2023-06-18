using PublishingHouse.Interfaces;
using PublishingHouse.ViewModels;
using System.Windows;
using System;
using PublishingHouse.Models.CategoryEntity;
using System.Collections.Generic;

namespace PublishingHouse.Commands
{
    public class LoadCategoriesCommand : CommandBase
    {
        private readonly MainPageViewModel _mainPageViewModel;
        private readonly ICategoryService _categoryService;

        public LoadCategoriesCommand(MainPageViewModel mainPageViewModel, ICategoryService categoryService)
        {
            _mainPageViewModel = mainPageViewModel;
            _categoryService = categoryService;
        }

        public override void Execute(object? parameter)
        {
            try
            {
                IEnumerable<Category> categories = _categoryService.GetAll();

                if(categories != null)
                {
                    _mainPageViewModel.UpdateCategories(categories);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
