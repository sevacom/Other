using System;
using Serilog;
using Serilog.Context;

namespace SerilogSample
{
	class Program
	{
		static void Main(string[] args)
		{
			var obj = new Foo();

			var number = 5;
			var count = 1;
			var name = "Seva";
			var template = 
				"{Timestamp:yyyy-MM-dd HH:mm:ss.fff zzz} [{Level}] {Message}{NewLine}"+
				"Version = {Version} EnvironmentUserName = {EnvironmentUserName} MachineName = {MachineName} ThreadId = {ThreadId}"+
				"{NewLine}{Exception}";

			var log = new LoggerConfiguration()
				.MinimumLevel.Debug()
				.Enrich.FromLogContext()
				.Enrich.WithProperty("Version", "2.0.0")
				.Enrich.WithThreadId()
				.Enrich.WithEnvironmentUserName()
				.Enrich.WithMachineName()
				.WriteTo.LiterateConsole(
					outputTemplate: template)
				.WriteTo.RollingFile("logs\\SeriLog-{Date}.txt",
					outputTemplate: template)
				.WriteTo.Seq("http://localhost:5341")
				.CreateLogger();

			log.Information("Hello Name = {Name} Log Count = {Count} Number = {Number} Object = {@Object}", 
				name, count, number, obj);
			
			int a = 10, b = 0;
			try
			{
				using (LogContext.PushProperty("Test", 1))
				{
					log.Debug("Dividing {A} by {B}", a, b);
				}
				Console.WriteLine(a / b);
			}
			catch (Exception ex)
			{
				log.Error(ex, "Something went wrong");
			}

			log.Dispose();

			Console.ReadKey();
		}

		public class Foo
		{
			public Foo()
			{
				Num = 8;
				Foo2Prop = new Foo2
				{
					Dbl = 12.888
				};
			}

			public int Num { get; set; }

			public Foo2 Foo2Prop { get; set; }
		}

		public class Foo2
		{
			public double Dbl { get; set; }
		}
	}
}
