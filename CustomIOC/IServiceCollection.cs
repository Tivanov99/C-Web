<<<<<<< HEAD
﻿using System;

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
=======
﻿using System;

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
>>>>>>> 33a760b24ee2de37f1d9e6bfd2e606b1a1be8796
