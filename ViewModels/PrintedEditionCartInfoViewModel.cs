using PublishingHouse.Commands;
using PublishingHouse.Models.PrintedEditionEntity;
using System.Windows.Input;

namespace PublishingHouse.ViewModels
{
    public class PrintedEditionCartInfoViewModel : ViewModelBase
    {
        private readonly PrintedEdition _printedEdition;

        public PrintedEdition PrintedEdition => _printedEdition;
        public string Title => _printedEdition.Title;
        public string Genre => _printedEdition.Genre;
        public string Language => _printedEdition.Language;
        public decimal Price => _printedEdition.Price;
        public string Author => _printedEdition.Author;
        public byte[]? Cover => _printedEdition.Cover;

        public ICommand RemoveBookCommand { get; }

        public PrintedEditionCartInfoViewModel(MainPageViewModel mainPageViewModel, PrintedEdition printedEdition)
        {
            _printedEdition = printedEdition;
            RemoveBookCommand = new RemoveBookFromOrderCommand(mainPageViewModel, this);
;       }
    }
}
