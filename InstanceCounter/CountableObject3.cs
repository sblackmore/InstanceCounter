namespace InstanceCounter
{
    public class CountableObject3 : ICountable
    {
        static int countInstances = 0;

        internal CountableObject3()
        {
            countInstances++;
        }

        public static int getCountInstances()
        {
            return countInstances;
        }
    }
}
