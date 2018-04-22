namespace InstanceCounter
{
    using System;
    using System.Threading;

    class Program
    {
        public static void Main(string[] args)
        {
            var factory = CountableObjectFactory.getInstance();

            var one = factory.createCountableObjectInstance(CountableObjectTypes.CountableObject1.ToString());
            var two = factory.createCountableObjectInstance(CountableObjectTypes.CountableObject1.ToString());
            var three = factory.createCountableObjectInstance(CountableObjectTypes.CountableObject2.ToString());
            var four = factory.createCountableObjectInstance(CountableObjectTypes.CountableObject3.ToString());

            Console.WriteLine("CountableObject1 instances:" + CountableObject1.getCountInstances());
            Console.WriteLine("CountableObject2 instances:" + CountableObject2.getCountInstances());
            Console.WriteLine("CountableObject3 instances:" + CountableObject3.getCountInstances());
            Console.WriteLine("From table CountableObject1 instances:" + CountableObjectRegistry.getCountableObjectInstances(CountableObjectTypes.CountableObject1.ToString()));
            Console.WriteLine("From table CountableObject2 instances:" + CountableObjectRegistry.getCountableObjectInstances(CountableObjectTypes.CountableObject2.ToString()));
            Console.WriteLine("From table CountableObject3 instances:" + CountableObjectRegistry.getCountableObjectInstances(CountableObjectTypes.CountableObject3.ToString()));
        }
    }
}