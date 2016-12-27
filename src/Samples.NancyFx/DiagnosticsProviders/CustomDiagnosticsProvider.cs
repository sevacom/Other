using Nancy.Diagnostics;

namespace Samples.NancyFx.DiagnosticsProviders
{
    /// <summary>
    /// Diagnostics http://<address-of-your-application>/_Nancy/
    /// </summary>
    public class CustomDiagnosticsProvider : IDiagnosticsProvider
    {
        public string Name => "Custom diagnostics provider";

        public string Description => "Custom diagnostics provider description";

        public object DiagnosticObject => this;

        [Description("Greets a person using their name")]
        //[Template("<p>{{Model.Result}}</p>")]
        public string HelloMethodWithDescription(string name)
        {
            return $"Hello, {name}";
        }

        public string HelloProperty => "Информация о процессе через свойство";

        public string HelloMethod(string param)
        {
            return $"HelloMethod Param = {param}";
        }
    }
}