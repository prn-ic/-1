using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Data;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class ProductListSortCommand: CommandBase
    {
        private readonly ProductListViewModel? _viewModel;
        public ProductListSortCommand(ProductListViewModel? viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            using (ApplicationDbContext _db = new ApplicationDbContext())
            {
                _db.Database.EnsureCreated();
                _db.User.Load();
            }

        }
    }
}
