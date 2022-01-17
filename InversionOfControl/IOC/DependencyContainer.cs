using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace InversionOfControl.IOC
{
    public class DependencyContainer : IDependencyContainer
    {
        private readonly Dictionary<Type, Type> _services;

        public DependencyContainer()
        {
            _services = new Dictionary<Type, Type>();
        }

        public IDependencyContainer Add<TService, TImplementation>()
            where TService : class
            where TImplementation : TService
        {
            _services[typeof(TService)] = typeof(TImplementation);
            return this;
        }

        public TService Get<TService>()
            where TService : class
        {
            if (!this._services.ContainsKey(typeof(TService)))
            {
                return null;
            }
            return (TService)Activator.CreateInstance(this._services[typeof(TService)]);
        }

        public object CreateInstance<T>()
        => this.CreateInstance(typeof(T));

        public object CreateInstance(Type type)
        {
            Type instanceType = this._services[type] ?? type;

            if (instanceType.IsInterface || instanceType.IsAbstract)
            {
                throw new InvalidOperationException($"The {instanceType.FullName} cannot be instantiated.");
            }

            ConstructorInfo constructor = instanceType
                .GetConstructors()
                .OrderBy(x => x.GetParameters().Length)
                .First();

            ParameterInfo[] constructorParameters = constructor.GetParameters();

            object[] constructorParametersObjects = new object[constructorParameters.Length];

            for (int i = 0; i < constructorParameters.Length; i++)
            {
                constructorParametersObjects[i] = this.CreateInstance(constructorParameters[i].ParameterType);
            }
            return constructor.Invoke(constructorParametersObjects);
        }
    }
}
