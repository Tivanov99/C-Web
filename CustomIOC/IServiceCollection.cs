using System;

namespace CustromInversionOfControll.Services
{
    public interface IServiceCollection
    {
        IServiceCollection Add<TService, TImplementation>()
            where TService : class
            where TImplementation : TService;

        IServiceCollection Add<TService>()
            where TService : class;

        object CreateInstance(Type serviceType);

        TService Get<TService>()
            where TService : class;
    }
}
