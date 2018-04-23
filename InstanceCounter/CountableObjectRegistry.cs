namespace InstanceCounter
{
    using System.Collections.Generic;
    using System;
                
    public class CountableObjectRegistry
    {
        static CountableObjectRegistry instance;
        static Dictionary<Type, List<WeakReference>> countableObjectTable;

        CountableObjectRegistry()
        {
            countableObjectTable = new Dictionary<Type, List<WeakReference>>();
        }

        public static CountableObjectRegistry getInstance()
        {
            if (instance == null)
            {
                instance = new CountableObjectRegistry();
            }
            return instance;
        }

        internal void addCountableObjectInstance(Object countableObject)
        {
            WeakReference reference = new WeakReference(countableObject);
            if (!countableObjectTable.ContainsKey(countableObject.GetType()))
            {
                countableObjectTable.Add(countableObject.GetType(), new List<WeakReference>());
            }

            countableObjectTable[countableObject.GetType()].Add(reference);
        }

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

                    //if(!reference.IsAlive) {
                    //    countableObjectTable[objectType].Remove(reference);
                    //}
                }
                Console.Out.WriteLine("All instances created of" + objectType + ": " + countTotal);
                Console.Out.WriteLine("All alive instances  of" + objectType + ": " + liveReferenceCount);
                Console.Out.WriteLine();
            }
        }
    }
}
