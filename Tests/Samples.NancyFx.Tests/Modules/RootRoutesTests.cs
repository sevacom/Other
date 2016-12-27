using FluentAssertions;
using Nancy;
using Nancy.Testing;
using NUnit.Framework;
using Samples.NancyFx.Modules;

namespace Samples.NancyFx.Tests.Modules
{
    [TestFixture]
    public class RootRoutesTests
    {
        private Browser _browser;

        [SetUp]
        public void Setup()
        {
            var bootstrapper = new Bootstrapper();
            _browser = new Browser(bootstrapper);
        }

        [Test]
        public void Should_return_status_ok_when_route_index()
        {
            // Given // When
            var response = _browser.Get("/", with => {
                with.HttpRequest();
            });

            // Then
            response.StatusCode.Should().Be(HttpStatusCode.OK);
        }

        [Test]
        public void Should_return_json_person_when_route_json()
        {
            // Given 
            var expectedPerson = new Person
            {
                Name = "Seavcom",
                Id = 12345,
                Collection = new[] {"item1", "item2"},
                Occupation = "Software Developer",
                SimpleProviderCounter = 1
            };
            
            // When
            var response = _browser.Get("/json", with => with.HttpRequest());
            var actualPerson = response.Body.DeserializeJson<Person>();

            // Then
            actualPerson.ShouldBeEquivalentTo(expectedPerson);
        }
    }
}
