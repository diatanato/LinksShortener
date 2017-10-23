using System;
using System.Data.Entity;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;

using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace LinkShortener
{
    using Common.Interfaces.Services;

    using Data;
    using Data.Generators;
    using Data.Generators.Interfaces;
    using Data.Repositories;
    using Data.Repositories.Interfaces;
    using Data.Services;

    public class InjectionConfig
    {
        public static void RegisterControllers()
        {
            RegisterMvcControllers();
            RegisterApiControllers();
        }

        private static void RegisterMvcControllers()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            RegisterData(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        private static void RegisterApiControllers()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            RegisterData(container);

            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);
            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
        }

        private static void RegisterData(Container container)
        {
            container.Register<ILinksService, LinksService>(Lifestyle.Scoped);

            container.Register<ILinksRepository, LinksRepository>(Lifestyle.Scoped);
            container.Register<IUsersRepository, UsersRepository>(Lifestyle.Scoped);
            container.Register<IClicksRepository, ClicksRepository>(Lifestyle.Scoped);
            container.Register<IHashGenerator, HashGenerator>(Lifestyle.Scoped);

            container.Register<DbContext>(() => new LinksDataContext(), Lifestyle.Scoped);
        }
    }
}