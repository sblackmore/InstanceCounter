namespace InstanceCounter
{
    public class CountableObject2 : ICountable
    {
        static int countInstances = 0;

        internal CountableObject2()
        {
            countInstances++;
        }

        public static int getCountInstances()
        {
            return countInstances;
        }
    }
}
