namespace InstanceCounterTest
{
    using NUnit.Framework;
    using System;
    using InstanceCounter;

    [TestFixture()]
    public class CountableObjectFactoryTest
    {
        [Test()]
        public void TestCase()
        {
            var factory = CountableObjectFactory.getInstance();
            var foo = factory.createCountableObject1Instance();
            var bar = factory.createCountableObject1Instance();

            Console.WriteLine(CountableObject1.getCountInstances());
            Assert.AreEqual(2, CountableObject1.getCountInstances());       
        }
    }
}
