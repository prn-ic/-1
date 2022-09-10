using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Data;
using Tableware.Models;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class RemoveProductCommand: CommandBase
    {
        private readonly ProductListViewModel? _viewModel;
        public RemoveProductCommand(ProductListViewModel? viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            using (ApplicationDbContext _db = new ApplicationDbContext())
            {
                _db.Database.EnsureCreated();

                _db.Product.Remove(_db.Product.FirstOrDefault(x => x.ProductArticleNumber == parameter.ToString())!);
                _db.SaveChanges();

                _db.Product.Load();
                _viewModel!.Products = _db.Product.Local.ToObservableCollection();
                _viewModel!.AllProductCount = _db.Product.Count();
                _viewModel!.SelectedProductCount = _viewModel!.SelectedProductCount - 1;
                _viewModel!.SortByCostText = "Убыванию";
            }

        }
    }
}
