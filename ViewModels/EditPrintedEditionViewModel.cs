using Microsoft.IdentityModel.Tokens;
using PublishingHouse.Models.CategoryEntity;
using PublishingHouse.Models.PrintedEditionEntity;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System;
using PublishingHouse.Commands;
using PublishingHouse.Interfaces;
using System.Collections.Generic;
using System.ComponentModel;

namespace PublishingHouse.ViewModels
{
    public class EditPrintedEditionViewModel : ViewModelBase
    {
        private readonly PrintedEdition _printedEdition;

        public PrintedEdition PrintedEdition
        {
            get => _printedEdition;
        }

        public string Title
        {
            get => _printedEdition.Title;

            set
            {
                _printedEdition.Title = value;

                OnPropertyChanged();
            }
        }

        public string? Description
        {
            get => _printedEdition.Description;

            set
            {
                _printedEdition.Description = value;

                OnPropertyChanged();
            }
        }

        public string Language
        {
            get => _printedEdition.Language;

            set 
            {
                _printedEdition.Language = value;
                
                OnPropertyChanged();
            }
        }

        public string Price
        {
            get => Convert.ToString(_printedEdition.Price);

            set
            {
                _printedEdition.Price = Convert.ToDecimal(value.IsNullOrEmpty() ? 0.0 : value);

                OnPropertyChanged();
            }
        }

        public DateTime ReleaseDate
        {
            get => _printedEdition.ReleaseDate;

            set 
            {
                _printedEdition.ReleaseDate = value;

                OnPropertyChanged();
            }
        }

        public DateTime Updated
        {
            get => _printedEdition.Updated;

            set 
            {
                _printedEdition.Updated = value;

                OnPropertyChanged();
            }
        }

        public bool IsAvailable
        {
            get => _printedEdition.IsAvailable;

            set 
            {
                _printedEdition.IsAvailable = value;

                OnPropertyChanged();
            }
        }

        public string Author
        {
            get => _printedEdition.Author;

            set 
            {
                _printedEdition.Author = value;

                OnPropertyChanged();
            }
        }

        public string Genre
        {
            get => _printedEdition.Genre;

            set 
            {
                _printedEdition.Genre = value;

                OnPropertyChanged();
            }
        }

        public byte[]? Cover
        {
            get => _printedEdition.Cover;

            set 
            {
                _printedEdition.Cover = value;

                OnPropertyChanged();
            }
        }

        public Category? Category
        {
            get => _printedEdition.Category;

            set 
            {
                _printedEdition.Category = value;

                OnPropertyChanged();
            }
        }

        private ObservableCollection<Category> _categories;

        public ObservableCollection<Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    _categories = new ObservableCollection<Category>();
                }

                return _categories;
            }

            set
            {
                _categories = value;
            }
        }

        ICommand LoadCategoriesCommand { get; }
        public ICommand LoadImageCommand { get; }
        public ICommand NavigateBackCommand { get; }
        public ICommand UpdatePrintedEditionCommand { get; }

        public EditPrintedEditionViewModel(
            PrintedEdition printedEdition,
            ICategoryService categoryService,
            INavigationService navigationService,
            IPrintedEditionService printedEditionService)
        {
            _printedEdition = printedEdition;
            LoadCategoriesCommand = new LoadCategoriesCommand(UpdateCategories, categoryService);
            NavigateBackCommand = new NavigateBackCommand(this, navigationService);
            LoadImageCommand = new LoadImageCommand(UpdateCover);
            UpdatePrintedEditionCommand = new UpdatePrintedEditionCommand(this, printedEditionService);

            LoadCategoriesCommand.Execute(null);

            PropertyChanged += OnBookEdited;
        }

        private void OnBookEdited(object? sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(Title) ||
                e.PropertyName == nameof(Description) ||
                e.PropertyName == nameof(Language) ||
                e.PropertyName == nameof(Price) ||
                e.PropertyName == nameof(ReleaseDate) ||
                e.PropertyName == nameof(Updated) ||
                e.PropertyName == nameof(IsAvailable) ||
                e.PropertyName == nameof(Author) ||
                e.PropertyName == nameof(Genre) ||
                e.PropertyName == nameof(Cover) ||
                e.PropertyName == nameof(Category))
            {
                _canNavigateBack = false;
            }
        }

        public void UpdateCategories(IEnumerable<Category> categories)
        {
            Categories.Clear();

            foreach (var category in categories)
            {
                Categories.Add(category);
            }
        }

        public void UpdateCover(byte[]? cover)
        {
            Cover = cover;
        }
    }
}
