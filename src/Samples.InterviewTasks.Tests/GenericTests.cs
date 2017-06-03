using FluentAssertions;
using NUnit.Framework;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedParameter.Global
// ReSharper disable ClassNeverInstantiated.Local
// ReSharper disable RedundantAssignment
// ReSharper disable UnusedVariable

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class GenericTests
    {
        [Test]
        public void ShouldCreateStaticFieldForEachGenericWithSpecificReferenceType()
        {
            GenericClass<Base>.StaticField = 42;
            GenericClass<Derived>.StaticField = 43;
            
            GenericClass<Derived>.StaticField.Should().NotBe(GenericClass<Base>.StaticField);
            GenericClass<Model>.StaticField.Should().Be(2);
        }

        [Test]
        public void ShouldCreateStaticFieldForEachGenericWithSpecificValueType()
        {
            GenericClass<int>.StaticField = 56;
            GenericClass<uint>.StaticField = 57;

            GenericClass<uint>.StaticField.Should().NotBe(GenericClass<int>.StaticField);
            GenericClass<double>.StaticField.Should().Be(2);
        }

        [Test]
        public void ShouldInvariantNotAllowImplicitCasting()
        {
            IInvariant<Base> invariantBase = new GenericClass<Base>();
            IInvariant<Derived> invariantDerived = new GenericClass<Derived>();

            // NOT ALLOWED, compilation error
            //invariantBase = invariantDerived;
            //invariantDerived = invariantBase;
        }

        [Test]
        public void ShouldCovariantAllowImplicitUpcasting()
        {
            ICovariant<Base> covariantBase = new GenericClass<Base>();
            ICovariant<Derived> covariantDerived = new GenericClass<Derived>();

            // allowed implicit upcasting
            covariantBase = covariantDerived;

            // not allowed implicit downcasting
            //covariantDerived = covariantBase;

            covariantBase.Should().Be(covariantDerived);
        }

        [Test]
        public void ShouldContravariantAllowImplicitDowncasting()
        {
            IContravariant<Base> contravariantBase = new GenericClass<Base>();
            IContravariant<Derived> contravariantDerived = new GenericClass<Derived>();

            // not allowed implicit upcasting
            //contravariantBase = contravariantDerived;

            // allowed implicit downcasting
            contravariantDerived = contravariantBase;

            contravariantDerived.Should().Be(contravariantBase);
        }

        private class Base
        {
        }

        private class Derived : Base
        {
        }

        private class Model
        {
            
        }

        private interface IInvariant<T>
        {
            T SetGet(T arg);
        }

        private interface ICovariant<out T>
        {
            T Get();
        }

        private interface IContravariant<in T>
        {
            void Set(T arg);
        }

        private class GenericClass<T> : ICovariant<T>, IContravariant<T>, IInvariant<T>
        {
            public static int StaticField = 2;

            public T Get()
            {
                return default(T);
            }

            public void Set(T arg)
            {
            }

            public T SetGet(T arg)
            {
                return default(T);
            }
        }
    }
}