using System;
using System.Collections.Generic;
using SimpleInjector;
using System.Linq;
using System.Web;
using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using Supero.Data.BusinessLogic;
using SimpleInjector.Integration.Web.Mvc;
using Supero.DataBase.Persister.Common;


namespace Supero.Web.Api
{
    public static class IocConfig
    {
        // Create the container as usual.
        private static Container container = new Container();

        /// <summary>
        /// Gets the container.
        /// </summary>
        public static Container IocContainer
        {
            get
            {
                return IocConfig.container;
            }
        }

        public static void Register()
        {
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());
            container.RegisterMvcIntegratedFilterProvider();

            // Extension methods from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            // Register services (Services register repositories inside).
            Supero.Data.BusinessLogic.ServiceConfiguration.Register(container);

            container.RegisterPerWebRequest<SuperoDbContext>(() => new SuperoDbContext());

            // Register all interfaces we need to use here.
            RegisterServices();
  
            // Verify the container configuration.
            container.Verify();

            // Register the dependency resolver.
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjector.Integration.WebApi.SimpleInjectorWebApiDependencyResolver(container);
        }


        private static void RegisterServices()
        {
            container.Register<Supero.Data.BusinessLogic.Interface.ITaskList, Supero.Data.BusinessLogic.Implementor.TaskList>();

        }
    }
}