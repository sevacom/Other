using FluentAssertions;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    // https://blogs.msdn.microsoft.com/ericlippert/2009/09/28/string-interning-and-string-empty/
    //If you are trying to reduce the total amount of memory your application allocates, keep in mind that interning a string has two unwanted side effects.
    //First, the memory allocated for interned String objects is not likely be released until the common language runtime (CLR) terminates.
    //The reason is that the CLR's reference to the interned String object can persist after your application, or even your application domain, terminates. 
    //Second, to intern a string, you must first create the string. 
    //The memory used by the String object must still be allocated, even though the memory will eventually be garbage collected.
    [TestFixture]
    public class StringInterningTests
    {

        [Test]
        public void ShouldIntern()
        {
            object obj = "Int32";
            string str1 = "Int32";
            string str2 = typeof (int).Name;

            // RefEquals
            (obj == str1).Should().BeTrue();

            // Equals
            (str1 == str2).Should().BeTrue();

            // RefEquals
            (obj == str2).Should().BeFalse();
        }

        [Test]
        public void ShouldInternWhenEmpty()
        {
            object obj = "";
            string str1 = "";
            string str2 = string.Empty;

            // RefEquals
            (obj == str1).Should().BeTrue();

            // Equals
            (str1 == str2).Should().BeTrue();

            // True - In the .NET Framework 1.0, .NET Framework 1.1, and .NET Framework 3.5 SP1 и выше
            // False - В .NET Framework 2.0 с пакетом обновления 1 (SP1) и .NET Framework 3.0
            (obj == str2).Should().BeTrue();
        }
    }
}
