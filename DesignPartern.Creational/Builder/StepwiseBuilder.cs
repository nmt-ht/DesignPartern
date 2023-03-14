namespace DesignPartern.Creational.Builder.StepwiseBuilder
{
    public enum CarType
    {
        Sedan,
        Crossover
    };
    public class Car
    {
        public CarType Type;
        public int WheelSize;
    }

    public interface ISpecifyCarType
    {
        public ISpecifyWheelSize OfType(CarType type);
    }

    public interface ISpecifyWheelSize
    {
        public IBuildCar WithWheels(int size);
    }

    public interface IBuildCar
    {
        public Car Build();
    }

    public class CarBuilder
    {
        public static ISpecifyCarType Create()
        {
            return new Impl();
        }

        private class Impl :
          ISpecifyCarType,
          ISpecifyWheelSize,
          IBuildCar
        {
            private Car car = new Car();

            public ISpecifyWheelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case CarType.Crossover when size < 17 || size > 20:
                    case CarType.Sedan when size < 15 || size > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
                }
                car.WheelSize = size;
                return this;
            }

            public Car Build()
            {
                Console.WriteLine(ToString());
                return car;
            }

            public override string ToString()
            {
                return $"Type of car: {car.Type}, Wheelsize is {car.WheelSize}";
            }
        }
    }
}
