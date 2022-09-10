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
    public class EditProductCommand: CommandBase
    {
        private readonly ProductListViewModel? _viewModel;
        public EditProductCommand(ProductListViewModel? viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            NavigationStore navigationStore = new NavigationStore();
            navigationStore.CurrentViewModel = new EditProductViewModel(_viewModel);
            EditProductWindow appendProductWindow = new EditProductWindow()
            {
                DataContext = new MainViewModel(navigationStore)
            };
            appendProductWindow.Show();

        }
    }
}
