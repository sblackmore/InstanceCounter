using System;
namespace InstanceCounter
{
    public class CountableObject1 : ICountable
    {
        static int countInstances = 0;

        internal CountableObject1()
        {
            countInstances++;
        }

        public static int getCountInstances()
        {
            return countInstances;
        }
    }
}
