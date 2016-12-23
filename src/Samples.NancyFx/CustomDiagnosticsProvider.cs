using Nancy.Diagnostics;

namespace Samples.NancyFx
{
    /// <summary>
    /// Diagnostics http://<address-of-your-application>/_Nancy/
    /// </summary>
    public class CustomDiagnosticsProvider : IDiagnosticsProvider
    {
        public string Name => "Custom diagnostics provider";

        public string Description => "Provides custom diagnostics capabilities";

        public object DiagnosticObject => this;

        [Description("Greets a person using their name")]
        //[Template("<p>{{Model.Result}}</p>")]
        public string Greet(string name)
        {
            return string.Concat("Hi, ", name);
        }

        public string GetProcessInfoDescription => "Информация о процессе через свойство";
        public string GetProcessInfo(string param)
        {
            return $"ProcessInfo Param {param}";
        }
    }
}