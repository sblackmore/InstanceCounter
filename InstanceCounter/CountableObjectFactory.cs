namespace InstanceCounter
{
    public class CountableObjectFactory
    {
        static CountableObjectFactory instance;

        CountableObjectFactory() { }

        public static CountableObjectFactory getInstance() 
        {
            if (instance == null)
            {
                instance = new CountableObjectFactory();
            }
            return instance;
        }

        public ICountable createCountableObject1Instance()
        {
            return new CountableObject1();
        }
    }
}

