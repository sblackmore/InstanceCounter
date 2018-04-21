namespace InstanceCounter
{
    using System;

    class Program
    {
        public static void Main(string[] args)
        {
            var factory = CountableObjectFactory.getInstance();

            var foo = factory.createCountableObject1Instance();
            var bar = factory.createCountableObject1Instance();

            Console.WriteLine(CountableObject1.getCountInstances());

        }
    }
}