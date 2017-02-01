using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;

using Ninject;
using Ninject.Extensions.Conventions;

using RememBeer.CompositionRoot.NinjectModules;

namespace RememBeer.CompositionRoot
{
    public class DefaultComposition
    {
        public void RegisterServices(IKernel kernel)
        {
            kernel.Bind(x =>
                        {
                            var assemblies =
                                AppDomain.CurrentDomain.GetAssemblies()
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

            kernel.Load(new BusinessNinjectModule());
            kernel.Load(new DataNinjectModule());
        }
    }
}
