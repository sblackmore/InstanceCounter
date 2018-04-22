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
            var foo = factory.createCountableObjectInstance(CountableObjectTypes.CountableObject1.ToString());
            var bar = factory.createCountableObjectInstance(CountableObjectTypes.CountableObject1.ToString());

            Console.WriteLine(CountableObject1.getCountInstances());
            Assert.AreEqual(2, CountableObject1.getCountInstances());       
        }
    }
}
