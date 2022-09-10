using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tableware.Command;
using Tableware.Data;
using Tableware.Models;
using Tableware.Stores;
using System.Windows;

namespace Tableware.ViewModels
{
    public class ProductListViewModel: ViewModelBase
    {
        private string? _name;
        private string? _sortByCostText;
        private User? _user;
        private ObservableCollection<Product>? _products;
        private ObservableCollection<string>? _manufacturers;
        private string? _selectedItem;
        private string? _searchBarValue;
        private int _allProductCount;
        private int _selectedProductCount;
        private bool _isAdmin;
        private Visibility? _adminPanelVisibility;
        private Product? _selectedProduct;
        public string? Name {
            get => _name;
            set {
                _name = value;
                OnPropertyChanged(nameof(Name));
            } 
        }

        public string? SortByCostText
        {
            get => _sortByCostText;
            set
            {
                _sortByCostText = value;
                OnPropertyChanged(nameof(SortByCostText));
            }
        }
        
        public User? User
        {
            get => _user;
            set
            {
                _user = value;
                OnPropertyChanged(nameof(User));
            }
        }

        public ObservableCollection<Product>? Products {
            get => _products;
            set
            {
                _products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        public ObservableCollection<string>? Manufacturers
        {
            get => _manufacturers;
            set
            {
                _manufacturers = value;
                OnPropertyChanged(nameof(Manufacturers));
            }
        }

        public string? SelectedItem
        {
            get => _selectedItem;
            set
            {
                
                _selectedItem = value;
                if (SelectedItem == "Все производители")
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        db.Database.EnsureCreated();
                        db.Product.Load();
                        Products = db.Product.Local.ToObservableCollection();
                        AllProductCount = db.Product.Count();
                        SelectedProductCount = db.Product.Count();
                    }

                }
                else
                {
                    using (ApplicationDbContext db = new ApplicationDbContext())
                    {
                        db.Database.EnsureCreated();
                        db.Product.Load();
                        Products = new ObservableCollection<Product>(db.Product.Where(x => x.ProductManufacturer == SelectedItem));
                        AllProductCount = db.Product.Count();
                        SelectedProductCount = Products.Count();
                    }
                    
                }


                SortByCostText = "Убыванию";
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        
        public string? SearchBarValue
        {
            get => _searchBarValue;
            set
            {
                _searchBarValue = value;
                OnPropertyChanged(nameof(SearchBarValue));
            }
        }

        public int AllProductCount
        {
            get => _allProductCount;
            set
            {
                _allProductCount = value;
                OnPropertyChanged(nameof(AllProductCount));
            }
        }
        
        public int SelectedProductCount
        {
            get => _selectedProductCount;
            set
            {
                _selectedProductCount = value;
                OnPropertyChanged(nameof(SelectedProductCount));
            }
        }
        
        public bool IsAdmin
        {
            get => _isAdmin;
            set
            {
                _isAdmin = value;
                OnPropertyChanged(nameof(IsAdmin));
            }
        }
        
        public Visibility? AdminPanelVisibility
        {
            get => _adminPanelVisibility;
            set
            {
                _adminPanelVisibility = value;
                OnPropertyChanged(nameof(AdminPanelVisibility));
            }
        }
        public Product? SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));
            }
        }
        public ICommand? SearchCommand { get; }
        public ICommand? NavigateLoginCommand { get; }
        public ICommand? SortByCostCommand { get; }
        public ICommand? RemoveProductCommand { get; }
        public ICommand? AddProductCommand { get; }
        public ICommand? EditProductCommand { get; }

        public void UpdateData()
        {
            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                SortByCostText = "Убыванию";
                db.Database.EnsureCreated();
                db.Product.Load();
                Products = db.Product.Local.ToObservableCollection();

                Manufacturers = new ObservableCollection<string>(db.Product.Local.Select(x => x.ProductManufacturer).Distinct()!);
                Manufacturers.Insert(0, "Все производители");
                SelectedItem = Manufacturers[0];

                AllProductCount = db.Product.Count();
                SelectedProductCount = db.Product.Count();
            }
        }

        public ProductListViewModel(NavigationStore navigationStore, User user = null!)
        {
            SortByCostText = "Убыванию";
            SearchCommand = new SearchCommand(this);
            SortByCostCommand = new SortByCostCommand(this);
            NavigateLoginCommand = new NavigateLoginCommand(navigationStore);
            RemoveProductCommand = new RemoveProductCommand(this);
            User = user;
            IsAdmin = user.UserRole == 3 ? true : false;
            AdminPanelVisibility = IsAdmin ? Visibility.Visible : Visibility.Hidden;
            Name = $"{user!.UserSurname!} {user!.UserName!} {user!.UserPatronymic!}";
            AddProductCommand = new AddProductCommand(this);
            EditProductCommand = new EditProductCommand(this);
            

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Database.EnsureCreated();
                db.Product.Load();
                Products = db.Product.Local.ToObservableCollection();

                Manufacturers = new ObservableCollection<string>(db.Product.Local.Select(x => x.ProductManufacturer).Distinct()!);
                Manufacturers.Insert(0, "Все производители");

                AllProductCount = db.Product.Count();
                SelectedProductCount = db.Product.Count();
            }

        }
    }
}
