using System;
using System.IO;
using System.Text;
using FluentAssertions;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class ValueTypeTests
    {
        [Test]
        public void ShouldCopyValueType()
        {
            var outString = SetupConsoleWriteBuffer();
            var foo  = new Foo();

            Console.WriteLine(foo);
            Console.WriteLine(foo);

            outString.ToString().Should().Be(
                "AAA\r\n" +
                "AAA\r\n");

        }

        private static StringBuilder SetupConsoleWriteBuffer()
        {
            var output = new StringWriter();
            Console.SetOut(output);

            return output.GetStringBuilder();
        }

        private struct Foo
        {
            private int _value;

            public override string ToString()
            {
                if (_value == 2)
                    return "CCC";
                return _value++ == 0 ? "AAA" : "BBB";
            }
        }
    }
}