using Nancy;
using Nancy.ModelBinding;

namespace Samples.NancyFx.Modules
{
    public class RootRoutes : NancyModule
    {
        public RootRoutes()
        {
            Get["/"] = Index;
            Get["json"] = Json;
            Get["hello/{name}"] = HelloName;
            Post["post"] = PostTest;
        }

        private dynamic Json(dynamic parameters)
        {
            var test = new
            {
                Name = "Seavcom",
                Id = 12345,
                Collection = new[] { "item1", "item2" },
                Occupation = "Software Developer"
            };

            return Response.AsJson(test);
        }

        private dynamic Index(dynamic parameters)
        {
            return "Hello World";
        }

        private dynamic HelloName(dynamic parameters)
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
        public string Name { get; set; }

        public int Id { get; set; }

        public string Occupation { get; set; }

    }
}
