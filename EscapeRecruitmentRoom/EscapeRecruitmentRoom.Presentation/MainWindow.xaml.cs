using System.Windows;

using EscapeRecruitmentRoom.Presentation.ViewModel;

namespace EscapeRecruitmentRoom.Presentation
{
    public partial class MainWindow : Window
    {
        public MainWindow(MainViewModel mainViewModel, RoomViewModel roomViewModel)
        {
            DataContext = mainViewModel;
            mainViewModel.SelectedViewModel = roomViewModel;

            InitializeComponent();
        }
    }
}
