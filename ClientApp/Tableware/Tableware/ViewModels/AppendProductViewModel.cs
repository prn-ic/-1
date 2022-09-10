using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Tableware.Command;
using Tableware.Data;
using Tableware.Models;

namespace Tableware.ViewModels
{
    public class AppendProductViewModel: ViewModelBase
    {
        private ProductListViewModel? _productListViewModel;
        private string? _productName;
        private string? _productSelectCategory;
        private int _productQuantityInStock;
        private string? _productUnit;
        private int _productCost;
        private string? _productProvider;
        private string? _productDescription;
        private string? _productPhoto;
        private string? _productArticleNumber;
        private string? _productManufacturer;
        private ObservableCollection<string>? _category;
        public string? ProductArticleNumber
        {
            get => _productArticleNumber;
            set
            {
                _productArticleNumber = value;
                OnPropertyChanged(nameof(ProductArticleNumber));
            }
        }
        public string? ProductName
        {
            get => _productName;
            set
            {
                _productName = value;
                OnPropertyChanged(nameof(ProductName));
            }
        }
        public string? ProductSelectCategory
        {
            get => _productSelectCategory;
            set
            {
                _productSelectCategory = value;
                OnPropertyChanged(nameof(ProductSelectCategory));
            }
        }

        public int ProductQuantityInStock
        {
            get => _productQuantityInStock;
            set 
            { 
                _productQuantityInStock = value;
                OnPropertyChanged(nameof(ProductQuantityInStock));
            }
        }
        public string? ProductUnit
        {
            get => _productUnit;
            set
            {
                _productUnit = value;
                OnPropertyChanged(nameof(ProductUnit));
            }
        }
        public int ProductCost
        {
            get => _productCost;
            set
            {
                _productCost = value;
                OnPropertyChanged(nameof(ProductCost));
            }
        }
        public string? ProductProvider
        {
            get => _productProvider;
            set
            {
                _productProvider = value;
                OnPropertyChanged(nameof(ProductProvider));
            }
        }
        public string? ProductDescription
        {
            get => _productDescription;
            set
            {
                _productDescription = value;
                OnPropertyChanged(nameof(ProductDescription));
            }
        }
        public string? ProductManufacturer
        {
            get => _productManufacturer;
            set
            {
                _productManufacturer = value;
                OnPropertyChanged(nameof(ProductManufacturer));
            }
        }
        public string? ProductPhoto
        {
            get => _productPhoto;
            set
            {
                _productPhoto = value;
                OnPropertyChanged(nameof(ProductPhoto));
            }
        }
        public ObservableCollection<string>? Category
        {
            get => _category;
            set
            {
                _category = value;
                OnPropertyChanged(nameof(Category));
            }
        }
        public ProductListViewModel? ProductListViewModel
        {
            get => _productListViewModel;
            set
            {
                _productListViewModel = value;
                OnPropertyChanged(nameof(ProductListViewModel));
            }
        }

        public ICommand? LoadProductImageCommand { get; }
        public ICommand? CreateProductCommand { get; }

        public AppendProductViewModel(ProductListViewModel? productListViewModel)
        {
            ProductListViewModel = productListViewModel;
            LoadProductImageCommand = new LoadProductImageCommand(this);
            CreateProductCommand = new CreateProductCommand(this);
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated();
                db.Product.Load();

                Category = new ObservableCollection<string>(db.Product.Local.Select(x => x.ProductCategory).Distinct()!);  
            }
                
        }
    }
}
