using System.Windows;

using Autofac;

using EscapeRecruitmentRoom.Presentation.ViewModel;

namespace EscapeRecruitmentRoom.Presentation
{
    public partial class App : Application
    {
        private MainWindow _window;

        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(MainViewModel).Assembly);

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                _window = scope.Resolve<MainWindow>();
                _window.Show();
            }
        }

        protected override void OnExit(ExitEventArgs e)
        {
            if ((_window.DataContext as MainViewModel)?.SelectedViewModel is RoomViewModel vm)
            {
                vm.Manager.Exit();
            }
            base.OnExit(e);
        }
    }
}
