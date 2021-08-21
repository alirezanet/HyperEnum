using Xunit;
using HyperEnum;
using TestNamespace.SubTestNamespace;

namespace HyperEnumTests
{
    public class HyperEnumTest 
    {
        [Fact]
        public void FastGetName()
        {
            Assert.Equal("Dead", HumanStates.Dead.GetName());
            Assert.Equal("Item2", TestStruct.Test2.Item2.GetName());
            Assert.Equal("Item1", TestClass.TestClass2.Test3.Item1.GetName());
        }
    }
}