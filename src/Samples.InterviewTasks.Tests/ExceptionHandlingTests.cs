using System;
using NUnit.Framework;

namespace Samples.InterviewTasks.Tests
{
    [TestFixture]
    public class ExceptionHandlingTests
    {
        [Test]
        public void ShouldTryCatchFinallyExpectedOrder()
        {
            Assert.Throws<InvalidTimeZoneException>(() =>
            {
                try
                {
                    throw new InvalidOperationException("1");
                }
                catch (Exception)
                {
                    throw new InvalidCastException("2");
                }
                finally
                {
                    throw new InvalidTimeZoneException("3");
                }
            });

        }
    }
}