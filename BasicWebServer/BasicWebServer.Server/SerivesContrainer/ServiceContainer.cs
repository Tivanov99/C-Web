<<<<<<< HEAD
﻿namespace BasicWebServer.Server.SerivesContrainer
{
    public class ServiceContainer : IServiceContainer
    {
        private Dictionary<Type, Type> _services;

        public ServiceContainer()
        {
            _services = new();
        }

        public IServiceContainer Add<TService, TImplementation>()
            where TService : class
            where TImplementation : TService
        {
            this._services[typeof(TService)] = typeof(TImplementation);
            return this;
        }

        public IServiceContainer Add<TService>() where TService : class
        => this.Add<TService, TService>();

        public object CreateInstance(Type serviceType)
        {
            if (this._services.ContainsKey(serviceType))
            {
                serviceType = this._services[serviceType];
            }
            else if (serviceType.IsInterface)
            {
                throw new InvalidOperationException($"Service {serviceType.FullName} is not registered!");
            }

            var constructors = serviceType.GetConstructors();

            if (constructors.Length > 1)
            {
                throw new InvalidOperationException("Multiple constructors are not supported");
            }


            var constructor = constructors[0];
            var parameters = constructor
                .GetParameters();

            var parameterValues = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameterType = parameters[i].ParameterType;
                var parameter = CreateInstance(parameterType);

                parameterValues[i] = parameter;
            }

            return constructor.Invoke(parameterValues);
        }

        public TService Get<TService>()
            where TService : class
        {
            var serviceType = typeof(TService);

            if (!this._services.ContainsKey(serviceType))
            {
                return null;
            }

            return (TService)CreateInstance(serviceType);
        }
    }
}
=======
﻿namespace BasicWebServer.Server.SerivesContrainer
{
    public class ServiceContainer : IServiceContainer
    {
        private Dictionary<Type, Type> _services;

        public ServiceContainer()
        {
            _services = new();
        }

        public IServiceContainer Add<TService, TImplementation>()
            where TService : class
            where TImplementation : TService
        {
            this._services[typeof(TService)] = typeof(TImplementation);
            return this;
        }

        public IServiceContainer Add<TService>() where TService : class
        => this.Add<TService, TService>();

        public object CreateInstance(Type serviceType)
        {
            if (this._services.ContainsKey(serviceType))
            {
                serviceType = this._services[serviceType];
            }
            else if (serviceType.IsInterface)
            {
                throw new InvalidOperationException($"Service {serviceType.FullName} is not registered!");
            }

            var constructors = serviceType.GetConstructors();

            if (constructors.Length > 1)
            {
                throw new InvalidOperationException("Multiple constructors are not supported");
            }


            var constructor = constructors[0];
            var parameters = constructor
                .GetParameters();

            var parameterValues = new object[parameters.Length];

            for (int i = 0; i < parameters.Length; i++)
            {
                var parameterType = parameters[i].ParameterType;
                var parameter = CreateInstance(parameterType);

                parameterValues[i] = parameter;
            }

            return constructor.Invoke(parameterValues);
        }

        public TService Get<TService>()
            where TService : class
        {
            var serviceType = typeof(TService);

            if (!this._services.ContainsKey(serviceType))
            {
                return null;
            }
            return (TService)CreateInstance(serviceType);
        }
    }
}
>>>>>>> 33a760b24ee2de37f1d9e6bfd2e606b1a1be8796
