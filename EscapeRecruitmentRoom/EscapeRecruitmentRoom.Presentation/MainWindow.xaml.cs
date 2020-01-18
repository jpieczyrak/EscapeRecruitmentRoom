using System.Windows;

using EscapeRecruitmentRoom.Presentation.ViewModel;

namespace EscapeRecruitmentRoom.Presentation
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            // todo: resolve
            MainViewModel vm = new MainViewModel();
            DataContext = vm;

            vm.SelectedViewModel = new RoomViewModel();

            InitializeComponent();
        }
    }
}
