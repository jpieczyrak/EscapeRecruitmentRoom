using Autofac;

using EscapeRecruitmentRoom.Core.Logic.Game;
using EscapeRecruitmentRoom.Presentation.ViewModel;

using GalaSoft.MvvmLight;

namespace EscapeRecruitmentRoom.Presentation.Module
{
    public class PresentationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterAssemblyModules(typeof(IGameManager).Assembly);

            builder.RegisterAssemblyTypes(typeof(MainViewModel).Assembly)
                .Where(t => t.IsSubclassOf(typeof(ViewModelBase)))
                .Named<ViewModelBase>(x => x.Name)
                .As(t => t)
                .ExternallyOwned();

            builder.RegisterType<MainWindow>().AsSelf();
        }
    }
}
