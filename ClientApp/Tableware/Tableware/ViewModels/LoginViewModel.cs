using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Tableware.Command;
using Tableware.Stores;

namespace Tableware.ViewModels
{
    public class LoginViewModel: ViewModelBase
    {
        private string _authError;
        public string AuthError
        {
            get => _authError;
            set
            {
                _authError = value;
                OnPropertyChanged(nameof(AuthError));
            }
        }
        public int _errorCounter;
        public int ErrorCounter
        {
            get => _errorCounter;
            set
            {
                _errorCounter = value;
                OnPropertyChanged(nameof(ErrorCounter));
            }
        }
        private string _userlogin;
        public string UserLogin
        {
            get => _userlogin;
            set
            {
                _userlogin = value;
                OnPropertyChanged(nameof(UserLogin));
            }
        }
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }
        public ICommand? LoginCommand { get; }

        public LoginViewModel(NavigationStore navigationStore)
        {
            LoginCommand = new LoginCommand(this, navigationStore);
        }
    }
}
