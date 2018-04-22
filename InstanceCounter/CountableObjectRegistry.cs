namespace InstanceCounter
{
    using System.Collections.Generic;
                
    public class CountableObjectRegistry
    {
        static Dictionary<string, int> countableObjectTable;
        internal CountableObjectRegistry()
        {
            countableObjectTable = new Dictionary<string, int>();
        }

        internal void addCountableObjectInstance(string countableObject) 
        {
            if (countableObjectTable.ContainsKey(countableObject))
            {
                countableObjectTable[countableObject]++;
            }
            else
            {
                countableObjectTable.Add(countableObject, 1);
            }
        }

        internal void removeCountableObjectInstance(string countableObject)
        {
            if (countableObjectTable.ContainsKey(countableObject))
            {
                countableObjectTable[countableObject]--;
            }
        }

        public static int getCountableObjectInstances(string countableObject)
        {
            if (countableObjectTable.ContainsKey(countableObject))
            {
                return countableObjectTable[countableObject];
            }
            return 0;
        }
    }
}
