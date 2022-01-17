using System;
using InversionOfControl.Animals;
using InversionOfControl.IOC;
namespace InversionOfControl
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DependencyContainer serviceCollection = new DependencyContainer();
            serviceCollection.Add<ISoundMaker, SoundMaker>();

            Lion lion = new Lion(serviceCollection);
            lion.GetSpecialSound();

            Console.WriteLine("Hello World!");
        }
    }
}
