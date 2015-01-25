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
        private List<Type> _typesToRegister = new List<Type>()
        {
            typeof(IBusinessLogic),
            typeof(IRepository)
        };

        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
                                .BasedOn<IController>()
                                .LifestyleTransient());

            container.Register(Types
                              .FromAssemblyInDirectory(new AssemblyFilter(AssemblyDirectory))
                              .Pick()
                              .If(x => _typesToRegister.Contains(x))
                              .WithService
                              .FirstInterface()
                              .LifestylePerWebRequest());
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