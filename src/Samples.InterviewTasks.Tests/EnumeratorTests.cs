using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class EnumeratorTests
    {
        [Test]
        public void ShouldManualYieldEnumerator()
        {
            Console.WriteLine("Calling GetNumbersEnumerator()");
            IEnumerator<int> iterator = GetNumbersEnumerator();
            Console.WriteLine("Calling MoveNext()...");
            bool more = iterator.MoveNext();
            Console.WriteLine("Result={0}; Current={1}", more, iterator.Current);

            Console.WriteLine("Calling MoveNext() again...");
            more = iterator.MoveNext();
            Console.WriteLine("Result={0}; Current={1}", more, iterator.Current);

            Console.WriteLine("Calling MoveNext() again...");
            more = iterator.MoveNext();
            Console.WriteLine("Result={0} (stopping)", more);
        }

        [Test]
        public void ShouldForeachYieldEnumerator()
        {
            Console.WriteLine("Before foreach GetNumbersEnumerable()");
            foreach (var number in GetNumbersEnumerable())
            {
                Console.WriteLine($"Inside foreach number = {number}");
            }
            Console.WriteLine("After foreach GetNumbersEnumerable()");
        }

        private static readonly string Padding = new string(' ', 30);

        private static IEnumerator<int> GetNumbersEnumerator()
        {
            Console.WriteLine(Padding + "First line of GetNumbersEnumerator()");

            Console.WriteLine(Padding + "Just before yield return 0");
            yield return 10;
            Console.WriteLine(Padding + "Just after yield return 0");

            Console.WriteLine(Padding + "Just before yield return 1");
            yield return 20;
            Console.WriteLine(Padding + "Just after yield return 1");
        }

        private static IEnumerable<int> GetNumbersEnumerable()
        {
            Console.WriteLine(Padding + "First line of GetNumbersEnumerable()");

            Console.WriteLine(Padding + "Just before yield return 0");
            yield return 10;
            Console.WriteLine(Padding + "Just after yield return 0");

            Console.WriteLine(Padding + "Just before yield return 1");
            yield return 20;
            Console.WriteLine(Padding + "Just after yield return 1");
        }
    }
}