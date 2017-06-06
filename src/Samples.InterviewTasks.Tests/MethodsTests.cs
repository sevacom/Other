using FluentAssertions;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class MethodsTests
    {
        [Test]
        public void ShouldUseRealClassMethodsInsteadInherited()
        {
            new Base().Foo(42).Should().Be("Base.Foo.int");
            new Derived().Foo(42).Should().Be("Derived.Foo.object");
        }

        private class Base
        {
            public virtual string Foo(int x)
            {
                return "Base.Foo.int";
            }
        }

        private class Derived : Base
        {
            public override string Foo(int x)
            {
                return "Derived.Foo.int";
            }

            public object Foo(object x)
            {
                return "Derived.Foo.object";
            }
        }
    }
}