using System;
using Nancy;
using Nancy.ModelBinding;

namespace Samples.NancyFx.Modules
{
    public class RootRoutes : NancyModule
    {
        private readonly ISimpleDependency _dependency;

        public RootRoutes(ISimpleDependency dependency)
        {
            if (dependency == null) throw new ArgumentNullException(nameof(dependency));
            _dependency = dependency;

            Get["/"] = Index;
            Get["json"] = Json;
            Get["hello/{name}"] = HelloName;
            Post["post"] = PostTest;
        }

        private dynamic Json(dynamic parameters)
        {
            var test = new Person
            {
                Name = "Seavcom",
                Id = 12345,
                Collection = new[] { "item1", "item2" },
                Occupation = "Software Developer",
                SimpleProviderCounter = _dependency.ConstructorCounter
            };

            return Response.AsJson(test);
        }

        private static dynamic Index(dynamic parameters)
        {
            return "Hello World";
        }

        private static dynamic HelloName(dynamic parameters)
        {
            var name = parameters.name;
            return string.Format("Hello there {0}", name);
        }

        private dynamic PostTest(dynamic parameters)
        {
            var myPerson = this.Bind<Person>();

            return $"Hello Person Name = {myPerson.Name}, " +
                   $"Id = {myPerson.Id}, " +
                   $"Occupation = {myPerson.Occupation}";
        }
    }

    public class Person
    {
        public Person()
        {
            Collection = new string[0];
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public string Occupation { get; set; }

        public string[] Collection { get; set; }

        public int SimpleProviderCounter { get; set; }
    }
}
