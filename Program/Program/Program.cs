namespace InstanceCounter
{
    using System;

    class Program
    {
        public static void Main(string[] args)
        {
            var registry = CountableObjectRegistry.getInstance();
            var factory = new CountableObjectFactory(registry);

            var one = factory.createCountableObjectInstance(() => new CountableObject1());
            var two = factory.createCountableObjectInstance(() => new CountableObject1());
            var three = factory.createCountableObjectInstance(() => new CountableObject2());
            var four = factory.createCountableObjectInstance(() => new CountableObject2());
            var five = factory.createCountableObjectInstance(() => new CountableObject2());
            var six = factory.createCountableObjectInstance(() => new CountableObject3());


            registry.printStatistics();
            Console.Out.WriteLine("\r\nSetting one of the CountableObject1 instances to null...");
            one = null;
            Console.Out.WriteLine("Requesting Garbage Collection...");
            GC.Collect(GC.GetGeneration(one));
            Console.Out.Write("Sleeping for 5 seconds...\r\n");
            System.Threading.Thread.Sleep(5000);
            registry.printStatistics();
        }
    }
}