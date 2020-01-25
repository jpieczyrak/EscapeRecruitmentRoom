using System;
using System.Windows;

using EscapeRecruitmentRoom.Presentation.ViewModel;

using GalaSoft.MvvmLight;

namespace EscapeRecruitmentRoom.Presentation
{
    public partial class MainWindow : Window
    {
        public MainWindow(Func<Type, ViewModelBase> factory)
        {
            MainViewModel mainViewModel = factory(typeof(MainViewModel)) as MainViewModel;
            DataContext = mainViewModel;
            mainViewModel.NavigateTo(ViewModel.View.Login);
            InitializeComponent();
        }
    }
}
