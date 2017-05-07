using FluentAssertions;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class GenericTests
    {
        [Test]
        public void ShouldOneStaticFieldForGenericWithSpecificType()
        {
            GenericClass<Model1>.StaticValue = 42;
            GenericClass<Model2>.StaticValue.Should().NotBe(GenericClass<Model1>.StaticValue);

            GenericClass<int>.StaticValue = 56;
            GenericClass<uint>.StaticValue.Should().NotBe(GenericClass<int>.StaticValue);
        }

        private class GenericClass<T>
        {
            public static int StaticValue = 2;
        }


        private class Model1 { }
            
        private class Model2 { }
    }
}