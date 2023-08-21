using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace PublishingHouse.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public virtual void Dispose() { }

        protected bool _canNavigateBack = true;

        public bool CanNavigateBack 
        {
            get => _canNavigateBack; 
            set => _canNavigateBack = value;
        }
    }
}
