using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Models;
using Tableware.Stores;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class SortByCostCommand : CommandBase
    {
        private readonly ProductListViewModel? _viewModel;

        public SortByCostCommand(ProductListViewModel? viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if (_viewModel?.SortByCostText == "Убыванию")
            {
                _viewModel.SortByCostText = "Возрастанию";
                var productList = _viewModel?.Products!.OrderByDescending(x => x.ProductCost);
                _viewModel!.Products = new ObservableCollection<Product>(productList!);
                _viewModel!.SelectedProductCount = productList!.Count();
            }
            else
            {
                _viewModel!.SortByCostText = "Убыванию";
                var productList = _viewModel?.Products!.OrderBy(x => x.ProductCost);
                _viewModel!.Products = new ObservableCollection<Product>(productList!);
                _viewModel!.SelectedProductCount = productList!.Count();
            }
        }
    }
}
