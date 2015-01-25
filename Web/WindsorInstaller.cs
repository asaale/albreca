using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Web.Mvc;
using Albreca.Common.Interfaces.Marker;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Albreca.Web
{
    public class WindsorInstaller : IWindsorInstaller
    {
        private readonly List<Type> _typesToRegister = new List<Type>()
        {
            typeof(IBusinessLogic),
            typeof(IRepository<>),
            typeof(IService)
        };

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient());

            foreach (var type in _typesToRegister)
            {
                container.Register(Types
                            .FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory))
                           .BasedOn(type)
                            .WithService
                            .FromInterface()
                            .LifestylePerWebRequest());
            }
        }

        static public string AssemblyDirectory
        {
            get
            {
                var codeBase = Assembly.GetExecutingAssembly().CodeBase;

                var uri = new UriBuilder(codeBase);

                var path = Uri.UnescapeDataString(uri.Path);

                return Path.GetDirectoryName(path);
            }
        }
    }
}