using EscapeRecruitmentRoom.Presentation.ViewModel;

namespace EscapeRecruitmentRoom.Presentation.View
{
    public class ViewNavigator : IViewNavigator
    {
        private readonly MainViewModel _viewModel;

        public ViewNavigator(MainViewModel viewModel) => _viewModel = viewModel;

        public void NavigateTo(ViewModel.View view) => _viewModel.NavigateTo(view);
    }
}
