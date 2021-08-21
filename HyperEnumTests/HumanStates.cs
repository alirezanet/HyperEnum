using EnumTools;

// ReSharper disable once CheckNamespace
namespace TestNamespace.SubTestNamespace
{
    [EnumTools]
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
        [EnumTools]
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
            [EnumTools]
            public enum Test3
            {
                Item1 = 0,
                Item2 = 2
            }
        }
    }
}