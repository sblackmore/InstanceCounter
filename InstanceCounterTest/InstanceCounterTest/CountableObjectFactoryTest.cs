namespace InstanceCounterTest
{
    using NUnit.Framework;
    using System;
    using System.Collections;
    using InstanceCounter;

    [TestFixture()]
    public class CountableObjectFactoryTest
    {
        [Test()]
        public void TestCase()
        {
            var factory = new CountableObjectFactory();
            var foo = factory.createCountableObject1Instance();
            var bar = factory.createCountableObject1Instance();


            //  Assert.AreEqual(countableObjectFactoryList.Count, CountableObject1.getCountInstances());
            Console.WriteLine(CountableObject1.getCountInstances());
            Assert.AreEqual(2, CountableObject1.getCountInstances());       
        }
    }
}
