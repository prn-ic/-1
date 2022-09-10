using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Stores;
using Tableware.ViewModels;
using Tableware.Windows;

namespace Tableware.Command
{
    public class AddProductCommand: CommandBase
    {
        private readonly ProductListViewModel? _viewModel;
        public AddProductCommand(ProductListViewModel? viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new AppendProductViewModel(_viewModel);
            AppendProductWindow appendProductWindow = new AppendProductWindow()
            { 
                DataContext = new MainViewModel(navigationStore) 
            };
            appendProductWindow.Show();

        }
    }
}
