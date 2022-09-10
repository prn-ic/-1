using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Models;
using Tableware.Stores;

namespace Tableware.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
       private readonly NavigationStore _navigationStore;
       public ViewModelBase? CurrentViewModel => _navigationStore.CurrentViewModel;
       
       public MainViewModel(NavigationStore navigationStore)
       {
           _navigationStore = navigationStore;

           _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged;
       }

       private void OnCurrentViewModelChanged()
       {
            OnPropertyChanged(nameof(CurrentViewModel));
       }
    }
}
