using FluentAssertions;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class GenericTests
    {
        [Test]
        public void ShouldOneStaticFieldPerGenericWithSpecificType()
        {
            GenericClass<Model1>.StaticValue = 42;
            GenericClass<Model2>.StaticValue = 43;
            GenericClass<Model2>.StaticValue.Should().NotBe(GenericClass<Model1>.StaticValue);

            GenericClass<int>.StaticValue = 56;
            GenericClass<uint>.StaticValue = 57;
            GenericClass<uint>.StaticValue.Should().NotBe(GenericClass<int>.StaticValue);
        }

        [Test]
        public void ShouldCovariant()
        {
            var val1 = new GenericClass<Model1>();
            var val2 = new GenericClass<Model2>();
            CovariantMethod(val1);
            CovariantMethod(val2);
        }

        private class Model1 { }
            
        private class Model2:Model1 { }

        private interface IGenericCovariant<out T>
        {
            T Get();
        }

        private interface IGenericContravariant<in T>
        {
            void Set(T arg);
        }

        private class GenericClass<T> : IGenericCovariant<T>
        {
            public static int StaticValue = 2;

            public T Get()
            {
                return default(T);
            }
        }

        private static Model1 CovariantMethod(IGenericCovariant<Model1> link)
        {
            return link.Get();
        }
    }
}