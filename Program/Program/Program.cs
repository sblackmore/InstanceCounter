using System;

namespace InstanceCounter
{
    class Program
    {
        public static void Main(string[] args)
        {
            var factory = new CountableObjectFactory();

            var foo = factory.createCountableObject1Instance();
            var bar = factory.createCountableObject1Instance();

            Console.WriteLine(CountableObject1.getCountInstances());

        }
    }
}