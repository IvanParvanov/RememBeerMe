using System;
using System.IO;
using System.Linq;

using Ninject;
using Ninject.Extensions.Conventions;
using Ninject.Syntax;

using RememBeer.CompositionRoot.NinjectModules;

using WebFormsMvp.Binder;

namespace RememBeer.CompositionRoot
{
    public class DefaultComposition
    {
        public void RegisterServices(IKernel kernel)
        {
            BindDefaultInterfaces(kernel);
            LoadModules(kernel);
        }

        private static void LoadModules(IKernel kernel)
        {
            kernel.Load(new BusinessNinjectModule());
            kernel.Load(new DataNinjectModule());
        }

        private static void BindDefaultInterfaces(IBindingRoot kernel)
        {
            kernel.Bind(x =>
                        {
                            var assemblies = AppDomain.CurrentDomain
                                                      .GetAssemblies()
                                                      .Where(a => a.FullName.StartsWith("RememBeer."));

                            foreach (var assembly in assemblies)
                            {
                                var assemblyLocation = assembly.Location;
                                var directoryPath = Path.GetDirectoryName(assemblyLocation);
                                x.FromAssembliesInPath(directoryPath)
                                 .SelectAllClasses()
                                 .BindDefaultInterface();
                            }
                        });

            kernel.Bind<IKernel>()
                  .ToMethod(ctx => ctx.Kernel);
        }
    }
}
