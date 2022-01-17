using System;
using System.Collections.Generic;
using System.Text;

namespace InversionOfControl.Animals
{
    public interface IAnimal
    {
        public int Age { get; set; }

        public string Name { get; set; }

        void GetSpecialSound();
    }
}
