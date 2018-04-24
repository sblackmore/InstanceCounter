# InstanceCounter
This proof of concept solution provides a mechanism to count the number of times a set of classes have been instantiated as well as the number of those classes that are still reachable/alive. The type of class should not matter, so it should be extensible to any class type as long as the class is instantiated using the CountableObjectFactory. The factory returns the object to the caller after updating an internally maintained "registry" of types and weak references. If no more references remain to an object and it is  garbage collected (meaning the WeakReference property IsAlive = false), then the count of alive references for that type will be lower than the total instances of the type.

### Sample Program Output:
```
** Instantiated and Alive Stats for InstanceCounter.CountableObject1 **
All instances created of InstanceCounter.CountableObject1: 2
All alive instances of InstanceCounter.CountableObject1: 2

** Instantiated and Alive Stats for InstanceCounter.CountableObject2 **
All instances created of InstanceCounter.CountableObject2: 3
All alive instances of InstanceCounter.CountableObject2: 3

** Instantiated and Alive Stats for InstanceCounter.CountableObject3 **
All instances created of InstanceCounter.CountableObject3: 1
All alive instances of InstanceCounter.CountableObject3: 1

Setting one of the CountableObject1 instances to null...
Requesting Garbage Collection...
Sleeping for 5 seconds...

** Instantiated and Alive Stats for InstanceCounter.CountableObject1 **
All instances created of InstanceCounter.CountableObject1: 2
All alive instances of InstanceCounter.CountableObject1: 1

** Instantiated and Alive Stats for InstanceCounter.CountableObject2 **
All instances created of InstanceCounter.CountableObject2: 3
All alive instances of InstanceCounter.CountableObject2: 3

** Instantiated and Alive Stats for InstanceCounter.CountableObject3 **
All instances created of InstanceCounter.CountableObject3: 1
All alive instances of InstanceCounter.CountableObject3: 1

Press any key to continue...
```

### Discussion:
I tried several different approaches to this challenge. I first started with using an interface that implemented IDisposable. I had a factory that returned IDisposable after informing a registry class to update counts. The CountableObjects all implemented ICountable, so they also had to also implement IDisposable. The problem with that approach is that these objects are not unmanaged resources like a database connection or file stream. So even though I could "fake" object destruction in my Dispose method and update the count of alive objects, the fact was that the objects were still definitely reachable.

I also considered overriding Object.Finalize() and updating the registry count in my Finalize method. However, this leads to a similar problem in that there is no guarantee as to when the object would be garbage collected after calling Finalize(). So the count would still potentially show the count of reachable objects as having gone down even though the object was still reachable.

The two main issues with my approach are unit testability and the fact that the List<WeakReference> within the CountableObjectFactory's registry object grows exponentially (I added a TODO comment for that in the code). If this was to run in some sort of production environment, then a task or job would have to run periodically to prune the dead WeakReferences from the List. Unit testing is difficult (if not impossible) because of the dependency on the garbage collector. This would lead to flaky and unpredictable tests.
