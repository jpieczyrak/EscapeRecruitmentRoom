using System.Windows.Controls;

using EscapeRecruitmentRoom.Presentation.ViewModel;

namespace EscapeRecruitmentRoom.Presentation.View
{
    public partial class RoomView : UserControl
    {
        public RoomView()
        {
            InitializeComponent();
            DataContext = new RoomViewModel();
        }
    }
}
