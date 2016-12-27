using System;
using Nancy.Diagnostics;

namespace Samples.NancyFx.DiagnosticsProviders
{
    public class SecondDiagnosticProvider : IDiagnosticsProvider
    {
        private readonly ISimpleDependency _dependency;

        public SecondDiagnosticProvider(ISimpleDependency dependency)
        {
            if (dependency == null) throw new ArgumentNullException(nameof(dependency));
            _dependency = dependency;
        }

        public string Name => "Second provider";

        public string Description => "Second provider description";

        public object DiagnosticObject => this;

        public string GetStatusInformation()
        {
            return $"Current Date = {DateTime.Now} SimpleProviderCounter = {_dependency.ConstructorCounter}";
        }
    }
}