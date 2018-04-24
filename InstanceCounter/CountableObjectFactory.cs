namespace InstanceCounter
{
    using System;
    using System.Collections.Generic;

    // This class is responsible for instantiating objects and and tracking how many have been instantiated and are still alive.
    public class CountableObjectFactory
    {
        // A table to keep track of object instances.
        static Dictionary<Type, List<WeakReference>> countableObjectRegistry;

        public CountableObjectFactory() 
        {
            countableObjectRegistry = new Dictionary<Type, List<WeakReference>>();
        }

        // Creates an object of type <T> and updates the registry with the new instance.
        public T createCountableObjectInstance<T>(createInstance<T> createInstanceMethod)
        {
            var instance = createInstanceMethod();
            addCountableObjectInstance(instance);
            return instance;
        }

        // Method that will return any object
        public delegate T createInstance<T>();

        // Prints the total number of objects that have been instantiated and added to the table.
        // If an object has been set to null and garbage collected, then it is no longer alive. 
        // TODO: Would need to add a task to run periodically to clean out dead references so the list
        // does not grow exponentially.
        public void printStatistics()
        {
            var objectTypes = countableObjectRegistry.Keys;
            foreach (var objectType in objectTypes)
            {
                int countTotal = countableObjectRegistry[objectType].Count;
                int liveReferenceCount = 0;
                foreach (var reference in countableObjectRegistry[objectType])
                {
                    if (reference.IsAlive)
                    {
                        liveReferenceCount++;
                    }
                }
                Console.Out.WriteLine("\r\n** Instantiated and Alive Stats for {0} **", objectType);
                Console.Out.WriteLine("All instances created of" + objectType + ": " + countTotal);
                Console.Out.WriteLine("All alive instances  of" + objectType + ": " + liveReferenceCount);
                Console.Out.WriteLine();
            }
        }

        // Updates the countableObjectRegistry with new types/references, or adds new references for types already in the table.
        internal void addCountableObjectInstance(Object countableObject)
        {
            WeakReference reference = new WeakReference(countableObject);
            if (!countableObjectRegistry.ContainsKey(countableObject.GetType()))
            {
                countableObjectRegistry.Add(countableObject.GetType(), new List<WeakReference>());
            }

            countableObjectRegistry[countableObject.GetType()].Add(reference);
        }
    }
}

