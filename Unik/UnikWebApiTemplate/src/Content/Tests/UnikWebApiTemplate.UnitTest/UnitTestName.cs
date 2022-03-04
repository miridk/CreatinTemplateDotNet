using System;
using UnikWebApiTemplate.Domain.Models;
using Xunit;

namespace UnikWebApiTemplate.UnitTest
{
    public class UnitTestName
    {
        [Fact]
        public void NameCannotBeMoreThan100Characters()
        {
            var name = "abcdefghijklabcdefghijklabcdefghijklabcdefghijklabcdefghijklabcdefghijklabcdefghijklabcdefghijklabcdefghijkl";

            Assert.Throws<ArgumentException>(() => new TestDomain(name));
        }
    }
}
