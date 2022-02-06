namespace BasicWebServer.Server.SerivesContrainer
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
