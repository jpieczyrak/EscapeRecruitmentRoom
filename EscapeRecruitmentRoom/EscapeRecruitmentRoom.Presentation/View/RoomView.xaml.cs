using System.Windows;
using System.Windows.Controls;

namespace EscapeRecruitmentRoom.Presentation.View
{
    public partial class RoomView : UserControl
    {
        public RoomView()
        {
            InitializeComponent();
        }

        private void OnLoaded(object sender, RoutedEventArgs e)
        {
            ConsoleInputTextBox.Focus();
        }
    }
}
