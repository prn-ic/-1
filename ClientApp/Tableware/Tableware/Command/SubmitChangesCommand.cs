using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Data;
using Tableware.Models;
using Tableware.ViewModels;

namespace Tableware.Command
{
    /// <summary>
    /// Данный класс предназначен для изменения обьекта продукта. 
    /// Служит как команда для кнопки из EditProductView 
    /// <param name="_viewModel">Получаем View для дальнейшего взаимодействия</param>
    /// </summary>
    public class SubmitChangesCommand: CommandBase
    {
        private readonly EditProductViewModel? _viewModel;
        public SubmitChangesCommand(EditProductViewModel? viewModel)
        {
            _viewModel = viewModel;
        }

        public override void Execute(object parameter)
        {
            var path = "";
            var filePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0-windows", "");
            var imagePath = _viewModel!.ProductPhoto!.Split('\\')[_viewModel!.ProductPhoto.Split('\\').Length - 1];

            if (_viewModel?.ProductPrevPhoto != _viewModel?.ProductPhoto)
            {
                LoadImage(_viewModel?.ProductPhoto!);
                path = $"/Resources/Images/{imagePath}";
            }
            else
            {
                path = _viewModel?.ProductPhoto;
            }
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
                ProductPhoto = path
            };

            using (ApplicationDbContext db = new ApplicationDbContext())
            {
                
                db.Update(product);
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

