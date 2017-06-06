using System;
using System.IO;
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
            var output = new StringWriter();
            var outString = output.GetStringBuilder();
            Console.SetOut(output);
            
            var foo  = new Foo();
            Console.Write(foo);
            outString.ToString().Should().Be("AAA");

            outString.Clear();

            Console.Write(foo);
            output.ToString().Should().Be("AAA");

        }

        private struct Foo
        {
            int _value;

            public override string ToString()
            {
                if (_value == 2)
                    return "CCC";
                return _value++ == 0 ? "AAA" : "BBB";
            }
        }
    }
}