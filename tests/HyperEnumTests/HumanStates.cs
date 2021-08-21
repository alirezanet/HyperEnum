using HyperEnum;

// ReSharper disable once CheckNamespace
namespace TestNamespace.SubTestNamespace
{
    [HyperEnum]
    public enum HumanStates
    {
        Idle,
        Working,
        Sleeping,
        Eating,
        Dead
    }

    public struct TestStruct
    {
        [HyperEnum]
        public enum Test2
        {
            Item1,
            Item2,
            Item3
        }
    }


    public class TestClass
    {
        public class TestClass2
        {
            [HyperEnum]
            public enum Test3
            {
                Item1 = 0,
                Item2 = 2
            }
        }
    }
}