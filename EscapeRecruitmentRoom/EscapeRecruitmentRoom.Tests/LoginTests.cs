using Autofac;

using EscapeRecruitmentRoom.Core.Logic.Account;
using EscapeRecruitmentRoom.Presentation.ViewModel;

using Xunit;

namespace EscapeRecruitmentRoom.Tests
{
    public class LoginTests
    {
        [Fact]
        public void ShouldProperlyResolveLoginService()
        {
            // given
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(MainViewModel).Assembly);
            var container = builder.Build();

            // when
            var service = container.Resolve<ILoginService>();

            // then
            Assert.NotNull(service);
        }

        [Fact]
        public void ShouldAuthorizeBaseUser()
        {
            // given
            var builder = new ContainerBuilder();
            builder.RegisterAssemblyModules(typeof(MainViewModel).Assembly);
            var container = builder.Build();
            var service = container.Resolve<ILoginService>();
            string login = "Code Byte";
            string password = "It's a trap!";

            // when
            bool logged = service.Authorize(login, password);

            // then
            Assert.True(logged);
        }
    }
}
