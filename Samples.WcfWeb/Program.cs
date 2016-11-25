using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace Samples.WcfWeb
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var svcHost = new WebServiceHost(typeof(ServiceInfo));

			//Uri baseAddress = new Uri("http://localhost:8000/");
			//var svcEndpoint = svcHost.AddServiceEndpoint(typeof(IServiceInfo),
			//  new WebHttpBinding(), baseAddress);
			//svcEndpoint.Behaviors.Add(new WebHttpBehavior());

			svcHost.Open();
			Console.WriteLine("Press enter to quit...");
			Console.ReadLine();

			svcHost.Close();
		}
	}
}
