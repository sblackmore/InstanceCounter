namespace InstanceCounter
{
    using System;

    public class CountableObjectFactory
    {
        static CountableObjectFactory instance;
        CountableObjectRegistry registry = new CountableObjectRegistry();

        CountableObjectFactory() { }

        public static CountableObjectFactory getInstance() 
        {
            if (instance == null)
            {
                instance = new CountableObjectFactory();
            }
            return instance;
        }

        public ICountable createCountableObjectInstance(string countableObjectType)
        {
            CountableObjectTypes types;
            if (Enum.TryParse(countableObjectType, out types))
            {
                switch (types) 
                { 
                    case CountableObjectTypes.CountableObject1:
                        registry.addCountableObjectInstance(countableObjectType);
                        return new CountableObject1();
                    case CountableObjectTypes.CountableObject2:
                        registry.addCountableObjectInstance(countableObjectType);
                        return new CountableObject2();
                    case CountableObjectTypes.CountableObject3:
                        registry.addCountableObjectInstance(countableObjectType);
                        return new CountableObject3();
                    default:
                        throw new Exception("Must provide a valid countable type");
                }
            }

            throw new Exception("Must provide a valid countable type");
        }
    }
}

