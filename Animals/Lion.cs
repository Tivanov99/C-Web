namespace InversionOfControl.Animals
{
    using InversionOfControl.IOC;
    using System;

    public class Lion
    {
        private readonly ISoundMaker soundMaker;

        public Lion(IDependencyContainer container)
        {
            this.soundMaker = container.Get<ISoundMaker>();
        }

        public int Age { get; set; }

        public string Name { get; set; }

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
