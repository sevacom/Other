using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class LinqTests
    {
        [Test]
        public void ShouldLinqLazyAndClosures()
        {
            var list = new List<string> {"a", "bb", "ccc"};

            var len = 3;
            var linq = list.Where(p => p.Length >= len);
            len = 2;

            linq.Count().Should().Be(2);
        }

        [Test]
        public void ShouldLinqLazy()
        {
            var list = new List<string> {"a", "bb", "ccc"};

            var linq = list.Where(p => p.Length == 2);
            list.Remove("bb");

            linq.Count().Should().Be(0);
        }
    }
}