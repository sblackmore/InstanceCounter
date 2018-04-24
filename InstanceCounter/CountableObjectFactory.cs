namespace InstanceCounter
{
    using System;

    // This class is responsible for instantiating objects and informing the Registry to update the instances it is tracking.
    public class CountableObjectFactory
    {
        CountableObjectRegistry registry;

        public CountableObjectFactory(CountableObjectRegistry registry) 
        {
            this.registry = registry;
        }

        // Creates an object of type <T> and updates the Registry with the new instance.
        public T createCountableObjectInstance<T>(createInstance<T> createInstanceMethod)
        {
            var instance = createInstanceMethod();
            registry.addCountableObjectInstance(instance);
            return instance;
        }

        // Method that will return any object
        public delegate T createInstance<T>();
    }
}

