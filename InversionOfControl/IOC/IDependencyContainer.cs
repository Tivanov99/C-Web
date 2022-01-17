using System;
using System.Collections.Generic;
using System.Text;

namespace InversionOfControl.IOC
{
    public interface IDependencyContainer
    {
        IDependencyContainer Add<TService, TImplementation>()
            where TImplementation : TService
            where TService : class;

        TService Get<TService>()
            where TService : class;

        object CreateInstance<T>();
    }
}
