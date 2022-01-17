
namespace InversionOfControl.Animals
{
    public interface IAnimal
    {
        public int Age { get; set; }

        public string Name { get; set; }

        public bool IsAggressive { get; }

        public bool IsExotic { get;  }

        void GetSpecialSound();
    }
}
