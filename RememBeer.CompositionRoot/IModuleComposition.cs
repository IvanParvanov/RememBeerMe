using Ninject;

namespace RememBeer.CompositionRoot
{
    public interface IModuleComposition
    {
        void RegisterServices(IKernel kernel);
    }
}
