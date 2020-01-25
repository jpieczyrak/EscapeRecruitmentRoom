using GalaSoft.MvvmLight;
using System;

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

        public MainViewModel(Func<Type, ViewModelBase> factory)
        {
            _factory = factory;
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
        }
    }
}