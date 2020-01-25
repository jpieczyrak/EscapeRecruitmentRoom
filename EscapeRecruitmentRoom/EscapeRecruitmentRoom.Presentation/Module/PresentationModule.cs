using System;

using Autofac;

using EscapeRecruitmentRoom.Core.Logic.Game;
using EscapeRecruitmentRoom.Presentation.View;
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
            builder.RegisterType<ViewNavigator>().As<IViewNavigator>().SingleInstance().ExternallyOwned();

            builder.RegisterAssemblyTypes(typeof(MainViewModel).Assembly)
                .Where(t => t.IsSubclassOf(typeof(ViewModelBase)))
                .Named<ViewModelBase>(x => x.Name)
                .As(t => t)
                .SingleInstance()
                .ExternallyOwned();

            builder.Register<Func<Type, ViewModelBase>>(c =>
            {
                var context = c.Resolve<IComponentContext>();
                return type => context.ResolveNamed<ViewModelBase>(type.Name);
            });

            builder.Register(c =>
                {
                    IComponentContext context = c.Resolve<IComponentContext>();

                    return new MainViewModel(context.Resolve<Func<Type, ViewModelBase>>());
                })
                .SingleInstance()
                .ExternallyOwned()
                .Named<ViewModelBase>(nameof(MainViewModel))
                .As<MainViewModel>();

            builder.RegisterType<MainWindow>().SingleInstance().AsSelf();
        }
    }
}
