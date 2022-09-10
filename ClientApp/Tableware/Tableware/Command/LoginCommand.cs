using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Data;
using Tableware.Models;
using Tableware.Stores;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class LoginCommand: CommandBase
    {
        private readonly NavigationStore? _navigationStore;
        private readonly LoginViewModel? _viewModel;
        public LoginCommand(LoginViewModel? viewModel,NavigationStore? navigationStore)
        {
            _viewModel = viewModel;
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            using (ApplicationDbContext _db = new ApplicationDbContext())
            {
                _db.Database.EnsureCreated();
                _db.User.Load();
                var user = _db.User.FirstOrDefault(x => x.UserLogin == _viewModel!.UserLogin && x.UserPassword == _viewModel!.Password);
                if (user == null)
                {
                    _viewModel!.AuthError = _viewModel.ErrorCounter < 4?"Ошибка: Неверные данные!": "Пройдите капчу";
                    _viewModel.ErrorCounter += 1;
                }
                else
                {
                    _navigationStore!.CurrentViewModel = new ProductListViewModel(_navigationStore, user);
                }
            }
            
        }
    }
}
