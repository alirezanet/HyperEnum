using Xunit;
using EnumTools;
using TestNamespace.SubTestNamespace;

namespace EnumToolsTests
{
    public class UnitTest1
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