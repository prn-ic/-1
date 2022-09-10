using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tableware.Stores;
using Tableware.ViewModels;

namespace Tableware.Command
{
    public class NavigateLoginCommand: CommandBase
    {
        private readonly NavigationStore? _navigationStore;

        public NavigateLoginCommand(NavigationStore? navigationStore)
        {
            _navigationStore = navigationStore;
        }

        public override void Execute(object parameter)
        {
            _navigationStore!.CurrentViewModel = new LoginViewModel(_navigationStore);
        }
    }
}
