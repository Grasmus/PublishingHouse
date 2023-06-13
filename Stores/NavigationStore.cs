using PublishingHouse.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublishingHouse.Stores
{
    public class NavigationStore
    {
        private List<ViewModelBase> _previousViews = new List<ViewModelBase>();
        private ViewModelBase _currentView;

        public ViewModelBase CurrentView 
        { 
            get { return _currentView; } 
            set 
            {
                _previousViews.Add(_currentView);
                _currentView = value;

                OnCurrentViewModelChanged();
            } 
        }

        public void GoBack()
        {
            if(_previousViews.Count != 0)
            {
                _currentView?.Dispose();
                _currentView = _previousViews.Last();
                _previousViews.Remove(_previousViews.Last());

                OnCurrentViewModelChanged();
            }
        }

        public event Action CurrentViewModelChanged;

        private void OnCurrentViewModelChanged()
        {
            CurrentViewModelChanged?.Invoke();
        }
    }
}
