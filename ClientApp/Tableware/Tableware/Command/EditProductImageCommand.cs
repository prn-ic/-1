using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class EditProductImageCommand: CommandBase
    {
        private readonly EditProductViewModel? _viewModel;
        public EditProductImageCommand(EditProductViewModel? appendProductViewModel)
        {
            _viewModel = appendProductViewModel;
        }

        public override async void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
               
                var filePath = AppDomain.CurrentDomain.BaseDirectory.Replace("\\bin\\Debug\\net6.0-windows", "");
                var imagePath = _viewModel!.ProductPhoto!.Split('/')[_viewModel!.ProductPhoto.Split('/').Length - 1];
                

                _viewModel!.ProductPhoto = openFileDialog.FileName;
                
            }
        }
    }
}
