namespace InstanceCounter
{
    using System;

    public class CountableObjectFactory
    {
        CountableObjectRegistry registry;
        public CountableObjectFactory(CountableObjectRegistry registry) 
        {
            this.registry = registry;
        }

        public T createCountableObjectInstance<T>(createInstance<T> foo)
        {
            var temp = foo();
            var tempType = temp.GetType();

            registry.addCountableObjectInstance(temp);
            return temp;
        }

        public delegate T createInstance<T>();
    }
}

