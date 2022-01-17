namespace InversionOfControl.Animals
{
    using System;
    public class SoundMaker : ISoundMaker
    {
        public void SpecialSound()
        {
            Console.WriteLine("Meowww");
        }

        public void GetSomeData()
        {
            Console.WriteLine("Making requst to database...");

            Console.WriteLine("Request are completed!");

            Console.WriteLine("The data are following:");
            Console.WriteLine("User - Trix are 22 years old \r\n User - Rali are 25 years old");
        }
    }
}
