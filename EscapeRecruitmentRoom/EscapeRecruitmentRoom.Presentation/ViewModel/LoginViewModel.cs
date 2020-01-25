using EscapeRecruitmentRoom.Core.Logic.Account;
using EscapeRecruitmentRoom.Presentation.View;

using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;

namespace EscapeRecruitmentRoom.Presentation.ViewModel
{
    public class LoginViewModel : ViewModelBase
    {
        private readonly ILoginService _loginService;
        private readonly IViewNavigator _navigator;
        private string _loginText;
        private string _passwordText;

        public LoginViewModel(ILoginService loginService, IViewNavigator navigator)
        {
            _loginService = loginService;
            _navigator = navigator;
            Login = new RelayCommand(LoginImpl);
        }

        public string LoginText
        {
            get => _loginText;
            set => this.Set(ref _loginText, value);
        }

        public string PasswordText
        {
            get => _passwordText;
            set => this.Set(ref _passwordText, value);
        }

        public string Title => "Please enter credentials";

        public RelayCommand Login { get; }

        private void LoginImpl()
        {
            if (_loginService.Authorize(LoginText, PasswordText))
            {
                _navigator.NavigateTo(View.Room);
            }
        }
    }
}
