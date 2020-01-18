using GalaSoft.MvvmLight;

namespace EscapeRecruitmentRoom.Presentation.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        private ViewModelBase _selectedViewModel;

        public ViewModelBase SelectedViewModel
        {
            get => _selectedViewModel;
            set => Set(ref _selectedViewModel, value);
        }

        public MainViewModel()
        {
        }
    }
}