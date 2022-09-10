using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Data;
using Tableware.Models;
using Tableware.Stores;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class SearchCommand: CommandBase
    {
        private readonly ProductListViewModel? _viewModel;

        public SearchCommand(ProductListViewModel? viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if (_viewModel!.SearchBarValue == "")
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Database.EnsureCreated();
                    db.Product.Load();
                    if (_viewModel!.SelectedItem == "Все производители")
                    {
                        _viewModel!.Products = db.Product.Local.ToObservableCollection();
                        _viewModel!.SelectedProductCount = db.Product.Count();
                    }
                    else
                    {
                        var productList = db.Product.Where(x => x.ProductManufacturer == _viewModel!.SelectedItem);
                        _viewModel!.Products = new ObservableCollection<Product>(productList);
                        _viewModel!.SelectedProductCount = productList.Count();
                    }
                }

            }
            else
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {
                    db.Database.EnsureCreated();
                    db.Product.Load();
                    if (_viewModel!.SelectedItem == "Все производители")
                    {
                        var productList = db.Product.Where(x =>
                        x.ProductManufacturer!.Contains(_viewModel!.SearchBarValue!) ||
                        x.ProductProvider!.Contains(_viewModel!.SearchBarValue!) ||
                        x.ProductName!.Contains(_viewModel!.SearchBarValue!)
                        );
                        _viewModel!.Products = new ObservableCollection<Product>(productList);
                        _viewModel!.SelectedProductCount = productList.Count();
                    }
                    else
                    {
                        var productList = db.Product.Where(
                        x => x.ProductManufacturer == _viewModel!.SelectedItem).Where(x =>
                        x.ProductManufacturer!.Contains(_viewModel!.SearchBarValue!) ||
                        x.ProductProvider!.Contains(_viewModel!.SearchBarValue!) ||
                        x.ProductName!.Contains(_viewModel!.SearchBarValue!)
                        );
                        _viewModel!.Products = new ObservableCollection<Product>(productList);
                        _viewModel!.SelectedProductCount = productList.Count();
                    }
                    
                }

            }
        }
    }
}
