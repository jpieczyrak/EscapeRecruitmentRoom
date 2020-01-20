using System.Windows;

using Autofac;

using EscapeRecruitmentRoom.Core.Logic.Game;
using EscapeRecruitmentRoom.Presentation.ViewModel;

namespace EscapeRecruitmentRoom.Presentation
{
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            var builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(typeof(MainViewModel).Assembly);

            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var window = scope.Resolve<MainWindow>();
                window.Show();
            }
        }
    }
}
