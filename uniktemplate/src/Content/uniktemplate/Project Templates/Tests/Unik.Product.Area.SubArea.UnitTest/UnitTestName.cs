namespace $safeprojectname$
{
    using System;
    using $ext_safeprojectname$.Domain.Models;
    using Xunit;

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
