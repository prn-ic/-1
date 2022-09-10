using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class LoadProductImageCommand : CommandBase
    {
        private readonly AppendProductViewModel? _viewModel;
        public LoadProductImageCommand(AppendProductViewModel? appendProductViewModel)
        {
            _viewModel = appendProductViewModel;
        }

        public override async void Execute(object parameter)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";

            if (openFileDialog.ShowDialog() == true)
            {
                _viewModel!.ProductPhoto = openFileDialog.FileName;
            }
        }
    }
}
