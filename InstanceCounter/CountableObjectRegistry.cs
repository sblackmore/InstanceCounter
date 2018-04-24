namespace InstanceCounter
{
    using System.Collections.Generic;
    using System;

    // A class to track total instances of objects as well as the number of the objects that are still alive (have not been garbage collected).
    public class CountableObjectRegistry
    {
        static CountableObjectRegistry instance;
        static Dictionary<Type, List<WeakReference>> countableObjectTable;

        CountableObjectRegistry()
        {
            countableObjectTable = new Dictionary<Type, List<WeakReference>>();
        }

        // Created as a Singleton to restrict to one instance so that it is a single source of truth.
        public static CountableObjectRegistry getInstance()
        {
            if (instance == null)
            {
                instance = new CountableObjectRegistry();
            }
            return instance;
        }

        // Updates the countableObjectTable with new types/references, or adds new references for types already in the table.
        internal void addCountableObjectInstance(Object countableObject)
        {
            WeakReference reference = new WeakReference(countableObject);
            if (!countableObjectTable.ContainsKey(countableObject.GetType()))
            {
                countableObjectTable.Add(countableObject.GetType(), new List<WeakReference>());
            }

            countableObjectTable[countableObject.GetType()].Add(reference);
        }

        // Prints the total number of objects that have been instantiated and added to the table.
        // If an object has been set to null and garbage collected, then it is no longer alive. 
        // TODO: Would need to add a task to run periodically to clean out dead references so the list
        // does not grow exponentially.
        public void printStatistics()
        {
            var objectTypes = countableObjectTable.Keys;
            foreach(var objectType in objectTypes)
            {
                int countTotal = countableObjectTable[objectType].Count;
                int liveReferenceCount = 0;
                foreach(var reference in countableObjectTable[objectType])
                {
                    if(reference.IsAlive)
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
    }
}
