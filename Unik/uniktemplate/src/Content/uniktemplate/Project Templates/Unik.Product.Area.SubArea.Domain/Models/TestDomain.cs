namespace $safeprojectname$.Models
{
    using System;

    public class TestDomain
    {
        private string name;

        private TestDomain() { }

        public TestDomain(string name)
        {
            Name = name;
        }

        public string Name { 
            get => name; 
            private set
            {
                if (value.Length >= 100)
                    throw new ArgumentException("Name is more than 100 characters");

                name = value;
            }
        }

        public static TestDomain Restore(string name)
        {
            return new TestDomain
            {
                name = name
            };
        }
    }
}
