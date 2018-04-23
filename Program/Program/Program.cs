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
            one = null;
            GC.Collect(GC.GetGeneration(one));
            registry.printStatistics();
            System.Threading.Thread.Sleep(5000);
            registry.printStatistics();
        }


    }
}