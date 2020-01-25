using GalaSoft.MvvmLight;
using System;

using EscapeRecruitmentRoom.Presentation.View;
using System.Reflection;
using System.Diagnostics;

using EscapeRecruitmentRoom.Core.Logic.Game;

namespace EscapeRecruitmentRoom.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel;
        private Func<Type, ViewModelBase> _factory;

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);
        }

        public string Footer { get; }

        public MainViewModel(Func<Type, ViewModelBase> factory)
        {
            _factory = factory;
            Assembly uiAssembly = Assembly.GetExecutingAssembly();
            Assembly logicAssembly = typeof(IGameManager).Assembly;
            var versionInfo = FileVersionInfo.GetVersionInfo(logicAssembly.Location);
            Footer = $"UI {uiAssembly.GetName().Version.ToString(3)}, Logic {logicAssembly.GetName().Version.ToString(3)}{Environment.NewLine}" +
                $"{versionInfo.LegalCopyright}{Environment.NewLine}" +
                $"{versionInfo.Comments}";
        }

        public void NavigateTo(View view)
        {
            switch (view)
            {
                case View.Login:
                    SelectedViewModel = _factory(typeof(LoginViewModel));

                    break;
                case View.Room:
                    SelectedViewModel = _factory(typeof(RoomViewModel));

                    break;
            }

            if (SelectedViewModel is INavigatedTo updateable)
            {
                updateable.Update();
            }
        }
    }
}