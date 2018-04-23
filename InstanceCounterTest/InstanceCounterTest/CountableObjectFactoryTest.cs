namespace InstanceCounterTest
{
    using NUnit.Framework;
    using System;
    using InstanceCounter;

    [TestFixture()]
    public class CountableObjectFactoryTest
    {
        readonly CountableObjectRegistry registry = CountableObjectRegistry.getInstance();

        [Test()]
        public void TestCase()
        {
            //    var factory = new CountableObjectFactory(registry);
            //    var foo = factory.createCountableObjectInstance(CountableObjectTypes.CountableObject1.ToString());
            //    var bar = factory.createCountableObjectInstance(CountableObjectTypes.CountableObject1.ToString());
            //    Assert.AreEqual(2, registry.getCountableObjectInstances(CountableObjectTypes.CountableObject1.ToString()));       
            //}
        }
    }
}
