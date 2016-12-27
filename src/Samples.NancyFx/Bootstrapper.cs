using Nancy;
using Nancy.Diagnostics;
using Nancy.TinyIoc;
using Newtonsoft.Json;
using Samples.NancyFx.Common;

namespace Samples.NancyFx
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);

            container.Register<JsonSerializer, CustomJsonSerializer>();

            // Абстрактные классы или интерфейсы по умолчанию регистрируются как Singleton
            container.Register<ISimpleDependency, SimpleDependency>();
        }

        protected override DiagnosticsConfiguration DiagnosticsConfiguration => 
            new DiagnosticsConfiguration { Password = @"1" };
    }
}
