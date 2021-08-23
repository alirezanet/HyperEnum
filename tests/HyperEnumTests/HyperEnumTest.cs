using System;
using Xunit;
using HyperEnum;
using TestNamespace.SubTestNamespace;

namespace HyperEnumTests
{
    public class HyperEnumTest
    {
        [Fact]
        public void HyperEnumGetNameExtension()
        {
            Assert.Equal("Dead", HumanStates.Dead.GetName());
            Assert.Equal("Item2", TestStruct.Test2.Item2.GetName());
            Assert.Equal("Item1", TestClass.TestClass2.Test3.Item1.GetName());
        }

        [Fact]
        public void HyperEnumClassGetNames()
        {
            var expected = Enum.GetNames<HumanStates>();
            var actual = HyperEnumHelper.GetHumanStatesNames();

            Assert.NotEmpty(actual);
            Assert.Equal(expected, actual);
        }
    }
}