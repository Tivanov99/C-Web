<<<<<<< HEAD
﻿namespace BasicWebServer.Server.SerivesContrainer
{
    public interface IServiceContainer
    {
        IServiceContainer Add<TService, TImplementation>()
            where TService : class
            where TImplementation : TService;

        IServiceContainer Add<TService>()
            where TService : class;

        TService Get<TService>()
            where TService : class;

        object CreateInstance(Type serviceType);
    }
}
=======
﻿namespace BasicWebServer.Server.SerivesContrainer
{
    public interface IServiceContainer
    {
        IServiceContainer Add<TService, TImplementation>()
            where TService : class
            where TImplementation : TService;

        IServiceContainer Add<TService>()
            where TService : class;

        TService Get<TService>()
            where TService : class;

        object CreateInstance(Type serviceType);
    }
}
>>>>>>> 33a760b24ee2de37f1d9e6bfd2e606b1a1be8796
