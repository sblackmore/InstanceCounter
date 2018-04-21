using System;
namespace InstanceCounter
{
    public class CountableObjectFactory
    {
        public CountableObjectFactory()
        {

        }

        public ICountable createCountableObject1Instance()
        {
            return new CountableObject1();

        }
    }
}

