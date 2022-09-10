using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Tableware.Data;
using Tableware.Models;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class CreateProductCommand : CommandBase
    {
        private readonly AppendProductViewModel? _viewModel;
        public CreateProductCommand(AppendProductViewModel? viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var imagePath = _viewModel?.ProductPhoto! != null?_viewModel?.ProductPhoto!.Split('\\')[_viewModel!.ProductPhoto!.Split('\\').Length - 1]: "default.png";
            LoadImage(_viewModel?.ProductPhoto!);
            Product? product = new Product()
            {
                ProductArticleNumber = _viewModel?.ProductArticleNumber,
                ProductName = _viewModel?.ProductName,
                ProductCategory = _viewModel?.ProductSelectCategory,
                ProductCost = _viewModel!.ProductCost,
                ProductUnit = _viewModel?.ProductUnit,
                ProductProvider = _viewModel?.ProductProvider,
                ProductDescription = _viewModel?.ProductDescription,
                ProductManufacturer = _viewModel?.ProductManufacturer,
                ProductDiscountAmount = 0,
                ProductMaxDiscount = 0,
                ProductQuantityInStock = _viewModel!.ProductQuantityInStock,
                ProductPhoto = $"/Resources/Images/{imagePath}"
            };

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                db.Product.Add(product);
                db.SaveChanges();
            }
            _viewModel?.ProductListViewModel?.UpdateData();
        }

        public async void LoadImage(string path)
        {
            FileStream? fileStream = null!;
            try
            {
                fileStream = new FileStream(path, FileMode.Open);
                byte[] buffer = new byte[fileStream.Length];
                await fileStream.ReadAsync(buffer, 0, buffer.Length);

                fileStream.Close();
                fileStream.Dispose();
                var filePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0-windows", "");
                var imagePath = path.Split('\\')[path.Split('\\').Length - 1];
                fileStream = new FileStream($"{filePath}/Resources/Images/{imagePath}", FileMode.Create);
                await fileStream.WriteAsync(buffer, 0, buffer.Length);
            }
            catch (Exception ex)
            {
                var message = ex.ToString();

            }
            finally
            {
                fileStream?.Close();
            }

            
        }
    }
}
