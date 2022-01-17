namespace InversionOfControl.Animals
{
    using InversionOfControl.IOC;
    using System;

    public class Lion : IAnimal
    {
        private readonly ISoundMaker soundMaker;

        public Lion(IDependencyContainer container, bool isAggressive)
        {
            this.soundMaker = container.Get<ISoundMaker>();
            this.IsAggressive = isAggressive;
            IsExotic = true;
        }

        public int Age { get; set; }

        public string Name { get; set; }

        public bool IsAggressive { get; private set; }
        public bool IsExotic { get; private set; }

        public void GetSpecialSound()
        {
            this.soundMaker.SpecialSound();
        }

        public void GetBornDate()
        {
            Console.WriteLine(DateTime.Now);
        }
    }
}
