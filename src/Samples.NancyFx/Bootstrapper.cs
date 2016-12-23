using Nancy;
using Nancy.Diagnostics;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Samples.NancyFx
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<JsonSerializer, CustomJsonSerializer>();
        }

        protected override DiagnosticsConfiguration DiagnosticsConfiguration => 
            new DiagnosticsConfiguration { Password = @"1" };
    }

    public sealed class CustomJsonSerializer : JsonSerializer
    {
        public CustomJsonSerializer()
        {
            ContractResolver = new CamelCasePropertyNamesContractResolver();
            Converters.Add(new StringEnumConverter
            {
                AllowIntegerValues = false,
                CamelCaseText = true
            });
            Formatting = Formatting.Indented;
            
        }
    }
}
