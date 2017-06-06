using System.Collections;
using System.Collections.Generic;
using FluentAssertions;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class DuckTypingTests
    {
        [Test]
        public void ShouldForeachWorkWhenOnlyExistGetEnumeratorMethod()
        {
            var actualResults = new List<int>();
            var enumerable = new FakeEnumerable();

            foreach (var i in enumerable)
            {
                actualResults.Add(i);
            }

            actualResults.Should().BeEquivalentTo(1, 2, 3);
        }

        [Test]
        public void ShouldCollectionInitializerWorkWhenOnlyExistAddMethodAndImplementsIEnumerable()
        {
            var collection = new FakeCollection {1, 2, 3, 4};
            collection.Results.Should().BeEquivalentTo(1, 2, 3, 4);


            collection = new FakeCollection
            {
                {1, 2, 3},
                {4, 5, 6}
            };

            collection.Results.Should().BeEquivalentTo(1, 2, 3, 4, 5, 6);
        }

        private class FakeEnumerable
        {
            public IEnumerator<int> GetEnumerator()
            {
                yield return 1;
                yield return 2;
                yield return 3;
            }
        }

        private class FakeCollection: IEnumerable
        {
            public readonly List<int> Results = new List<int>(); 

            public void Add(int i)
            {
                Results.Add(i);
            }

            public void Add(int x, int y, int z)
            {
                Results.Add(x);
                Results.Add(y);
                Results.Add(z);
            }

            /// <summary>
            /// Возвращает перечислитель, который осуществляет итерацию по коллекции.
            /// </summary>
            /// <returns>
            /// Объект <see cref="T:System.Collections.IEnumerator"/>, который может использоваться для перебора коллекции.
            /// </returns>
            public IEnumerator GetEnumerator()
            {
                yield return 1;
            }
        }
    }
}