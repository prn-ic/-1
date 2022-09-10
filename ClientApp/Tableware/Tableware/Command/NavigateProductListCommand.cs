using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Stores;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class NavigateProductListCommand: CommandBase
    {
        private readonly NavigationStore? _navigationStore;

        public NavigateProductListCommand(NavigationStore? navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            
            _navigationStore!.CurrentViewModel = new ProductListViewModel(_navigationStore);
        }
    }
}
