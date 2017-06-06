using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class EnumeratorTests
    {
        private static readonly string Padding = new string(' ', 30);

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

        [Test]
        public void ShouldLinqClosures()
        {
            var actions = new List<Func<int>>();

            foreach (var i in Enumerable.Range(1, 4))
            {
                actions.Add(() => i);
            }

            // C# 5.0+
            actions.Select(p => p()).Should().BeEquivalentTo(1, 2, 3, 4);

            // C# 1.0 - 4.0
            //actions.Select(p => p()).Should().BeEquivalentTo(4, 4, 4, 4);

        }

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

        private void ForeachImpl()
        {
            var values = GetNumbersEnumerable();
            var funcs = new List<Func<int>>();

            //foreach (var v in values)
            //{
            //    var v2 = v;
            //    funcs.Add(() => v2);
            //}

            
            IEnumerator<int> e = ((IEnumerable<int>)values).GetEnumerator();
            try
            {
                //  C# 1.0 - 4.0
                int m; // �� ������ foreach
                while (e.MoveNext())
                {
                    m = (int)e.Current;
                    funcs.Add(() => m);
                }

                // C# 5.0+
                //while (e.MoveNext())
                //{
                //    int m; // ������ �����
                //    m = (int)e.Current;
                //    funcs.Add(() => m);
                //}
            }
            finally
            {
                if (e != null)
                    e.Dispose();
            }
        }
    }
}